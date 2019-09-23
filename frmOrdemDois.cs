using System;
using System.Linq;
using System.Windows.Forms;

namespace MathSharp
{
    public partial class frmOrdemDois : Form
    {
        public frmOrdemDois()
        {
            InitializeComponent();
        }

        public static float[,] Senha_Comum; // MATRIZ SENHA (informada pelo usuário)
        public static float[,] Senha_Criptografia; // MATRIZ CRIPTOGRAFIA (matriz auxiliar formada pela multiplicação dos elementos da MATRIZ SENHA)
        public static float[,] Senha_Mestre; // MATRIZ MESTRE (multiplicação entre a MATRIZ SENHA x MATRIZ CRIPTOGRAFIA)
        public static float[,] Senha_Inversa; // MATRIZ INVERSA (inversa da MATRIZ CRIPTOGRAFIA)
        public static float[,] Senha_Descriptografia; // MATRIZ DESCRIPTOGRAFIA (multiplicação da MATRIZ MESTRE x MATRIZ INVERSA = MATRIZ SENHA)

        private void frmOrdemDois_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal Principal = new frmPrincipal();
            Principal.Show();
            this.Hide();
        }

        private void btnCriptografar_Click(object sender, EventArgs e)
        {
            try
            {
                // MATRIZ SENHA: é uma matriz de ordem dois, na qual o usuário deve informar seus valores.
                // Esta matriz tem apenas como regra o limite de seus elementos, limitada a números inteiros positivos não superiores a 9999.
                float[,] Senha = { { 0, 0 }, { 0, 0 } };

                for (int l = 0; l <= 1; l++)
                {
                    for (int c = 0; c <= 1; c++)
                    {
                        String Nome = "txtSenha" + l + "x" + c;
                        TextBox txtSenha = this.Controls.Find(Nome, true).FirstOrDefault() as TextBox;
                        Senha[l, c] = float.Parse(txtSenha.Text);
                    }
                }

                Senha_Comum = Senha;

                // Determinante da MATRIZ SENHA (se o determinante for igual a 0, por definição sua inversa é inexistente)
                float Determinante;
                Determinante = (Senha_Comum[0, 0] * Senha_Comum[1, 1]) - (Senha_Comum[1, 0] * Senha_Comum[0, 1]);

                if (Determinante == 0)
                {
                    MessageBox.Show("Não foi possível criptografar a senha.\nA matriz senha comum tem zero como determinante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Zerar_Tudo();
                }
                else
                {
                    // MATRIZ CRIPTOGRAFIA: é uma matriz auxiliar que será multiplicada pela MATRIZ COMUM. 
                    // Esta matriz é formada por meio de uma multiplicação (baseada na regra abaixo) com os elementos da MATRIZ SENHA:

                    // - [Senha(L0C0) x 73] (73 em decimal = I)
                    // - [Senha(L0C1) x 70] (70 em decimal = F)
                    // - [Senha(L1C0) x 83] (83 em decimal = S)
                    // - [Senha(L1C1) x 80] (80 em decimal = P)

                    float[,] Criptografia = { 
                                                  // Coluna 1       // Coluna 2
                                                { Senha[0, 0] * 73, Senha[0, 1] * 70 } ,  // Linha 1

                                                  // Coluna 1       // Coluna 2
                                                { Senha[1, 0] * 83, Senha[1, 1] * 80 }    // Linha 2
                                            };

                    Senha_Criptografia = Criptografia;
                    txtSenhaCriptografia.Text = Senha_Criptografia[0, 0].ToString() + "   " + Senha_Criptografia[0, 1].ToString() + "   " + Senha_Criptografia[1, 0].ToString() + "   " + Senha_Criptografia[1, 1].ToString();

                    // MATRIZ MESTRE: é uma matriz gerada a partir da multiplicação da MATRIZ CRIPTOGRAFIA com a MATRIZ COMUM.
                    float[,] Mestre =
                                        {
                                            // LINHA 0
                                            {
                                                (Senha_Comum[0, 0] * Senha_Criptografia[0, 0]) + (Senha_Comum[0, 1] * Senha_Criptografia[1, 0]) ,   // COLUNA 0
                                                (Senha_Comum[0, 0] * Senha_Criptografia[0, 1]) + (Senha_Comum[0, 1] * Senha_Criptografia[1, 1])     // COLUNA 1
                                            } ,

                                            // LINHA 1
                                            {
                                                (Senha_Comum[1, 0] * Senha_Criptografia[0, 0]) + (Senha_Comum[1, 1] * Senha_Criptografia[1, 0]) ,   // COLUNA 0
                                                (Senha_Comum[1, 0] * Senha_Criptografia[0, 1]) + (Senha_Comum[1, 1] * Senha_Criptografia[1, 1])     // COLUNA 1
                                            }
                                        };

                    Senha_Mestre = Mestre;
                    txtSenhaMestre.Text = Senha_Mestre[0, 0].ToString() + "   " + Senha_Mestre[0, 1].ToString() + "   " + Senha_Mestre[1, 0].ToString() + "   " + Senha_Mestre[1, 1].ToString();

                    Zerar_Parcial();
                    btnDescriptografar.Enabled = true;
                    btnDescriptografar.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Dados inválidos, favor digitar novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Zerar_Tudo();
            }
        }

        private void btnDescriptografar_Click(object sender, EventArgs e)
        {

            // Determinante da MATRIZ CRIPTOGRAFIA (se o determinante for igual a 0, por definição sua inversa é inexistente)
            float Determinante;
            Determinante = (Senha_Criptografia[0, 0] * Senha_Criptografia[1, 1]) - (Senha_Criptografia[1, 0] * Senha_Criptografia[0, 1]);

            if (Determinante == 0)
            {
                MessageBox.Show("Não foi possível descriptografar a senha.\nA matriz criptografia tem zero como determinante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Zerar_Tudo();
            }
            else
            {
                // MATRIZ INVERSA: é a matriz inversa formada a partir da MATRIZ CRIPTOGRAFIA (regra exclusiva para matrizes de ordem 2)

                float[,] Inversa = {    // Coluna 1                   // Coluna 2
                                        {  Senha_Criptografia[1, 1] , -Senha_Criptografia[0, 1] } ,  // Linha 1

                                        // Coluna 1                   // Coluna 2
                                        { -Senha_Criptografia[1, 0] ,  Senha_Criptografia[0, 0] }    // Linha 2
                                   };

                Senha_Inversa = Inversa;
                txtSenhaInversa.Text = Senha_Inversa[0, 0].ToString() + "   " + Senha_Inversa[0, 1].ToString() + "   " + Senha_Inversa[1, 0].ToString() + "   " + Senha_Inversa[1, 1].ToString();

                // MATRIZ DESCRIPTOGRAFIA: é uma multiplicação entre a MATRIZ MESTRE e a MATRIZ INVERSA, resultando na MATRIZ SENHA
                float[,] Descriptografia =
                                        {       
                                            // LINHA 0
                                            {
                                                (Senha_Mestre[0, 0] * (Senha_Inversa[0, 0] / Determinante)) + (Senha_Mestre[0, 1] * (Senha_Inversa[1, 0] / Determinante)) ,   // COLUNA 0
                                                (Senha_Mestre[0, 0] * (Senha_Inversa[0, 1] / Determinante)) + (Senha_Mestre[0, 1] * (Senha_Inversa[1, 1] / Determinante))     // COLUNA 1
                                            } ,

                                            // LINHA 1
                                            {
                                                (Senha_Mestre[1, 0] * (Senha_Inversa[0, 0] / Determinante)) + (Senha_Mestre[1, 1] * (Senha_Inversa[1, 0] / Determinante)) ,   // COLUNA 0
                                                (Senha_Mestre[1, 0] * (Senha_Inversa[0, 1] / Determinante)) + (Senha_Mestre[1, 1] * (Senha_Inversa[1, 1] / Determinante))     // COLUNA 1
                                            }
                                        };

                Senha_Descriptografia = Descriptografia;
                txtSenhaDescriptografia.Text = Math.Round(Senha_Descriptografia[0, 0], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[0, 1], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[1, 0], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[1, 1], 0).ToString();
                btnZerar.Focus();
            }
        }

        private void btnZerar_Click(object sender, EventArgs e)
        {
            Zerar_Tudo();
        }

        // As instâncias abaixo tem como função fazer as validações do sistema, tais como: limpezas de campos, selecionar textos, gerar números randômicos.
        // Estas rotinas não influenciam diretamente no funcionamento do sistema, servindo apenas como uma base de organização.

        public void Zerar_Tudo()
        {
            for (int l = 0; l <= 1; l++)
            {
                for (int c = 0; c <= 1; c++)
                {
                    String Nome = "txtSenha" + l + "x" + c;
                    TextBox txtSenha = this.Controls.Find(Nome, true).FirstOrDefault() as TextBox;
                    txtSenha.Clear();
                }
            }

            Senha_Comum = null;
            Senha_Criptografia = null;
            Senha_Mestre = null;
            Senha_Inversa = null;
            Senha_Descriptografia = null;
            txtSenhaMestre.Clear();
            txtSenhaCriptografia.Clear();
            txtSenhaInversa.Clear();
            txtSenhaDescriptografia.Clear();
            btnDescriptografar.Enabled = false;
            txtSenha0x0.Focus();
        }

        public void Zerar_Parcial()
        {
            txtSenhaInversa.Clear();
            txtSenhaDescriptografia.Clear();
            Senha_Inversa = null;
            Senha_Descriptografia = null;
            btnDescriptografar.Enabled = false;
        }

        private void txtSenha0x0_Enter(object sender, EventArgs e)
        {
            txtSenha0x0.SelectAll();
        }

        private void txtSenha0x1_Enter(object sender, EventArgs e)
        {
            txtSenha0x1.SelectAll();
        }

        private void txtSenha1x0_Enter(object sender, EventArgs e)
        {
            txtSenha1x0.SelectAll();
        }

        private void txtSenha1x1_Enter(object sender, EventArgs e)
        {
            txtSenha1x1.SelectAll();
        }

        private void txtSenha0x0_KeyPress(object sender, KeyPressEventArgs e)
        {
            Zerar_Parcial();

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtSenhaMestre_Click(object sender, EventArgs e)
        {
            if (txtSenhaMestre.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Mestre[0, 0].ToString() + "\t" + Senha_Mestre[0, 1].ToString() + "\n" +
                    Senha_Mestre[1, 0].ToString() + "\t" + Senha_Mestre[1, 1].ToString(), "Senha Mestre"
                );
            }
        }

        private void txtSenhaCriptografia_Click(object sender, EventArgs e)
        {
            if (txtSenhaCriptografia.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Criptografia[0, 0].ToString() + "\t" + Senha_Criptografia[0, 1].ToString() + "\n" +
                    Senha_Criptografia[1, 0].ToString() + "\t" + Senha_Criptografia[1, 1].ToString(), "Senha Criptografia"
                );
            }
        }

        private void txtSenhaInversa_Click(object sender, EventArgs e)
        {
            if (txtSenhaInversa.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Inversa[0, 0].ToString() + "\t" + Senha_Inversa[0, 1].ToString() + "\n" +
                    Senha_Inversa[1, 0].ToString() + "\t" + Senha_Inversa[1, 1].ToString(), "Senha Inversa"
                );
            }
        }

        private void txtSenhaDescriptografia_Click(object sender, EventArgs e)
        {
            if (txtSenhaDescriptografia.Text != "")
            {
                MessageBox.Show
                (
                    Math.Round(Senha_Descriptografia[0, 0], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[0, 1], 0).ToString() + "\n" +
                    Math.Round(Senha_Descriptografia[1, 0], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[1, 1], 0).ToString(), "Senha Descriptografia"
                );
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Zerar_Parcial();

            Random Randômico = new Random();

            for (int l = 0; l <= 1; l++)
            {
                for (int c = 0; c <= 1; c++)
                {
                    String Nome = "txtSenha" + l + "x" + c;
                    TextBox txtSenha = this.Controls.Find(Nome, true).FirstOrDefault() as TextBox;
                    txtSenha.Text = Randômico.Next(0, 9999).ToString();
                }

                btnCriptografar.Focus();
            }
        }
    }
}
