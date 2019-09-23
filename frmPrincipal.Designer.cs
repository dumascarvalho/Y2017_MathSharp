namespace MathSharp
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOrdemDois = new System.Windows.Forms.Button();
            this.btnOrdemTrês = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrdemDois
            // 
            this.btnOrdemDois.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdemDois.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnOrdemDois.Location = new System.Drawing.Point(12, 12);
            this.btnOrdemDois.Name = "btnOrdemDois";
            this.btnOrdemDois.Size = new System.Drawing.Size(360, 93);
            this.btnOrdemDois.TabIndex = 0;
            this.btnOrdemDois.TabStop = false;
            this.btnOrdemDois.Text = "Matriz de Ordem 2x2";
            this.btnOrdemDois.UseVisualStyleBackColor = true;
            this.btnOrdemDois.Click += new System.EventHandler(this.btnOrdemDois_Click);
            // 
            // btnOrdemTrês
            // 
            this.btnOrdemTrês.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdemTrês.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnOrdemTrês.Location = new System.Drawing.Point(12, 111);
            this.btnOrdemTrês.Name = "btnOrdemTrês";
            this.btnOrdemTrês.Size = new System.Drawing.Size(360, 93);
            this.btnOrdemTrês.TabIndex = 1;
            this.btnOrdemTrês.TabStop = false;
            this.btnOrdemTrês.Text = "Matriz de Ordem 3x3";
            this.btnOrdemTrês.UseVisualStyleBackColor = true;
            this.btnOrdemTrês.Click += new System.EventHandler(this.btnOrdemTres_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 214);
            this.Controls.Add(this.btnOrdemTrês);
            this.Controls.Add(this.btnOrdemDois);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criptografia de Matrizes";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrdemDois;
        private System.Windows.Forms.Button btnOrdemTrês;
    }
}

