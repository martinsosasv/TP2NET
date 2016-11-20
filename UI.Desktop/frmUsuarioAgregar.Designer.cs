namespace UI.Desktop
{
    partial class frmUsuarioAgregar
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
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblNomberUsuario = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPersona = new System.Windows.Forms.Label();
            this.cbxPersona = new System.Windows.Forms.ComboBox();
            this.txtClave2 = new System.Windows.Forms.TextBox();
            this.lblClave2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(258, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(79, 250);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 23);
            this.btnAceptar.TabIndex = 22;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(180, 108);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(158, 20);
            this.txtClave.TabIndex = 21;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(140, 111);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 20;
            this.lblClave.Text = "Clave";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(180, 50);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(158, 20);
            this.txtNombreUsuario.TabIndex = 17;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(180, 19);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(158, 20);
            this.txtID.TabIndex = 16;
            // 
            // lblNomberUsuario
            // 
            this.lblNomberUsuario.AutoSize = true;
            this.lblNomberUsuario.Location = new System.Drawing.Point(96, 53);
            this.lblNomberUsuario.Name = "lblNomberUsuario";
            this.lblNomberUsuario.Size = new System.Drawing.Size(83, 13);
            this.lblNomberUsuario.TabIndex = 13;
            this.lblNomberUsuario.Text = "Nombre Usuario";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(156, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "ID";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(180, 85);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 24;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(180, 160);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(158, 20);
            this.txtEmail.TabIndex = 27;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(142, 167);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 26;
            this.lblEmail.Text = "Email";
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.Location = new System.Drawing.Point(128, 192);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(46, 13);
            this.lblPersona.TabIndex = 28;
            this.lblPersona.Text = "Persona";
            // 
            // cbxPersona
            // 
            this.cbxPersona.FormattingEnabled = true;
            this.cbxPersona.Location = new System.Drawing.Point(180, 189);
            this.cbxPersona.Name = "cbxPersona";
            this.cbxPersona.Size = new System.Drawing.Size(158, 21);
            this.cbxPersona.TabIndex = 29;
            // 
            // txtClave2
            // 
            this.txtClave2.Location = new System.Drawing.Point(180, 134);
            this.txtClave2.Name = "txtClave2";
            this.txtClave2.PasswordChar = '*';
            this.txtClave2.Size = new System.Drawing.Size(158, 20);
            this.txtClave2.TabIndex = 31;
            // 
            // lblClave2
            // 
            this.lblClave2.AutoSize = true;
            this.lblClave2.Location = new System.Drawing.Point(103, 141);
            this.lblClave2.Name = "lblClave2";
            this.lblClave2.Size = new System.Drawing.Size(71, 13);
            this.lblClave2.TabIndex = 30;
            this.lblClave2.Text = "Repetir Clave";
            // 
            // UsuarioAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 329);
            this.Controls.Add(this.txtClave2);
            this.Controls.Add(this.lblClave2);
            this.Controls.Add(this.cbxPersona);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.chkHabilitado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblNomberUsuario);
            this.Controls.Add(this.lblID);
            this.Name = "UsuarioAgregar";
            this.Text = "UsuarioAgregar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblNomberUsuario;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.ComboBox cbxPersona;
        private System.Windows.Forms.TextBox txtClave2;
        private System.Windows.Forms.Label lblClave2;

    }
}