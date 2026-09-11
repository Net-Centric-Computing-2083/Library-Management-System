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
    public partial class CategoryForm : Form
    {
        private int? selectedCategoryId = null;

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCategories.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                if (row.Cells["CategoryID"].Value != null)
                {
                    selectedCategoryId = Convert.ToInt32(row.Cells["CategoryID"].Value);
                    txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? string.Empty;
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            selectedCategoryId = null;
            txtCategoryName.Clear();
            dgvCategories.ClearSelection();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Category name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand check = conn.CreateCommand();
                check.CommandText = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @name";
                check.Parameters.AddWithValue("@name", name);
                int exists = Convert.ToInt32(check.ExecuteScalar());
                if (exists > 0)
                {
                    MessageBox.Show("Category name already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Categories (CategoryName) VALUES (@name)";
                cmd.Parameters.AddWithValue("@name", name);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Category added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add category: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedCategoryId == null)
            {
                MessageBox.Show("Please select a category to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Category name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand check = conn.CreateCommand();
                check.CommandText = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @name AND CategoryID <> @id";
                check.Parameters.AddWithValue("@name", name);
                check.Parameters.AddWithValue("@id", selectedCategoryId.Value);
                int exists = Convert.ToInt32(check.ExecuteScalar());
                if (exists > 0)
                {
                    MessageBox.Show("Another category with the same name exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Categories SET CategoryName = @name WHERE CategoryID = @id";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", selectedCategoryId.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Category updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update category: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedCategoryId == null)
            {
                MessageBox.Show("Please select a category to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();
                using SqlCommand check = conn.CreateCommand();
                check.CommandText = "SELECT COUNT(*) FROM Books WHERE CategoryID = @id";
                check.Parameters.AddWithValue("@id", selectedCategoryId.Value);
                int count = Convert.ToInt32(check.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("This category cannot be deleted because books are associated with this category.", "Delete Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Categories WHERE CategoryID = @id";
                cmd.Parameters.AddWithValue("@id", selectedCategoryId.Value);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Category deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, EventArgs.Empty);
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete category: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
