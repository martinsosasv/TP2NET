namespace UI.Desktop
{
    partial class frmDocenteCursoAgregar
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbxCursos = new System.Windows.Forms.ComboBox();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.cbxDocentes = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblIdCurso = new System.Windows.Forms.Label();
            this.lblIdDocente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 211);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(66, 28);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(35, 211);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(69, 28);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbxCursos
            // 
            this.cbxCursos.FormattingEnabled = true;
            this.cbxCursos.Location = new System.Drawing.Point(128, 83);
            this.cbxCursos.Name = "cbxCursos";
            this.cbxCursos.Size = new System.Drawing.Size(100, 21);
            this.cbxCursos.TabIndex = 13;
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(128, 145);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(100, 21);
            this.cbxRoles.TabIndex = 12;
            // 
            // cbxDocentes
            // 
            this.cbxDocentes.FormattingEnabled = true;
            this.cbxDocentes.Location = new System.Drawing.Point(128, 21);
            this.cbxDocentes.Name = "cbxDocentes";
            this.cbxDocentes.Size = new System.Drawing.Size(100, 21);
            this.cbxDocentes.TabIndex = 11;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(81, 148);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 10;
            this.lblRol.Text = "Rol";
            // 
            // lblIdCurso
            // 
            this.lblIdCurso.AutoSize = true;
            this.lblIdCurso.Location = new System.Drawing.Point(70, 86);
            this.lblIdCurso.Name = "lblIdCurso";
            this.lblIdCurso.Size = new System.Drawing.Size(34, 13);
            this.lblIdCurso.TabIndex = 9;
            this.lblIdCurso.Text = "Curso";
            // 
            // lblIdDocente
            // 
            this.lblIdDocente.AutoSize = true;
            this.lblIdDocente.Location = new System.Drawing.Point(56, 24);
            this.lblIdDocente.Name = "lblIdDocente";
            this.lblIdDocente.Size = new System.Drawing.Size(48, 13);
            this.lblIdDocente.TabIndex = 8;
            this.lblIdDocente.Text = "Docente";
            // 
            // frmDocenteCursoAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbxCursos);
            this.Controls.Add(this.cbxRoles);
            this.Controls.Add(this.cbxDocentes);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblIdCurso);
            this.Controls.Add(this.lblIdDocente);
            this.Name = "frmDocenteCursoAgregar";
            this.Text = "Asignar Docente a Curso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbxCursos;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.ComboBox cbxDocentes;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblIdCurso;
        private System.Windows.Forms.Label lblIdDocente;
    }
}