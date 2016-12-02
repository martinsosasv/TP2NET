namespace UI.Desktop
{
    partial class frmAlumnoInscriptoACurso
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
            this.dgvAlumnosInscriptos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscriptos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlumnosInscriptos
            // 
            this.dgvAlumnosInscriptos.AllowDrop = true;
            this.dgvAlumnosInscriptos.AllowUserToAddRows = false;
            this.dgvAlumnosInscriptos.AllowUserToDeleteRows = false;
            this.dgvAlumnosInscriptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosInscriptos.Location = new System.Drawing.Point(12, 12);
            this.dgvAlumnosInscriptos.Name = "dgvAlumnosInscriptos";
            this.dgvAlumnosInscriptos.Size = new System.Drawing.Size(584, 271);
            this.dgvAlumnosInscriptos.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAlumnoInscriptoACurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvAlumnosInscriptos);
            this.Name = "frmAlumnoInscriptoACurso";
            this.Text = "Detalle del Curso";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscriptos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlumnosInscriptos;
        private System.Windows.Forms.Button button1;
    }
}