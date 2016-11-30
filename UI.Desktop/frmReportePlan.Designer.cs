namespace UI.Desktop
{
    partial class frmReportePlan
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
            this.lblReportePlanes = new System.Windows.Forms.Label();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportePlanes
            // 
            this.lblReportePlanes.AutoSize = true;
            this.lblReportePlanes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportePlanes.Location = new System.Drawing.Point(222, 9);
            this.lblReportePlanes.Name = "lblReportePlanes";
            this.lblReportePlanes.Size = new System.Drawing.Size(153, 24);
            this.lblReportePlanes.TabIndex = 0;
            this.lblReportePlanes.Text = "Reporte Planes";
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Location = new System.Drawing.Point(12, 50);
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.Size = new System.Drawing.Size(577, 233);
            this.dgvPlanes.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(250, 303);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(99, 36);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmReportePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 351);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvPlanes);
            this.Controls.Add(this.lblReportePlanes);
            this.Name = "frmReportePlan";
            this.Text = "frmReportePlan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReportePlanes;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Button btnVolver;
    }
}