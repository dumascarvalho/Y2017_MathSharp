namespace MathSharp
{
    partial class frmOrdemDois
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
            this.components = new System.ComponentModel.Container();
            this.gbxCriarSenha = new System.Windows.Forms.GroupBox();
            this.txtSenha1x1 = new System.Windows.Forms.TextBox();
            this.txtSenha1x0 = new System.Windows.Forms.TextBox();
            this.txtSenha0x1 = new System.Windows.Forms.TextBox();
            this.txtSenha0x0 = new System.Windows.Forms.TextBox();
            this.btnCriptografar = new System.Windows.Forms.Button();
            this.txtSenhaMestre = new System.Windows.Forms.TextBox();
            this.lblSenhaMestre = new System.Windows.Forms.Label();
            this.btnDescriptografar = new System.Windows.Forms.Button();
            this.lblSenhaInversa = new System.Windows.Forms.Label();
            this.txtSenhaInversa = new System.Windows.Forms.TextBox();
            this.btnZerar = new System.Windows.Forms.Button();
            this.lblDescriptografia = new System.Windows.Forms.Label();
            this.txtSenhaDescriptografia = new System.Windows.Forms.TextBox();
            this.lblCriptografia = new System.Windows.Forms.Label();
            this.txtSenhaCriptografia = new System.Windows.Forms.TextBox();
            this.tipMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.btnRandom = new System.Windows.Forms.Button();
            this.gbxCriarSenha.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCriarSenha
            // 
            this.gbxCriarSenha.Controls.Add(this.txtSenha1x1);
            this.gbxCriarSenha.Controls.Add(this.txtSenha1x0);
            this.gbxCriarSenha.Controls.Add(this.txtSenha0x1);
            this.gbxCriarSenha.Controls.Add(this.txtSenha0x0);
            this.gbxCriarSenha.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCriarSenha.Location = new System.Drawing.Point(12, 12);
            this.gbxCriarSenha.Name = "gbxCriarSenha";
            this.gbxCriarSenha.Size = new System.Drawing.Size(230, 96);
            this.gbxCriarSenha.TabIndex = 0;
            this.gbxCriarSenha.TabStop = false;
            this.gbxCriarSenha.Text = " Criar Senha: ";
            this.tipMensagem.SetToolTip(this.gbxCriarSenha, "Estes campos recebem apenas números inteiros positivos.");
            // 
            // txtSenha1x1
            // 
            this.txtSenha1x1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha1x1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSenha1x1.Location = new System.Drawing.Point(126, 59);
            this.txtSenha1x1.MaxLength = 4;
            this.txtSenha1x1.Name = "txtSenha1x1";
            this.txtSenha1x1.Size = new System.Drawing.Size(84, 22);
            this.txtSenha1x1.TabIndex = 3;
            this.txtSenha1x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha1x1.Click += new System.EventHandler(this.txtSenha1x1_Enter);
            this.txtSenha1x1.Enter += new System.EventHandler(this.txtSenha1x1_Enter);
            this.txtSenha1x1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha0x0_KeyPress);
            // 
            // txtSenha1x0
            // 
            this.txtSenha1x0.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha1x0.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSenha1x0.Location = new System.Drawing.Point(20, 59);
            this.txtSenha1x0.MaxLength = 4;
            this.txtSenha1x0.Name = "txtSenha1x0";
            this.txtSenha1x0.Size = new System.Drawing.Size(84, 22);
            this.txtSenha1x0.TabIndex = 2;
            this.txtSenha1x0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha1x0.Click += new System.EventHandler(this.txtSenha1x0_Enter);
            this.txtSenha1x0.Enter += new System.EventHandler(this.txtSenha1x0_Enter);
            this.txtSenha1x0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha0x0_KeyPress);
            // 
            // txtSenha0x1
            // 
            this.txtSenha0x1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha0x1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSenha0x1.Location = new System.Drawing.Point(126, 28);
            this.txtSenha0x1.MaxLength = 4;
            this.txtSenha0x1.Name = "txtSenha0x1";
            this.txtSenha0x1.Size = new System.Drawing.Size(84, 22);
            this.txtSenha0x1.TabIndex = 1;
            this.txtSenha0x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha0x1.Click += new System.EventHandler(this.txtSenha0x1_Enter);
            this.txtSenha0x1.Enter += new System.EventHandler(this.txtSenha0x1_Enter);
            this.txtSenha0x1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha0x0_KeyPress);
            // 
            // txtSenha0x0
            // 
            this.txtSenha0x0.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha0x0.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSenha0x0.Location = new System.Drawing.Point(20, 28);
            this.txtSenha0x0.MaxLength = 4;
            this.txtSenha0x0.Name = "txtSenha0x0";
            this.txtSenha0x0.Size = new System.Drawing.Size(84, 22);
            this.txtSenha0x0.TabIndex = 0;
            this.txtSenha0x0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha0x0.Click += new System.EventHandler(this.txtSenha0x0_Enter);
            this.txtSenha0x0.Enter += new System.EventHandler(this.txtSenha0x0_Enter);
            this.txtSenha0x0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha0x0_KeyPress);
            // 
            // btnCriptografar
            // 
            this.btnCriptografar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriptografar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriptografar.Location = new System.Drawing.Point(270, 12);
            this.btnCriptografar.Name = "btnCriptografar";
            this.btnCriptografar.Size = new System.Drawing.Size(152, 31);
            this.btnCriptografar.TabIndex = 1;
            this.btnCriptografar.Text = "&Criptografar";
            this.btnCriptografar.UseVisualStyleBackColor = true;
            this.btnCriptografar.Click += new System.EventHandler(this.btnCriptografar_Click);
            // 
            // txtSenhaMestre
            // 
            this.txtSenhaMestre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSenhaMestre.Cursor = System.Windows.Forms.Cursors.Help;
            this.txtSenhaMestre.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaMestre.Location = new System.Drawing.Point(12, 149);
            this.txtSenhaMestre.Name = "txtSenhaMestre";
            this.txtSenhaMestre.ReadOnly = true;
            this.txtSenhaMestre.Size = new System.Drawing.Size(410, 21);
            this.txtSenhaMestre.TabIndex = 4;
            this.txtSenhaMestre.TabStop = false;
            this.txtSenhaMestre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaMestre.Click += new System.EventHandler(this.txtSenhaMestre_Click);
            // 
            // lblSenhaMestre
            // 
            this.lblSenhaMestre.AutoSize = true;
            this.lblSenhaMestre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaMestre.Location = new System.Drawing.Point(12, 128);
            this.lblSenhaMestre.Name = "lblSenhaMestre";
            this.lblSenhaMestre.Size = new System.Drawing.Size(111, 18);
            this.lblSenhaMestre.TabIndex = 8;
            this.lblSenhaMestre.Text = "Senha Mestre:";
            // 
            // btnDescriptografar
            // 
            this.btnDescriptografar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescriptografar.Enabled = false;
            this.btnDescriptografar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescriptografar.Location = new System.Drawing.Point(270, 49);
            this.btnDescriptografar.Name = "btnDescriptografar";
            this.btnDescriptografar.Size = new System.Drawing.Size(152, 31);
            this.btnDescriptografar.TabIndex = 2;
            this.btnDescriptografar.Text = "&Descriptografar";
            this.btnDescriptografar.UseVisualStyleBackColor = true;
            this.btnDescriptografar.Click += new System.EventHandler(this.btnDescriptografar_Click);
            // 
            // lblSenhaInversa
            // 
            this.lblSenhaInversa.AutoSize = true;
            this.lblSenhaInversa.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaInversa.Location = new System.Drawing.Point(12, 220);
            this.lblSenhaInversa.Name = "lblSenhaInversa";
            this.lblSenhaInversa.Size = new System.Drawing.Size(114, 18);
            this.lblSenhaInversa.TabIndex = 10;
            this.lblSenhaInversa.Text = "Senha Inversa:";
            // 
            // txtSenhaInversa
            // 
            this.txtSenhaInversa.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSenhaInversa.Cursor = System.Windows.Forms.Cursors.Help;
            this.txtSenhaInversa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaInversa.Location = new System.Drawing.Point(12, 241);
            this.txtSenhaInversa.Name = "txtSenhaInversa";
            this.txtSenhaInversa.ReadOnly = true;
            this.txtSenhaInversa.Size = new System.Drawing.Size(410, 21);
            this.txtSenhaInversa.TabIndex = 6;
            this.txtSenhaInversa.TabStop = false;
            this.txtSenhaInversa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaInversa.Click += new System.EventHandler(this.txtSenhaInversa_Click);
            // 
            // btnZerar
            // 
            this.btnZerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZerar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZerar.Location = new System.Drawing.Point(270, 86);
            this.btnZerar.Name = "btnZerar";
            this.btnZerar.Size = new System.Drawing.Size(152, 31);
            this.btnZerar.TabIndex = 3;
            this.btnZerar.Text = "&Zerar Campos";
            this.btnZerar.UseVisualStyleBackColor = true;
            this.btnZerar.Click += new System.EventHandler(this.btnZerar_Click);
            // 
            // lblDescriptografia
            // 
            this.lblDescriptografia.AutoSize = true;
            this.lblDescriptografia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptografia.Location = new System.Drawing.Point(12, 266);
            this.lblDescriptografia.Name = "lblDescriptografia";
            this.lblDescriptografia.Size = new System.Drawing.Size(170, 18);
            this.lblDescriptografia.TabIndex = 11;
            this.lblDescriptografia.Text = "Senha Descriptografia:";
            // 
            // txtSenhaDescriptografia
            // 
            this.txtSenhaDescriptografia.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSenhaDescriptografia.Cursor = System.Windows.Forms.Cursors.Help;
            this.txtSenhaDescriptografia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaDescriptografia.Location = new System.Drawing.Point(12, 287);
            this.txtSenhaDescriptografia.Name = "txtSenhaDescriptografia";
            this.txtSenhaDescriptografia.ReadOnly = true;
            this.txtSenhaDescriptografia.Size = new System.Drawing.Size(410, 21);
            this.txtSenhaDescriptografia.TabIndex = 7;
            this.txtSenhaDescriptografia.TabStop = false;
            this.txtSenhaDescriptografia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaDescriptografia.Click += new System.EventHandler(this.txtSenhaDescriptografia_Click);
            // 
            // lblCriptografia
            // 
            this.lblCriptografia.AutoSize = true;
            this.lblCriptografia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriptografia.Location = new System.Drawing.Point(12, 174);
            this.lblCriptografia.Name = "lblCriptografia";
            this.lblCriptografia.Size = new System.Drawing.Size(145, 18);
            this.lblCriptografia.TabIndex = 9;
            this.lblCriptografia.Text = "Senha Criptografia:";
            // 
            // txtSenhaCriptografia
            // 
            this.txtSenhaCriptografia.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSenhaCriptografia.Cursor = System.Windows.Forms.Cursors.Help;
            this.txtSenhaCriptografia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaCriptografia.Location = new System.Drawing.Point(12, 195);
            this.txtSenhaCriptografia.Name = "txtSenhaCriptografia";
            this.txtSenhaCriptografia.ReadOnly = true;
            this.txtSenhaCriptografia.Size = new System.Drawing.Size(410, 21);
            this.txtSenhaCriptografia.TabIndex = 5;
            this.txtSenhaCriptografia.TabStop = false;
            this.txtSenhaCriptografia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaCriptografia.Click += new System.EventHandler(this.txtSenhaCriptografia_Click);
            // 
            // tipMensagem
            // 
            this.tipMensagem.AutoPopDelay = 5000;
            this.tipMensagem.InitialDelay = 500;
            this.tipMensagem.ReshowDelay = 2000;
            this.tipMensagem.ShowAlways = true;
            this.tipMensagem.ToolTipTitle = "Mensagem:";
            // 
            // btnRandom
            // 
            this.btnRandom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRandom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(149, 114);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(93, 23);
            this.btnRandom.TabIndex = 12;
            this.btnRandom.Text = "&Randômico";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // frmOrdemDois
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 322);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.lblCriptografia);
            this.Controls.Add(this.txtSenhaCriptografia);
            this.Controls.Add(this.lblDescriptografia);
            this.Controls.Add(this.txtSenhaDescriptografia);
            this.Controls.Add(this.btnZerar);
            this.Controls.Add(this.lblSenhaInversa);
            this.Controls.Add(this.txtSenhaInversa);
            this.Controls.Add(this.btnDescriptografar);
            this.Controls.Add(this.lblSenhaMestre);
            this.Controls.Add(this.txtSenhaMestre);
            this.Controls.Add(this.btnCriptografar);
            this.Controls.Add(this.gbxCriarSenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOrdemDois";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matriz de Ordem Dois";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOrdemDois_FormClosed);
            this.gbxCriarSenha.ResumeLayout(false);
            this.gbxCriarSenha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCriarSenha;
        private System.Windows.Forms.TextBox txtSenha1x1;
        private System.Windows.Forms.TextBox txtSenha1x0;
        private System.Windows.Forms.TextBox txtSenha0x1;
        private System.Windows.Forms.TextBox txtSenha0x0;
        private System.Windows.Forms.Button btnCriptografar;
        private System.Windows.Forms.TextBox txtSenhaMestre;
        private System.Windows.Forms.Label lblSenhaMestre;
        private System.Windows.Forms.Button btnDescriptografar;
        private System.Windows.Forms.Label lblSenhaInversa;
        private System.Windows.Forms.TextBox txtSenhaInversa;
        private System.Windows.Forms.Button btnZerar;
        private System.Windows.Forms.Label lblDescriptografia;
        private System.Windows.Forms.TextBox txtSenhaDescriptografia;
        private System.Windows.Forms.Label lblCriptografia;
        private System.Windows.Forms.TextBox txtSenhaCriptografia;
        private System.Windows.Forms.ToolTip tipMensagem;
        private System.Windows.Forms.Button btnRandom;
    }
}