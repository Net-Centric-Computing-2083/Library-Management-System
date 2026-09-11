using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Data;

namespace LibraryManagementSystem.Forms
{
    public partial class IssueBookForm : Form
    {
        public IssueBookForm()
        {
            InitializeComponent();
        }

        private void IssueBookForm_Load(object sender, EventArgs e)
        {
            dtpIssueDate.Value = DateTime.Now.Date;
            dtpDueDate.Value = DateTime.Now.Date.AddDays(7);
            LoadAvailableBooks();
            LoadMembers();
            LoadIssues();
        }

        private void LoadAvailableBooks()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT BookID, Title FROM Books WHERE AvailableQuantity > 0 ORDER BY Title";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbBook.DisplayMember = "Title";
                cmbBook.ValueMember = "BookID";
                cmbBook.DataSource = dt;
                cmbBook.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load available books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMembers()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MemberID, FullName FROM Members ORDER BY FullName";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "MemberID";
                cmbMember.DataSource = dt;
                cmbMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load members: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIssues()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT i.IssueID, b.BookID, b.Title AS BookTitle, m.MemberID, m.FullName AS MemberName, i.IssueDate, i.DueDate
FROM BookIssues i
JOIN Books b ON i.BookID = b.BookID
JOIN Members m ON i.MemberID = m.MemberID
ORDER BY i.IssueDate DESC";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvIssues.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load issues: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            cmbBook.SelectedIndex = -1;
            cmbMember.SelectedIndex = -1;
            dtpIssueDate.Value = DateTime.Now.Date;
            dtpDueDate.Value = DateTime.Now.Date.AddDays(7);
        }

        private void btnIssue_Click(object? sender, EventArgs e)
        {
            if (cmbBook.SelectedValue == null || !(cmbBook.SelectedValue is int || int.TryParse(cmbBook.SelectedValue.ToString(), out _)))
            {
                MessageBox.Show("Please select a book to issue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMember.SelectedValue == null || !(cmbMember.SelectedValue is int || int.TryParse(cmbMember.SelectedValue.ToString(), out _)))
            {
                MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(cmbBook.SelectedValue);
            int memberId = Convert.ToInt32(cmbMember.SelectedValue);
            DateTime issueDate = dtpIssueDate.Value.Date;
            DateTime dueDate = dtpDueDate.Value.Date;
            if (dueDate < issueDate)
            {
                MessageBox.Show("Due date cannot be earlier than issue date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    using SqlCommand cmdCheck = conn.CreateCommand();
                    cmdCheck.Transaction = tran;
                    cmdCheck.CommandText = "SELECT AvailableQuantity FROM Books WHERE BookID = @id";
                    cmdCheck.Parameters.AddWithValue("@id", bookId);
                    object obj = cmdCheck.ExecuteScalar();
                    if (obj == null)
                    {
                        tran.Rollback();
                        MessageBox.Show("Selected book no longer exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int avail = Convert.ToInt32(obj);
                    if (avail <= 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("This book is currently unavailable.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadAvailableBooks();
                        return;
                    }

                    using SqlCommand cmdInsert = conn.CreateCommand();
                    cmdInsert.Transaction = tran;
                    cmdInsert.CommandText = "INSERT INTO BookIssues (BookID, MemberID, IssueDate, DueDate) VALUES (@bookId, @memberId, @issueDate, @dueDate)";
                    cmdInsert.Parameters.AddWithValue("@bookId", bookId);
                    cmdInsert.Parameters.AddWithValue("@memberId", memberId);
                    cmdInsert.Parameters.AddWithValue("@issueDate", issueDate);
                    cmdInsert.Parameters.AddWithValue("@dueDate", dueDate);
                    cmdInsert.ExecuteNonQuery();

                    using SqlCommand cmdUpdate = conn.CreateCommand();
                    cmdUpdate.Transaction = tran;
                    cmdUpdate.CommandText = "UPDATE Books SET AvailableQuantity = AvailableQuantity - 1 WHERE BookID = @id";
                    cmdUpdate.Parameters.AddWithValue("@id", bookId);
                    cmdUpdate.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Book issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadAvailableBooks();
                    LoadIssues();
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    MessageBox.Show("Failed to issue book: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
