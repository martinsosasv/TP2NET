namespace UI.Desktop
{
    partial class frmReporteCurso
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
            this.lblReporte = new System.Windows.Forms.Label();
            this.dgvReporteCurso = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReporte
            // 
            this.lblReporte.AutoSize = true;
            this.lblReporte.Location = new System.Drawing.Point(197, 9);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(74, 13);
            this.lblReporte.TabIndex = 0;
            this.lblReporte.Text = "Reporte curso";
            // 
            // dgvReporteCurso
            // 
            this.dgvReporteCurso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporteCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteCurso.Location = new System.Drawing.Point(12, 35);
            this.dgvReporteCurso.Name = "dgvReporteCurso";
            this.dgvReporteCurso.Size = new System.Drawing.Size(464, 212);
            this.dgvReporteCurso.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReporteCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 301);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvReporteCurso);
            this.Controls.Add(this.lblReporte);
            this.Name = "frmReporteCurso";
            this.Text = "Reporte curso";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.DataGridView dgvReporteCurso;
        private System.Windows.Forms.Button button1;
    }
}