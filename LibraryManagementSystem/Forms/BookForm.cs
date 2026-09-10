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
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            // Load authors and categories for the combo boxes
            LoadAuthors();
            LoadCategories();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // reserved for title label click
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Add functionality not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Update functionality not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Delete functionality not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            try
            {
                // clear fields
                txtTitle.Clear();
                txtISBN.Clear();
                cmbAuthor.SelectedIndex = -1;
                cmbCategory.SelectedIndex = -1;
                txtPublisher.Clear();
                txtPublicationYear.Clear();
                txtQuantity.Clear();
                txtAvailableQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuthors()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT AuthorID, AuthorName FROM Authors ORDER BY AuthorName";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbAuthor.DisplayMember = "AuthorName";
                cmbAuthor.ValueMember = "AuthorID";
                cmbAuthor.DataSource = dt;
                cmbAuthor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load authors: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.DataSource = dt;
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
