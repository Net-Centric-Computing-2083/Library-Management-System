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
    public partial class FineForm : Form
    {
        public FineForm()
        {
            InitializeComponent();
        }

        private void FineForm_Load(object sender, EventArgs e)
        {
            LoadFines();
        }

        private void LoadFines()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT f.FineID, f.ReturnID, i.IssueID, b.Title AS BookTitle, m.FullName AS MemberName, i.IssueDate, i.DueDate, r.ReturnDate, f.FineAmount, f.PaidStatus
FROM Fines f
JOIN Returns r ON f.ReturnID = r.ReturnID
JOIN BookIssues i ON r.IssueID = i.IssueID
JOIN Books b ON i.BookID = b.BookID
JOIN Members m ON i.MemberID = m.MemberID
ORDER BY f.FineID DESC";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvFines.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load fines: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedFineId()
        {
            if (dgvFines.SelectedRows.Count == 0) return null;
            var row = dgvFines.SelectedRows[0];
            if (row.Cells["FineID"].Value == null) return null;
            return Convert.ToInt32(row.Cells["FineID"].Value);
        }

        private void btnMarkPaid_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedFineId();
            if (id == null)
            {
                MessageBox.Show("Please select a fine to mark paid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdatePaidStatus(id.Value, "Paid");
        }

        private void btnMarkUnpaid_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedFineId();
            if (id == null)
            {
                MessageBox.Show("Please select a fine to mark unpaid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdatePaidStatus(id.Value, "Unpaid");
        }

        private void UpdatePaidStatus(int fineId, string status)
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Fines SET PaidStatus = @status WHERE FineID = @id";
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", fineId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Payment status updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFines();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update payment status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadFines();
        }
    }
}
