namespace LibraryManagementSystem.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb1LibraryManagemet = new Label();
            btnDashboard = new Button();
            btnBook = new Button();
            btnMember = new Button();
            btnLogout = new Button();
            sidebarPanel = new Panel();
            BtnSearchBook = new Button();
            btnFines = new Button();
            btnreturnbook = new Button();
            btnIssueBook = new Button();
            btnCategories = new Button();
            btnAuthors = new Button();
            sidebarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lb1LibraryManagemet
            // 
            lb1LibraryManagemet.AutoSize = true;
            lb1LibraryManagemet.ForeColor = SystemColors.ActiveCaption;
            lb1LibraryManagemet.Location = new Point(23, 18);
            lb1LibraryManagemet.Name = "lb1LibraryManagemet";
            lb1LibraryManagemet.Size = new Size(237, 25);
            lb1LibraryManagemet.TabIndex = 0;
            lb1LibraryManagemet.Text = "Library Management System";
            lb1LibraryManagemet.UseWaitCursor = true;
            lb1LibraryManagemet.Click += label1_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(3, 59);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(188, 34);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.UseWaitCursor = true;
            btnDashboard.Click += button1_Click;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(23, 119);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(112, 34);
            btnBook.TabIndex = 2;
            btnBook.Text = "Books";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.UseWaitCursor = true;
            btnBook.Click += btnBook_Click;
            // 
            // btnMember
            // 
            btnMember.Location = new Point(23, 248);
            btnMember.Name = "btnMember";
            btnMember.Size = new Size(112, 34);
            btnMember.TabIndex = 3;
            btnMember.Text = "Members";
            btnMember.UseVisualStyleBackColor = true;
            btnMember.UseWaitCursor = true;
            btnMember.Click += button2_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 603);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.UseWaitCursor = true;
            btnLogout.Click += button4_Click;
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(30, 41, 59);
            sidebarPanel.Controls.Add(BtnSearchBook);
            sidebarPanel.Controls.Add(btnFines);
            sidebarPanel.Controls.Add(btnreturnbook);
            sidebarPanel.Controls.Add(btnIssueBook);
            sidebarPanel.Controls.Add(btnCategories);
            sidebarPanel.Controls.Add(btnAuthors);
            sidebarPanel.Controls.Add(btnDashboard);
            sidebarPanel.Controls.Add(lb1LibraryManagemet);
            sidebarPanel.Controls.Add(btnLogout);
            sidebarPanel.Controls.Add(btnBook);
            sidebarPanel.Controls.Add(btnMember);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(321, 717);
            sidebarPanel.TabIndex = 6;
            sidebarPanel.UseWaitCursor = true;
            // 
            // BtnSearchBook
            // 
            BtnSearchBook.Location = new Point(21, 471);
            BtnSearchBook.Name = "BtnSearchBook";
            BtnSearchBook.Size = new Size(145, 34);
            BtnSearchBook.TabIndex = 11;
            BtnSearchBook.Text = "SearchBooks";
            BtnSearchBook.UseVisualStyleBackColor = true;
            BtnSearchBook.UseWaitCursor = true;
            BtnSearchBook.Click += BtnSearchBook_Click;
            // 
            // btnFines
            // 
            btnFines.Location = new Point(21, 417);
            btnFines.Name = "btnFines";
            btnFines.Size = new Size(112, 34);
            btnFines.TabIndex = 10;
            btnFines.Text = "Fines";
            btnFines.UseVisualStyleBackColor = true;
            btnFines.UseWaitCursor = true;
            btnFines.Click += btnFines_Click;
            // 
            // btnreturnbook
            // 
            btnreturnbook.Location = new Point(23, 367);
            btnreturnbook.Name = "btnreturnbook";
            btnreturnbook.Size = new Size(112, 34);
            btnreturnbook.TabIndex = 9;
            btnreturnbook.Text = "Return Book";
            btnreturnbook.UseVisualStyleBackColor = true;
            btnreturnbook.UseWaitCursor = true;
            btnreturnbook.Click += btnreturnbook_Click;
            // 
            // btnIssueBook
            // 
            btnIssueBook.Location = new Point(21, 316);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(112, 34);
            btnIssueBook.TabIndex = 8;
            btnIssueBook.Text = "Issue Book";
            btnIssueBook.UseVisualStyleBackColor = true;
            btnIssueBook.UseWaitCursor = true;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // btnCategories
            // 
            btnCategories.Location = new Point(23, 208);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(112, 34);
            btnCategories.TabIndex = 7;
            btnCategories.Text = "Categories";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.UseWaitCursor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnAuthors
            // 
            btnAuthors.Location = new Point(23, 168);
            btnAuthors.Name = "btnAuthors";
            btnAuthors.Size = new Size(112, 34);
            btnAuthors.TabIndex = 6;
            btnAuthors.Text = "Authors";
            btnAuthors.UseVisualStyleBackColor = true;
            btnAuthors.UseWaitCursor = true;
            btnAuthors.Click += btnAuthors_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 717);
            Controls.Add(sidebarPanel);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System";
            UseWaitCursor = true;
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lb1LibraryManagemet;
        private Button btnDashboard;
        private Button btnBook;
        private Button btnMember;
        private Button btnLogout;
        private Panel sidebarPanel;
        private Button BtnSearchBook;
        private Button btnFines;
        private Button btnreturnbook;
        private Button btnIssueBook;
        private Button btnCategories;
        private Button btnAuthors;
    }
}