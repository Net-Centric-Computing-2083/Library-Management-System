using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        // Added to fix the Designer error:
        // CS0103: The name 'button2_Click' does not exist in the current context
        private void button2_Click(object sender, EventArgs e)
        {
            // Open Members form
            MemberForm form = new MemberForm();
            form.ShowDialog();
        }

        private void btMembers_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm();
            form.ShowDialog();
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            AuthorForm form = new AuthorForm();
            form.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoryForm form = new CategoryForm();
            form.ShowDialog();
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            IssueBookForm form = new IssueBookForm();
            form.ShowDialog();
        }

        private void btnreturnbook_Click(object sender, EventArgs e)
        {
            ReturnBookForm form = new ReturnBookForm();
            form.ShowDialog();
        }

        private void btnFines_Click(object sender, EventArgs e)
        {
            FineForm form = new FineForm();
            form.ShowDialog();
        }

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            SearchBookForm form = new SearchBookForm();
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
