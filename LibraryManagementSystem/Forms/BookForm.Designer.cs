namespace LibraryManagementSystem.Forms
{
    partial class BookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lb1BookManagement;
        private Label lb1Title;
        private Label lblISBN;
        private Label lblAuthor;
        private Label lblCategory;
        private Label lblPublisher;
        private Label lblPublicationYear;
        private Label lblQuantity;
        private Label lblAvailableQuantity;
        private TextBox txtTitle;
        private TextBox txtISBN;
        private TextBox txtPublisher;
        private TextBox txtPublicationYear;
        private TextBox txtQuantity;
        private TextBox txtAvailableQuantity;
        private ComboBox cmbAuthor;
        private ComboBox cmbCategory;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvBooks;
        private Panel panelLeft;
        private Panel panelRight;

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
            lb1BookManagement = new Label();
            lb1Title = new Label();
            lblISBN = new Label();
            lblAuthor = new Label();
            lblCategory = new Label();
            lblPublisher = new Label();
            lblPublicationYear = new Label();
            lblQuantity = new Label();
            lblAvailableQuantity = new Label();
            txtTitle = new TextBox();
            txtISBN = new TextBox();
            txtPublisher = new TextBox();
            txtPublicationYear = new TextBox();
            txtQuantity = new TextBox();
            txtAvailableQuantity = new TextBox();
            cmbAuthor = new ComboBox();
            cmbCategory = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvBooks = new DataGridView();
            panelLeft = new Panel();
            panelRight = new Panel();
            SuspendLayout();
            // 
            // lb1BookManagement
            // 
            lb1BookManagement.AutoSize = true;
            lb1BookManagement.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lb1BookManagement.Location = new Point(24, 16);
            lb1BookManagement.Name = "lb1BookManagement";
            lb1BookManagement.Size = new Size(194, 32);
            lb1BookManagement.TabIndex = 0;
            lb1BookManagement.Text = "Book Management";
            lb1BookManagement.Click += label1_Click;
            // 
            // panelLeft
            // 
            panelLeft.BorderStyle = BorderStyle.FixedSingle;
            panelLeft.Location = new Point(12, 60);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(420, 572);
            panelLeft.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.BorderStyle = BorderStyle.FixedSingle;
            panelRight.Location = new Point(444, 60);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(622, 572);
            panelRight.TabIndex = 2;
            // 
            // lb1Title
            // 
            lb1Title.AutoSize = true;
            lb1Title.Location = new Point(16, 16);
            lb1Title.Name = "lb1Title";
            lb1Title.Size = new Size(38, 20);
            lb1Title.TabIndex = 10;
            lb1Title.Text = "Title";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(16, 68);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(42, 20);
            lblISBN.TabIndex = 11;
            lblISBN.Text = "ISBN";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(16, 120);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(53, 20);
            lblAuthor.TabIndex = 12;
            lblAuthor.Text = "Author";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(16, 172);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(66, 20);
            lblCategory.TabIndex = 13;
            lblCategory.Text = "Category";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Location = new Point(16, 224);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(68, 20);
            lblPublisher.TabIndex = 14;
            lblPublisher.Text = "Publisher";
            // 
            // lblPublicationYear
            // 
            lblPublicationYear.AutoSize = true;
            lblPublicationYear.Location = new Point(16, 276);
            lblPublicationYear.Name = "lblPublicationYear";
            lblPublicationYear.Size = new Size(111, 20);
            lblPublicationYear.TabIndex = 15;
            lblPublicationYear.Text = "Publication Year";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(16, 328);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(62, 20);
            lblQuantity.TabIndex = 16;
            lblQuantity.Text = "Quantity";
            // 
            // lblAvailableQuantity
            // 
            lblAvailableQuantity.AutoSize = true;
            lblAvailableQuantity.Location = new Point(16, 380);
            lblAvailableQuantity.Name = "lblAvailableQuantity";
            lblAvailableQuantity.Size = new Size(130, 20);
            lblAvailableQuantity.TabIndex = 17;
            lblAvailableQuantity.Text = "Available Quantity";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(16, 39);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(376, 27);
            txtTitle.TabIndex = 0;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(16, 91);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(376, 27);
            txtISBN.TabIndex = 1;
            // 
            // cmbAuthor
            // 
            cmbAuthor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuthor.FormattingEnabled = true;
            cmbAuthor.Location = new Point(16, 143);
            cmbAuthor.Name = "cmbAuthor";
            cmbAuthor.Size = new Size(376, 28);
            cmbAuthor.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(16, 195);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(376, 28);
            cmbCategory.TabIndex = 3;
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(16, 247);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(376, 27);
            txtPublisher.TabIndex = 4;
            // 
            // txtPublicationYear
            // 
            txtPublicationYear.Location = new Point(16, 299);
            txtPublicationYear.Name = "txtPublicationYear";
            txtPublicationYear.Size = new Size(376, 27);
            txtPublicationYear.TabIndex = 5;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(16, 351);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(176, 27);
            txtQuantity.TabIndex = 6;
            // 
            // txtAvailableQuantity
            // 
            txtAvailableQuantity.Location = new Point(216, 351);
            txtAvailableQuantity.Name = "txtAvailableQuantity";
            txtAvailableQuantity.ReadOnly = true;
            txtAvailableQuantity.Size = new Size(176, 27);
            txtAvailableQuantity.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(16, 400);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(120, 400);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(88, 34);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(224, 400);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 34);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(320, 400);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(72, 34);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.Location = new Point(16, 16);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(586, 536);
            dgvBooks.TabIndex = 0;
            // 
            // add controls to panels
            // 
            panelLeft.Controls.Add(lb1Title);
            panelLeft.Controls.Add(txtTitle);
            panelLeft.Controls.Add(lblISBN);
            panelLeft.Controls.Add(txtISBN);
            panelLeft.Controls.Add(lblAuthor);
            panelLeft.Controls.Add(cmbAuthor);
            panelLeft.Controls.Add(lblCategory);
            panelLeft.Controls.Add(cmbCategory);
            panelLeft.Controls.Add(lblPublisher);
            panelLeft.Controls.Add(txtPublisher);
            panelLeft.Controls.Add(lblPublicationYear);
            panelLeft.Controls.Add(txtPublicationYear);
            panelLeft.Controls.Add(lblQuantity);
            panelLeft.Controls.Add(txtQuantity);
            panelLeft.Controls.Add(lblAvailableQuantity);
            panelLeft.Controls.Add(txtAvailableQuantity);
            panelLeft.Controls.Add(btnAdd);
            panelLeft.Controls.Add(btnUpdate);
            panelLeft.Controls.Add(btnDelete);
            panelLeft.Controls.Add(btnClear);
            panelRight.Controls.Add(dgvBooks);
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 644);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(lb1BookManagement);
            Name = "BookForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Management";
            this.Load += BookForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

    }
}