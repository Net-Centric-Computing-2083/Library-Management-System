namespace LibraryManagementSystem.Forms
{
    partial class FineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView dgvFines;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Button btnMarkUnpaid;
        private System.Windows.Forms.Button btnRefresh;

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
            this.components = new System.ComponentModel.Container();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgvFines = new System.Windows.Forms.DataGridView();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.btnMarkUnpaid = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(16, 16);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(63, 25);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Fines";
            // 
            // dgvFines
            // 
            this.dgvFines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFines.Location = new System.Drawing.Point(16, 64);
            this.dgvFines.MultiSelect = false;
            this.dgvFines.Name = "dgvFines";
            this.dgvFines.ReadOnly = true;
            this.dgvFines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFines.Size = new System.Drawing.Size(960, 360);
            this.dgvFines.TabIndex = 1;
            // 
            // btnMarkPaid
            // 
            this.btnMarkPaid.Location = new System.Drawing.Point(16, 436);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new System.Drawing.Size(88, 34);
            this.btnMarkPaid.TabIndex = 2;
            this.btnMarkPaid.Text = "Mark Paid";
            this.btnMarkPaid.UseVisualStyleBackColor = true;
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            // 
            // btnMarkUnpaid
            // 
            this.btnMarkUnpaid.Location = new System.Drawing.Point(120, 436);
            this.btnMarkUnpaid.Name = "btnMarkUnpaid";
            this.btnMarkUnpaid.Size = new System.Drawing.Size(100, 34);
            this.btnMarkUnpaid.TabIndex = 3;
            this.btnMarkUnpaid.Text = "Mark Unpaid";
            this.btnMarkUnpaid.UseVisualStyleBackColor = true;
            this.btnMarkUnpaid.Click += new System.EventHandler(this.btnMarkUnpaid_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(236, 436);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FineForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvFines);
            this.Controls.Add(this.btnMarkPaid);
            this.Controls.Add(this.btnMarkUnpaid);
            this.Controls.Add(this.btnRefresh);
            this.Name = "FineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fine Management";
            this.Load += new System.EventHandler(this.FineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}