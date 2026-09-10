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
    public partial class AuthorForm : Form
    {
        private int? selectedAuthorId = null;

        public AuthorForm()
        {
            InitializeComponent();
        }

        private void AuthorForm_Load(object sender, EventArgs e)
        {
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT AuthorID, AuthorName, Email, Phone FROM Authors ORDER BY AuthorName";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvAuthors.DataSource = dt;
                // make sure AuthorID column is not editable
                if (dgvAuthors.Columns["AuthorID"] != null)
                    dgvAuthors.Columns["AuthorID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load authors: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAuthors_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAuthors.Rows[e.RowIndex];
                if (row.Cells["AuthorID"].Value != null)
                {
                    selectedAuthorId = Convert.ToInt32(row.Cells["AuthorID"].Value);
                    txtAuthorName.Text = row.Cells["AuthorName"].Value?.ToString() ?? string.Empty;
                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                    txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            selectedAuthorId = null;
            txtAuthorName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            dgvAuthors.ClearSelection();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string name = txtAuthorName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Author name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Authors (AuthorName, Email, Phone) VALUES (@name, @email, @phone)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Author added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadAuthors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add author: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedAuthorId == null)
            {
                MessageBox.Show("Please select an author to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtAuthorName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Author name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Authors SET AuthorName = @name, Email = @email, Phone = @phone WHERE AuthorID = @id";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@id", selectedAuthorId.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Author updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadAuthors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update author: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedAuthorId == null)
            {
                MessageBox.Show("Please select an author to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this author?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand checkCmd = conn.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM Books WHERE AuthorID = @id";
                checkCmd.Parameters.AddWithValue("@id", selectedAuthorId.Value);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("This author cannot be deleted because books are associated with this author.", "Delete Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Authors WHERE AuthorID = @id";
                cmd.Parameters.AddWithValue("@id", selectedAuthorId.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Author deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadAuthors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete author: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
