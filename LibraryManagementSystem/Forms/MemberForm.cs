using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Data;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.Forms
{
    public partial class MemberForm : Form
    {
        private int? selectedMemberId = null;

        public MemberForm()
        {
            InitializeComponent();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadMembers();
            dtpJoinDate.Value = DateTime.Now.Date;
        }

        private void LoadMembers()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MemberID, FullName, Email, Phone, Address, JoinDate FROM Members ORDER BY FullName";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMembers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load members: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMembers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
                if (row.Cells["MemberID"].Value != null)
                {
                    selectedMemberId = Convert.ToInt32(row.Cells["MemberID"].Value);
                    txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? string.Empty;
                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                    txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
                    txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
                    if (DateTime.TryParse(row.Cells["JoinDate"].Value?.ToString(), out DateTime jd))
                        dtpJoinDate.Value = jd;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return true; // optional
            try
            {
                // simple regex for validation
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return true; // optional
            // allow digits, plus, spaces, hyphens; require 7-15 digits
            string digits = Regex.Replace(phone, "[^0-9]", "");
            return digits.Length >= 7 && digits.Length <= 15;
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            selectedMemberId = null;
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpJoinDate.Value = DateTime.Now.Date;
            dgvMembers.ClearSelection();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            DateTime joinDate = dtpJoinDate.Value.Date;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Please enter a valid phone number (7-15 digits).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Members (FullName, Email, Phone, Address, JoinDate) VALUES (@name, @email, @phone, @address, @joinDate)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                cmd.Parameters.AddWithValue("@joinDate", joinDate);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Member added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add member: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedMemberId == null)
            {
                MessageBox.Show("Please select a member to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            DateTime joinDate = dtpJoinDate.Value.Date;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Please enter a valid phone number (7-15 digits).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Members SET FullName = @name, Email = @email, Phone = @phone, Address = @address, JoinDate = @joinDate WHERE MemberID = @id";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                cmd.Parameters.AddWithValue("@joinDate", joinDate);
                cmd.Parameters.AddWithValue("@id", selectedMemberId.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Member updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update member: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedMemberId == null)
            {
                MessageBox.Show("Please select a member to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this member?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand check = conn.CreateCommand();
                check.CommandText = "SELECT COUNT(*) FROM BookIssues WHERE MemberID = @id";
                check.Parameters.AddWithValue("@id", selectedMemberId.Value);
                int count = Convert.ToInt32(check.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("This member cannot be deleted because issue records exist.", "Delete Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Members WHERE MemberID = @id";
                cmd.Parameters.AddWithValue("@id", selectedMemberId.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete member: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
