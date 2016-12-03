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
            this.button1 = new System.Windows.Forms.Button();
            this.dgvAlumnosDelCurso = new System.Windows.Forms.DataGridView();
            this.btnEditarNota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosDelCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvAlumnosDelCurso
            // 
            this.dgvAlumnosDelCurso.AllowUserToAddRows = false;
            this.dgvAlumnosDelCurso.AllowUserToDeleteRows = false;
            this.dgvAlumnosDelCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosDelCurso.Location = new System.Drawing.Point(12, 12);
            this.dgvAlumnosDelCurso.MultiSelect = false;
            this.dgvAlumnosDelCurso.Name = "dgvAlumnosDelCurso";
            this.dgvAlumnosDelCurso.ReadOnly = true;
            this.dgvAlumnosDelCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnosDelCurso.Size = new System.Drawing.Size(584, 268);
            this.dgvAlumnosDelCurso.TabIndex = 5;
            // 
            // btnEditarNota
            // 
            this.btnEditarNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarNota.Location = new System.Drawing.Point(109, 298);
            this.btnEditarNota.Name = "btnEditarNota";
            this.btnEditarNota.Size = new System.Drawing.Size(185, 32);
            this.btnEditarNota.TabIndex = 0;
            this.btnEditarNota.Text = "Editar Nota";
            this.btnEditarNota.UseVisualStyleBackColor = true;
            this.btnEditarNota.Click += new System.EventHandler(this.btnEditarNota_Click);
            // 
            // frmAlumnoInscriptoACurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 342);
            this.Controls.Add(this.btnEditarNota);
            this.Controls.Add(this.dgvAlumnosDelCurso);
            this.Controls.Add(this.button1);
            this.Name = "frmAlumnoInscriptoACurso";
            this.Text = "Detalle del Curso";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosDelCurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvAlumnosDelCurso;
        private System.Windows.Forms.Button btnEditarNota;
    }
}