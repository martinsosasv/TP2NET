namespace UI.Desktop
{
    partial class frmCursoAsignado
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
            this.dgvCursosAsignados = new System.Windows.Forms.DataGridView();
            this.Cancelar = new System.Windows.Forms.Button();
            this.btnVerAlumnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosAsignados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCursosAsignados
            // 
            this.dgvCursosAsignados.AllowUserToAddRows = false;
            this.dgvCursosAsignados.AllowUserToDeleteRows = false;
            this.dgvCursosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosAsignados.Location = new System.Drawing.Point(12, 12);
            this.dgvCursosAsignados.Name = "dgvCursosAsignados";
            this.dgvCursosAsignados.ReadOnly = true;
            this.dgvCursosAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursosAsignados.Size = new System.Drawing.Size(615, 215);
            this.dgvCursosAsignados.TabIndex = 5;
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(423, 247);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 34);
            this.Cancelar.TabIndex = 4;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // btnVerAlumnos
            // 
            this.btnVerAlumnos.Location = new System.Drawing.Point(146, 247);
            this.btnVerAlumnos.Name = "btnVerAlumnos";
            this.btnVerAlumnos.Size = new System.Drawing.Size(75, 34);
            this.btnVerAlumnos.TabIndex = 3;
            this.btnVerAlumnos.Text = "Ver Alumnos";
            this.btnVerAlumnos.UseVisualStyleBackColor = true;
            this.btnVerAlumnos.Click += new System.EventHandler(this.btnVerAlumnos_Click);
            // 
            // frmCursoAsignado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 296);
            this.Controls.Add(this.dgvCursosAsignados);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnVerAlumnos);
            this.Name = "frmCursoAsignado";
            this.Text = "Cursos Asignados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosAsignados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCursosAsignados;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button btnVerAlumnos;
    }
}