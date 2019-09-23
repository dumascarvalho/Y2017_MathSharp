using System;
using System.Windows.Forms;

namespace MathSharp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnOrdemDois_Click(object sender, EventArgs e)
        {
            frmOrdemDois OrdemDois = new frmOrdemDois();
            OrdemDois.Show();
            this.Hide();
        }

        private void btnOrdemTres_Click(object sender, EventArgs e)
        {
            frmOrdemTrês OrdemTres = new frmOrdemTrês();
            OrdemTres.Show();
            this.Hide();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
