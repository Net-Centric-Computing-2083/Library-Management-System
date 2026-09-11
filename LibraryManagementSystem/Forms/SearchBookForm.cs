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
    public partial class SearchBookForm : Form
    {
        public SearchBookForm()
        {
            InitializeComponent();
        }

        private void SearchBookForm_Load(object sender, EventArgs e)
        {
            cmbSearchBy.Items.Clear();
            cmbSearchBy.Items.AddRange(new string[] { "Title", "ISBN", "Author", "Category" });
            cmbSearchBy.SelectedIndex = 0;
            LoadAllBooks();
        }

        private void LoadAllBooks()
        {
            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT b.BookID, b.Title, b.ISBN, a.AuthorName, c.CategoryName, b.Publisher, b.PublicationYear, b.Quantity, b.AvailableQuantity
FROM Books b
JOIN Authors a ON b.AuthorID = a.AuthorID
JOIN Categories c ON b.CategoryID = c.CategoryID
ORDER BY b.Title";
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvSearchResults.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string searchBy = cmbSearchBy.SelectedItem?.ToString() ?? "Title";
            string text = txtSearch.Text.Trim();

            try
            {
                using SqlConnection conn = DatabaseConnection.GetConnection();
                using SqlCommand cmd = conn.CreateCommand();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT b.BookID, b.Title, b.ISBN, a.AuthorName, c.CategoryName, b.Publisher, b.PublicationYear, b.Quantity, b.AvailableQuantity");
                sb.AppendLine("FROM Books b");
                sb.AppendLine("JOIN Authors a ON b.AuthorID = a.AuthorID");
                sb.AppendLine("JOIN Categories c ON b.CategoryID = c.CategoryID");
                if (string.IsNullOrEmpty(text))
                {
                    sb.AppendLine("ORDER BY b.Title");
                }
                else
                {
                    sb.Append("WHERE ");
                    switch (searchBy)
                    {
                        case "Title":
                            sb.Append("b.Title LIKE @search ");
                            break;
                        case "ISBN":
                            sb.Append("b.ISBN LIKE @search ");
                            break;
                        case "Author":
                            sb.Append("a.AuthorName LIKE @search ");
                            break;
                        case "Category":
                            sb.Append("c.CategoryName LIKE @search ");
                            break;
                        default:
                            sb.Append("b.Title LIKE @search ");
                            break;
                    }
                    sb.AppendLine("ORDER BY b.Title");
                    cmd.Parameters.AddWithValue("@search", "%" + text + "%");
                }
                cmd.CommandText = sb.ToString();
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvSearchResults.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbSearchBy.SelectedIndex = 0;
            LoadAllBooks();
        }
    }
}
