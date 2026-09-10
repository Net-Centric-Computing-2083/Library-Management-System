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
    public partial class ReturnBookForm : Form
    {
        public ReturnBookForm()
        {
            InitializeComponent();
        }

        private void ReturnBookForm_Load(object sender, EventArgs e)
        {
            dtpReturnDate.Value = DateTime.Now.Date;
            LoadUnreturnedIssues();
            LoadReturns();
        }

        private void LoadUnreturnedIssues()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT i.IssueID, b.BookID, b.Title AS BookTitle, m.MemberID, m.FullName AS MemberName, i.IssueDate, i.DueDate,
    CONCAT('ID:', i.IssueID, ' - ', b.Title, ' - ', m.FullName) AS DisplayText
FROM BookIssues i
JOIN Books b ON i.BookID = b.BookID
JOIN Members m ON i.MemberID = m.MemberID
LEFT JOIN Returns r ON r.IssueID = i.IssueID
WHERE r.ReturnID IS NULL
ORDER BY i.IssueDate DESC";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbIssue.DisplayMember = "DisplayText";
                cmbIssue.ValueMember = "IssueID";
                cmbIssue.DataSource = dt;
                cmbIssue.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load issues: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReturns()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT r.ReturnID, i.IssueID, b.Title AS BookTitle, m.FullName AS MemberName, i.IssueDate, i.DueDate, r.ReturnDate
FROM Returns r
JOIN BookIssues i ON r.IssueID = i.IssueID
JOIN Books b ON i.BookID = b.BookID
JOIN Members m ON i.MemberID = m.MemberID
ORDER BY r.ReturnDate DESC";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReturns.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load returns: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            cmbIssue.SelectedIndex = -1;
            dtpReturnDate.Value = DateTime.Now.Date;
        }

        private void btnReturn_Click(object? sender, EventArgs e)
        {
            if (cmbIssue.SelectedValue == null || !int.TryParse(cmbIssue.SelectedValue.ToString(), out int issueId))
            {
                MessageBox.Show("Please select an issue to return.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime returnDate = dtpReturnDate.Value.Date;

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    using SqlCommand cmdCheck = conn.CreateCommand();
                    cmdCheck.Transaction = tran;
                    cmdCheck.CommandText = "SELECT COUNT(*) FROM Returns WHERE IssueID = @issueId";
                    cmdCheck.Parameters.AddWithValue("@issueId", issueId);
                    int already = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (already > 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("This issue has already been returned.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadUnreturnedIssues();
                        return;
                    }

                    // get issue details
                    using SqlCommand cmdGet = conn.CreateCommand();
                    cmdGet.Transaction = tran;
                    cmdGet.CommandText = "SELECT BookID, IssueDate, DueDate FROM BookIssues WHERE IssueID = @id";
                    cmdGet.Parameters.AddWithValue("@id", issueId);
                    using SqlDataReader reader = cmdGet.ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                        tran.Rollback();
                        MessageBox.Show("Selected issue not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int bookId = reader.GetInt32(0);
                    DateTime issueDate = reader.GetDateTime(1);
                    DateTime dueDate = reader.GetDateTime(2);
                    reader.Close();

                    if (returnDate < issueDate)
                    {
                        tran.Rollback();
                        MessageBox.Show("Return date cannot be earlier than issue date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // insert return
                    using SqlCommand cmdInsert = conn.CreateCommand();
                    cmdInsert.Transaction = tran;
                    cmdInsert.CommandText = "INSERT INTO Returns (IssueID, ReturnDate) VALUES (@issueId, @returnDate); SELECT SCOPE_IDENTITY();";
                    cmdInsert.Parameters.AddWithValue("@issueId", issueId);
                    cmdInsert.Parameters.AddWithValue("@returnDate", returnDate);
                    object obj = cmdInsert.ExecuteScalar();
                    int returnId = Convert.ToInt32(Convert.ToDecimal(obj));

                    // update book availability
                    using SqlCommand cmdUpdate = conn.CreateCommand();
                    cmdUpdate.Transaction = tran;
                    cmdUpdate.CommandText = "UPDATE Books SET AvailableQuantity = AvailableQuantity + 1 WHERE BookID = @bookId";
                    cmdUpdate.Parameters.AddWithValue("@bookId", bookId);
                    cmdUpdate.ExecuteNonQuery();

                    // calculate fine
                    int overdueDays = 0;
                    if (returnDate > dueDate)
                        overdueDays = (returnDate - dueDate).Days;
                    decimal fineAmount = overdueDays * 10m;

                    using SqlCommand cmdFine = conn.CreateCommand();
                    cmdFine.Transaction = tran;
                    cmdFine.CommandText = "INSERT INTO Fines (ReturnID, FineAmount, PaidStatus) VALUES (@returnId, @amount, @status)";
                    cmdFine.Parameters.AddWithValue("@returnId", returnId);
                    cmdFine.Parameters.AddWithValue("@amount", fineAmount);
                    cmdFine.Parameters.AddWithValue("@status", fineAmount > 0 ? "Unpaid" : "Paid");
                    cmdFine.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show($"Book returned successfully. Fine: Rs.{fineAmount:0.00}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadUnreturnedIssues();
                    LoadReturns();
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    MessageBox.Show("Failed to process return: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
