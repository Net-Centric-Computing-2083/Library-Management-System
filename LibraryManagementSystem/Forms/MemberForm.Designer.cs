namespace LibraryManagementSystem.Forms
{
    partial class MemberForm
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
            lblFullName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblJoinDate = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            dtpJoinDate = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvMembers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvMembers)).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.Location = new Point(16, 16);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(190, 32);
            lbTitle.Text = "Member Management";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(16, 64);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(73, 20);
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(16, 87);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(360, 27);
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(16, 124);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(16, 147);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 27);
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(16, 184);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(49, 20);
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(16, 207);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 27);
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(16, 244);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 20);
            lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(16, 267);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(360, 27);
            // 
            // lblJoinDate
            // 
            lblJoinDate.AutoSize = true;
            lblJoinDate.Location = new Point(16, 304);
            lblJoinDate.Name = "lblJoinDate";
            lblJoinDate.Size = new Size(70, 20);
            lblJoinDate.Text = "Join Date";
            // 
            // dtpJoinDate
            // 
            dtpJoinDate.Format = DateTimePickerFormat.Short;
            dtpJoinDate.Location = new Point(16, 327);
            dtpJoinDate.Name = "dtpJoinDate";
            dtpJoinDate.Size = new Size(200, 27);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(16, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 34);
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(116, 370);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(88, 34);
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(216, 370);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 34);
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(312, 370);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 34);
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvMembers
            // 
            dgvMembers.Location = new Point(400, 16);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.Size = new Size(560, 450);
            dgvMembers.ReadOnly = true;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.MultiSelect = false;
            dgvMembers.CellClick += dgvMembers_CellClick;
            // 
            // MemberForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 500);
            Controls.Add(lbTitle);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblJoinDate);
            Controls.Add(dtpJoinDate);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvMembers);
            Name = "MemberForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Management";
            Load += MemberForm_Load;
            ((System.ComponentModel.ISupportInitialize)(dgvMembers)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblJoinDate;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private DateTimePicker dtpJoinDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvMembers;
    }
}