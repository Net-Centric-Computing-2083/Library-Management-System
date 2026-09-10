namespace LibraryManagementSystem.Forms
{
    partial class CategoryForm
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
            lbTitle = new Label();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvCategories = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvCategories)).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.Location = new Point(16, 16);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(195, 32);
            lbTitle.Text = "Category Management";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(16, 68);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(110, 20);
            lblCategoryName.Text = "Category Name";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(16, 91);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(360, 27);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(16, 140);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 34);
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(116, 140);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(88, 34);
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(216, 140);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 34);
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(312, 140);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 34);
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvCategories
            // 
            dgvCategories.Location = new Point(400, 16);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.Size = new Size(560, 450);
            dgvCategories.ReadOnly = true;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.MultiSelect = false;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // CategoryForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 500);
            Controls.Add(lbTitle);
            Controls.Add(lblCategoryName);
            Controls.Add(txtCategoryName);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvCategories);
            Name = "CategoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category Management";
            Load += CategoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)(dgvCategories)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lbTitle;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvCategories;

        #endregion
    }
}