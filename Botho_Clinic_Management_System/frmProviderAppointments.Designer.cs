namespace Botho_Clinic_Management_System
{
    partial class frmProviderAppointments
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProviderAppointments;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProviderAppointments = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProviderAppointments)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvProviderAppointments
            // 
            this.dgvProviderAppointments.AllowUserToAddRows = false;
            this.dgvProviderAppointments.AllowUserToDeleteRows = false;
            this.dgvProviderAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProviderAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvProviderAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProviderAppointments.Location = new System.Drawing.Point(20, 70);
            this.dgvProviderAppointments.MultiSelect = false;
            this.dgvProviderAppointments.Name = "dgvProviderAppointments";
            this.dgvProviderAppointments.ReadOnly = true;
            this.dgvProviderAppointments.RowHeadersVisible = false;
            this.dgvProviderAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProviderAppointments.Size = new System.Drawing.Size(760, 320);
            this.dgvProviderAppointments.TabIndex = 0;

            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(20, 410);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(120, 35);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(160, 410);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 35);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(660, 410);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(20, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(259, 25);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "📅 Provider Appointments";

            // 
            // frmProviderAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvProviderAppointments);
            this.Name = "frmProviderAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Provider Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProviderAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
