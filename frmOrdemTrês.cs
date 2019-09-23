using System;
using System.Linq;
using System.Windows.Forms;

namespace MathSharp
{
    public partial class frmOrdemTrês : Form
    {
        public frmOrdemTrês()
        {
            InitializeComponent();
        }

        public static float[,] Senha_Comum; // MATRIZ SENHA (informada pelo usuário)
        public static float Determinante_Comum; // Determinante da MATRIZ SENHA
        public static float[,] Senha_Criptografia; // MATRIZ CRIPTOGRAFIA MATRIZ CRIPTOGRAFIA (matriz auxiliar formada pela multiplicação dos elementos da MATRIZ SENHA)
        public static float[,] Senha_Mestre; // MATRIZ MESTRE (multiplicação entre a MATRIZ SENHA x CRIPTOGRAFIA)
        public static float Determinante_Criptografia; // Determinante da MATRIZ CRIPTOGRAFIA
        public static float[,] Senha_Transposta; // MATRIZ TRANSPOSTA (transposta da MATRIZ CRIPTOGRAFIA)
        public static float[,] Senha_Cofatora; // MATRIZ COFATORA (matriz adjunta formada a partir dos elementos da MATRIZ TRANSPOSTA)
        public static float[,] Senha_Inversa; // MATRIZ INVERSA (matriz resultante da multiplicação entre MATRIZ COFATORA x 1 / DETERMINANTE CRIPTOGRAFIA
        public static float[,] Senha_Descriptografia; // MATRIZ DESCRIPTOGRAFIA (multiplicação da MATRIZ MESTRE x MATRIZ INVERSA = MATRIZ SENHA)

        private void frmOrdemTres_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal Principal = new frmPrincipal();
            Principal.Show();
            this.Hide();
        }

        private void btnCriptografar_Click(object sender, EventArgs e)
        {
            try
            {
                // MATRIZ SENHA: uma matriz de ordem três, na qual o usuário deve informar seus valores.
                // Esta matriz tem apenas como regra o limite de seus elementos, limitada a números inteiros positivos não superiores a 9999.
                float[,] Senha = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                for (int l = 0; l <= 2; l++)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        String Nome = "txtSenha" + l + "x" + c;
                        TextBox txtSenha = this.Controls.Find(Nome, true).FirstOrDefault() as TextBox;
                        Senha[l, c] = float.Parse(txtSenha.Text);
                    }
                }

                Senha_Comum = Senha;

                // Determinante da MATRIZ SENHA (se o determinante for igual a 0, por definição sua inversa é inexistente)
                float Det_PC, Det_NC, Det_Comum;

                // Sentido da Esquerda para Direita
                Det_PC = +(Senha_Comum[0, 0] * Senha_Comum[1, 1] * Senha_Comum[2, 2]) + (Senha_Comum[0, 1] * Senha_Comum[1, 2] * Senha_Comum[2, 0]) + (Senha_Comum[0, 2] * Senha_Comum[1, 0] * Senha_Comum[2, 1]);

                // Sentido da Direita para Esquerda 
                Det_NC = -(Senha_Comum[0, 2] * Senha_Comum[1, 1] * Senha_Comum[2, 0]) - (Senha_Comum[0, 0] * Senha_Comum[1, 2] * Senha_Comum[2, 1]) - (Senha_Comum[0, 1] * Senha_Comum[1, 0] * Senha_Comum[2, 2]);

                Det_Comum = Det_PC + Det_NC;
                Determinante_Comum = Det_Comum;

                if (Determinante_Comum == 0)
                {
                    MessageBox.Show("Não foi possível criptografar a senha.\nA matriz senha tem zero como determinante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Zerar_Tudo();
                }
                else
                {
                    // MATRIZ CRIPTOGRAFIA: é uma matriz auxiliar que será multiplicada pela MATRIZ COMUM. 
                    // Esta matriz é formada por meio de uma multiplicação (baseada na regra abaixo) com os elementos da MATRIZ SENHA:

                    // - [Senha(L0C0) x 73] (73 em decimal = I)
                    // - [Senha(L0C1) x 70] (70 em decimal = F)
                    // - [Senha(L0C2) x 72] (72 em decimal = H)
                    // - [Senha(L1C0) x 84] (84 em decimal = T)
                    // - [Senha(L1C1) x 65] (65 em decimal = A)
                    // - [Senha(L1C2) x 68] (68 em decimal = D)
                    // - [Senha(L2C0) x 83] (83 em decimal = S)
                    // - [Senha(L2C1) x 1] 
                    // - [Senha(L2C2) x 7] 

                    float[,] Criptografia = {     // Coluna 1             // Coluna 2             // Coluna 3
                                                { Senha_Comum[0,0] * 73 , Senha_Comum[0,1] * 70 , Senha_Comum[0,2] * 72 } ,   // Linha 1
                                                { Senha_Comum[1,0] * 84 , Senha_Comum[1,1] * 65 , Senha_Comum[1,2] * 68 } ,   // Linha 2
                                                { Senha_Comum[2,0] * 83 , Senha_Comum[2,1] * 01 , Senha_Comum[2,2] * 07 }     // Linha 3
                                            };

                    Senha_Criptografia = Criptografia;
                    txtSenhaCriptografia.Text = Senha_Criptografia[0, 0].ToString() + "   " + Senha_Criptografia[0, 1].ToString() + "   " + Senha_Criptografia[0, 2].ToString() +
                                        "   " + Senha_Criptografia[1, 0].ToString() + "   " + Senha_Criptografia[1, 1].ToString() + "   " + Senha_Criptografia[1, 2].ToString() +
                                        "   " + Senha_Criptografia[2, 0].ToString() + "   " + Senha_Criptografia[2, 1].ToString() + "   " + Senha_Criptografia[2, 2].ToString();

                    // Determinante da MATRIZ CRIPTOGRAFIA (se o determinante for igual a 0, por definição sua inversa é inexistente)
                    float Det_PM, Det_NM, Det_Criptografia;

                    // Sentido da Esquerda para Direita
                    Det_PM = +(Senha_Criptografia[0, 0] * Senha_Criptografia[1, 1] * Senha_Criptografia[2, 2]) + (Senha_Criptografia[0, 1] * Senha_Criptografia[1, 2] * Senha_Criptografia[2, 0]) + (Senha_Criptografia[0, 2] * Senha_Criptografia[1, 0] * Senha_Criptografia[2, 1]);

                    // Sentido da Direita para Esquerda 
                    Det_NM = -(Senha_Criptografia[0, 2] * Senha_Criptografia[1, 1] * Senha_Criptografia[2, 0]) - (Senha_Criptografia[0, 0] * Senha_Criptografia[1, 2] * Senha_Criptografia[2, 1]) - (Senha_Criptografia[0, 1] * Senha_Criptografia[1, 0] * Senha_Criptografia[2, 2]);

                    Det_Criptografia = Det_PM + Det_NM;
                    Determinante_Criptografia = Det_Criptografia;

                    if (Determinante_Criptografia == 0)
                    {
                        MessageBox.Show("Não foi possível criptografar a senha.\nA matriz criptografia tem zero como determinante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Zerar_Tudo();
                    }
                    else
                    {
                        // MATRIZ MESTRE: é uma matriz gerada a partir da multiplicação da MATRIZ CRIPTOGRAFIA com a MATRIZ COMUM.
                        float[] Elementos =
                        {
                            // Linha 1
                            (Senha_Comum[0,0] * Senha_Criptografia[0,0]) + (Senha_Comum[0,1] * Senha_Criptografia[1,0]) + (Senha_Comum[0,2] * Senha_Criptografia[2,0]) ,    // Coluna 1
                            (Senha_Comum[0,0] * Senha_Criptografia[0,1]) + (Senha_Comum[0,1] * Senha_Criptografia[1,1]) + (Senha_Comum[0,2] * Senha_Criptografia[2,1]) ,    // Coluna 2
                            (Senha_Comum[0,0] * Senha_Criptografia[0,2]) + (Senha_Comum[0,1] * Senha_Criptografia[1,2]) + (Senha_Comum[0,2] * Senha_Criptografia[2,2]) ,    // Coluna 3

                            // Linha 2
                            (Senha_Comum[1,0] * Senha_Criptografia[0,0]) + (Senha_Comum[1,1] * Senha_Criptografia[1,0]) + (Senha_Comum[1,2] * Senha_Criptografia[2,0]) ,    // Coluna 1
                            (Senha_Comum[1,0] * Senha_Criptografia[0,1]) + (Senha_Comum[1,1] * Senha_Criptografia[1,1]) + (Senha_Comum[1,2] * Senha_Criptografia[2,1]) ,    // Coluna 2
                            (Senha_Comum[1,0] * Senha_Criptografia[0,2]) + (Senha_Comum[1,1] * Senha_Criptografia[1,2]) + (Senha_Comum[1,2] * Senha_Criptografia[2,2]) ,    // Coluna 3

                            // Linha 3
                            (Senha_Comum[2,0] * Senha_Criptografia[0,0]) + (Senha_Comum[2,1] * Senha_Criptografia[1,0]) + (Senha_Comum[2,2] * Senha_Criptografia[2,0]) ,    // Coluna 1
                            (Senha_Comum[2,0] * Senha_Criptografia[0,1]) + (Senha_Comum[2,1] * Senha_Criptografia[1,1]) + (Senha_Comum[2,2] * Senha_Criptografia[2,1]) ,    // Coluna 2
                            (Senha_Comum[2,0] * Senha_Criptografia[0,2]) + (Senha_Comum[2,1] * Senha_Criptografia[1,2]) + (Senha_Comum[2,2] * Senha_Criptografia[2,2])      // Coluna 3
                        };

                        float[,] Mestre =
                        { 
                              // Coluna 1   // Coluna 2   // Coluna 3
                            { Elementos[0], Elementos[1], Elementos[2] } ,   // Linha 1
                            { Elementos[3], Elementos[4], Elementos[5] } ,   // Linha 2
                            { Elementos[6], Elementos[7], Elementos[8] }     // Linha 3
                        };

                        Senha_Mestre = Mestre;
                        txtSenhaMestre.Text = Senha_Mestre[0, 0].ToString() + "   " + Senha_Mestre[0, 1].ToString() + "   " + Senha_Mestre[0, 2].ToString() +
                                            "   " + Senha_Mestre[1, 0].ToString() + "   " + Senha_Mestre[1, 1].ToString() + "   " + Senha_Mestre[1, 2].ToString() +
                                            "   " + Senha_Mestre[2, 0].ToString() + "   " + Senha_Mestre[2, 1].ToString() + "   " + Senha_Mestre[2, 2].ToString();

                        // MATRIZ TRANSPOSTA: é a matriz transposta da MATRIZ CRIPTOGRAFIA
                        float[,] Transposta =
                        {   
                              // Coluna 1               // Coluna 2               // Coluna 3
                            { Senha_Criptografia[0,0] , Senha_Criptografia[1,0] , Senha_Criptografia[2,0] } ,   // Linha 1
                            { Senha_Criptografia[0,1] , Senha_Criptografia[1,1] , Senha_Criptografia[2,1] } ,   // Linha 2
                            { Senha_Criptografia[0,2] , Senha_Criptografia[1,2] , Senha_Criptografia[2,2] }     // Linha 3
                        };

                        Senha_Transposta = Transposta;
                        txtSenhaTransposta.Text = Senha_Transposta[0, 0].ToString() + "   " + Senha_Transposta[0, 1].ToString() + "   " + Senha_Transposta[0, 2].ToString() +
                                                "   " + Senha_Transposta[1, 0].ToString() + "   " + Senha_Transposta[1, 1].ToString() + "   " + Senha_Transposta[1, 2].ToString() +
                                                "   " + Senha_Transposta[2, 0].ToString() + "   " + Senha_Transposta[2, 1].ToString() + "   " + Senha_Transposta[2, 2].ToString();

                        // ZERAR CAMPOS: caso já houver números nos campos remanescentes, os mesmos serão zerados
                        Zerar_Parcial();
                        btnCofatorar.Enabled = true;
                        btnCofatorar.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Dados inválidos, favor digitar novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Zerar_Tudo();
            }
        }

        private void btnCofatorar_Click(object sender, EventArgs e)
        {
            // MATRIZ COFATORA: é a matriz adjunta gerada pelos elementos cofatores da MATRIZ TRANSPOSTA
            float[] Determinantes_Cofatora =
            { 
                // Linha 1
                + 1 * ((Senha_Transposta[1,1] * Senha_Transposta[2,2]) - (Senha_Transposta[2,1] * Senha_Transposta[1,2])) , // Coluna 1
                - 1 * ((Senha_Transposta[1,0] * Senha_Transposta[2,2]) - (Senha_Transposta[2,0] * Senha_Transposta[1,2])) , // Coluna 2
                + 1 * ((Senha_Transposta[1,0] * Senha_Transposta[2,1]) - (Senha_Transposta[2,0] * Senha_Transposta[1,1])) , // Coluna 3

                // Linha 2
                - 1 * ((Senha_Transposta[0,1] * Senha_Transposta[2,2]) - (Senha_Transposta[2,1] * Senha_Transposta[0,2])) , // Coluna 1
                + 1 * ((Senha_Transposta[0,0] * Senha_Transposta[2,2]) - (Senha_Transposta[2,0] * Senha_Transposta[0,2])) , // Coluna 2
                - 1 * ((Senha_Transposta[0,0] * Senha_Transposta[2,1]) - (Senha_Transposta[2,0] * Senha_Transposta[0,1])) , // Coluna 3

                // Linha 3
                + 1 * ((Senha_Transposta[0,1] * Senha_Transposta[1,2]) - (Senha_Transposta[1,1] * Senha_Transposta[0,2])) , // Coluna 1
                - 1 * ((Senha_Transposta[0,0] * Senha_Transposta[1,2]) - (Senha_Transposta[1,0] * Senha_Transposta[0,2])) , // Coluna 2
                + 1 * ((Senha_Transposta[0,0] * Senha_Transposta[1,1]) - (Senha_Transposta[1,0] * Senha_Transposta[0,1])) , // Coluna 3
            };

            float[,] Cofatora =
            {      
                  // Coluna 1                 // Coluna 2                  // Coluna 3
                { Determinantes_Cofatora[0] , Determinantes_Cofatora[1]  , Determinantes_Cofatora[2] } ,  // Linha 1  
                { Determinantes_Cofatora[3] , Determinantes_Cofatora[4]  , Determinantes_Cofatora[5] } ,  // Linha 2
                { Determinantes_Cofatora[6] , Determinantes_Cofatora[7]  , Determinantes_Cofatora[8] }    // Linha 3  
            };

            Senha_Cofatora = Cofatora;
            txtSenhaCofatora.Text = Senha_Cofatora[0, 0].ToString() + "   " + Senha_Cofatora[0, 1].ToString() + "   " + Senha_Cofatora[0, 2].ToString() +
                                    "   " + Senha_Cofatora[1, 0].ToString() + "   " + Senha_Cofatora[1, 1].ToString() + "   " + Senha_Cofatora[1, 2].ToString() +
                                    "   " + Senha_Cofatora[2, 0].ToString() + "   " + Senha_Cofatora[2, 1].ToString() + "   " + Senha_Cofatora[2, 2].ToString();

            btnDescriptografar.Enabled = true;
            btnDescriptografar.Focus();
        }

        private void btnDescriptografar_Click(object sender, EventArgs e)
        {
            // MATRIZ INVERSA: é a matriz resultante da multiplicação entre a MATRIZ COFATORA x 1 / Det(MATRIZ CRIPTOGRAFIA)
            float[,] Inversa =
            {     
                  // Coluna 1                                         // Coluna 2                                         // Coluna 3  
                { (Senha_Cofatora[0,0] / Determinante_Criptografia) , (Senha_Cofatora[0,1] / Determinante_Criptografia) , (Senha_Cofatora[0,2] / Determinante_Criptografia) } , // Linha 1
                { (Senha_Cofatora[1,0] / Determinante_Criptografia) , (Senha_Cofatora[1,1] / Determinante_Criptografia) , (Senha_Cofatora[1,2] / Determinante_Criptografia) } , // Linha 2
                { (Senha_Cofatora[2,0] / Determinante_Criptografia) , (Senha_Cofatora[2,1] / Determinante_Criptografia) , (Senha_Cofatora[2,2] / Determinante_Criptografia) }   // Linha 3
            };

            Senha_Inversa = Inversa;
            txtSenhaInversa.Text = Senha_Inversa[0, 0].ToString() + "   " + Senha_Inversa[0, 1].ToString() + "   " + Senha_Inversa[0, 2].ToString() +
                                    "   " + Senha_Inversa[1, 0].ToString() + "   " + Senha_Inversa[1, 1].ToString() + "   " + Senha_Inversa[1, 2].ToString() +
                                    "   " + Senha_Inversa[2, 0].ToString() + "   " + Senha_Inversa[2, 1].ToString() + "   " + Senha_Inversa[2, 2].ToString();

            // MATRIZ DESCRIPTOGRAFIA: é uma multiplicação entre a MATRIZ MESTRE e a MATRIZ INVERSA, resultando na MATRIZ SENHA
            float[] Elementos =
            {
                // Linha 1
                (Senha_Mestre[0,0] * Senha_Inversa[0,0]) + (Senha_Mestre[0,1] * Senha_Inversa[1,0]) + (Senha_Mestre[0,2] * Senha_Inversa[2,0]) ,    // Coluna 1
                (Senha_Mestre[0,0] * Senha_Inversa[0,1]) + (Senha_Mestre[0,1] * Senha_Inversa[1,1]) + (Senha_Mestre[0,2] * Senha_Inversa[2,1]) ,    // Coluna 2
                (Senha_Mestre[0,0] * Senha_Inversa[0,2]) + (Senha_Mestre[0,1] * Senha_Inversa[1,2]) + (Senha_Mestre[0,2] * Senha_Inversa[2,2]) ,    // Coluna 3

                // Linha 2
                (Senha_Mestre[1,0] * Senha_Inversa[0,0]) + (Senha_Mestre[1,1] * Senha_Inversa[1,0]) + (Senha_Mestre[1,2] * Senha_Inversa[2,0]) ,    // Coluna 1
                (Senha_Mestre[1,0] * Senha_Inversa[0,1]) + (Senha_Mestre[1,1] * Senha_Inversa[1,1]) + (Senha_Mestre[1,2] * Senha_Inversa[2,1]) ,    // Coluna 2
                (Senha_Mestre[1,0] * Senha_Inversa[0,2]) + (Senha_Mestre[1,1] * Senha_Inversa[1,2]) + (Senha_Mestre[1,2] * Senha_Inversa[2,2]) ,    // Coluna 3

                // Linha 3
                (Senha_Mestre[2,0] * Senha_Inversa[0,0]) + (Senha_Mestre[2,1] * Senha_Inversa[1,0]) + (Senha_Mestre[2,2] * Senha_Inversa[2,0]) ,    // Coluna 1
                (Senha_Mestre[2,0] * Senha_Inversa[0,1]) + (Senha_Mestre[2,1] * Senha_Inversa[1,1]) + (Senha_Mestre[2,2] * Senha_Inversa[2,1]) ,    // Coluna 2
                (Senha_Mestre[2,0] * Senha_Inversa[0,2]) + (Senha_Mestre[2,1] * Senha_Inversa[1,2]) + (Senha_Mestre[2,2] * Senha_Inversa[2,2])      // Coluna 3
            };

            float[,] Descriptografar =
            { 
                  // Coluna 1   // Coluna 2   // Coluna 3
                { Elementos[0], Elementos[1], Elementos[2] },   // Linha 1
                { Elementos[3], Elementos[4], Elementos[5] },   // Linha 2
                { Elementos[6], Elementos[7], Elementos[8] }    // Linha 3
            };

            Senha_Descriptografia = Descriptografar;
            txtSenhaDescriptografia.Text = Math.Round(Senha_Descriptografia[0, 0], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[0, 1], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[0, 2], 0).ToString() +
                                    "   " + Math.Round(Senha_Descriptografia[1, 0], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[1, 1], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[1, 2], 0).ToString() +
                                    "   " + Math.Round(Senha_Descriptografia[2, 0], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[2, 1], 0).ToString() + "   " + Math.Round(Senha_Descriptografia[2, 2], 0).ToString();
            btnZerar.Focus();
        }

        private void btnZerar_Click(object sender, EventArgs e)
        {
            Zerar_Tudo();
        }

        // As instâncias abaixo têm como função fazer as validações do sistema, tais como: limpezas de campos, selecionar textos, gerar números randômicos.
        // Estas rotinas não influenciam diretamente no funcionamento do sistema, servindo apenas como uma base de organização.

        public void Zerar_Tudo()
        {
            for (int l = 0; l <= 2; l++)
            {
                for (int c = 0; c <= 2; c++)
                {
                    String Nome = "txtSenha" + l + "x" + c;
                    TextBox txtSenha = this.Controls.Find(Nome, true).FirstOrDefault() as TextBox;
                    txtSenha.Clear();
                }
            }

            Senha_Comum = null;
            Senha_Criptografia = null;
            Senha_Mestre = null;
            Senha_Cofatora = null;
            Senha_Transposta = null;
            Senha_Inversa = null;
            Senha_Descriptografia = null;
            txtSenhaMestre.Clear();
            txtSenhaCriptografia.Clear();
            txtSenhaCofatora.Clear();
            txtSenhaTransposta.Clear();
            txtSenhaInversa.Clear();
            txtSenhaDescriptografia.Clear();
            btnCofatorar.Enabled = false;
            btnDescriptografar.Enabled = false;
            txtSenha0x0.Focus();
        }

        public void Zerar_Parcial()
        {
            Senha_Cofatora = null;
            Senha_Inversa = null;
            Senha_Descriptografia = null;
            txtSenhaCofatora.Clear();
            txtSenhaInversa.Clear();
            txtSenhaDescriptografia.Clear();
            btnCofatorar.Enabled = false;
            btnDescriptografar.Enabled = false;
        }

        private void txtSenha0x0_KeyPress(object sender, KeyPressEventArgs e)
        {
            Zerar_Parcial();

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtSenha0x0_Enter(object sender, EventArgs e)
        {
            txtSenha0x0.SelectAll();
        }

        private void txtSenha0x1_Enter(object sender, EventArgs e)
        {
            txtSenha0x1.SelectAll();
        }

        private void txtSenha0x2_Enter(object sender, EventArgs e)
        {
            txtSenha0x2.SelectAll();
        }

        private void txtSenha1x0_Enter(object sender, EventArgs e)
        {
            txtSenha1x0.SelectAll();
        }

        private void txtSenha1x1_Enter(object sender, EventArgs e)
        {
            txtSenha1x1.SelectAll();
        }

        private void txtSenha1x2_Enter(object sender, EventArgs e)
        {
            txtSenha1x2.SelectAll();
        }

        private void txtSenha2x0_Enter(object sender, EventArgs e)
        {
            txtSenha2x0.SelectAll();
        }

        private void txtSenha2x1_Enter(object sender, EventArgs e)
        {
            txtSenha2x1.SelectAll();
        }

        private void txtSenha2x2_Enter(object sender, EventArgs e)
        {
            txtSenha2x2.SelectAll();
        }

        private void txtSenhaMestre_Click(object sender, EventArgs e)
        {
            if (txtSenhaMestre.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Mestre[0, 0].ToString() + "\t" + Senha_Mestre[0, 1].ToString() + "\t" + Senha_Mestre[0, 2].ToString() + "\n" +
                    Senha_Mestre[1, 0].ToString() + "\t" + Senha_Mestre[1, 1].ToString() + "\t" + Senha_Mestre[1, 2].ToString() + "\n" +
                    Senha_Mestre[2, 0].ToString() + "\t" + Senha_Mestre[2, 1].ToString() + "\t" + Senha_Mestre[2, 2].ToString(), "Senha Mestre"
                );
            }
        }

        private void txtSenhaCriptografia_Click(object sender, EventArgs e)
        {
            if (txtSenhaCriptografia.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Criptografia[0, 0].ToString() + "\t" + Senha_Criptografia[0, 1].ToString() + "\t" + Senha_Criptografia[0, 2].ToString() + "\n" +
                    Senha_Criptografia[1, 0].ToString() + "\t" + Senha_Criptografia[1, 1].ToString() + "\t" + Senha_Criptografia[1, 2].ToString() + "\n" +
                    Senha_Criptografia[2, 0].ToString() + "\t" + Senha_Criptografia[2, 1].ToString() + "\t" + Senha_Criptografia[2, 2].ToString(), "Senha Criptografia"
                );
            }
        }

        private void txtMatrizTransposta_Click(object sender, EventArgs e)
        {
            if (txtSenhaTransposta.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Transposta[0, 0].ToString() + "\t" + Senha_Transposta[0, 1].ToString() + "\t" + Senha_Transposta[0, 2].ToString() + "\n" +
                    Senha_Transposta[1, 0].ToString() + "\t" + Senha_Transposta[1, 1].ToString() + "\t" + Senha_Transposta[1, 2].ToString() + "\n" +
                    Senha_Transposta[2, 0].ToString() + "\t" + Senha_Transposta[2, 1].ToString() + "\t" + Senha_Transposta[2, 2].ToString(), "Senha Transposta"
                );
            }
        }

        private void txtSenhaCofatora_Click(object sender, EventArgs e)
        {
            if (txtSenhaCofatora.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Cofatora[0, 0].ToString() + "\t" + Senha_Cofatora[0, 1].ToString() + "\t" + Senha_Cofatora[0, 2].ToString() + "\n" +
                    Senha_Cofatora[1, 0].ToString() + "\t" + Senha_Cofatora[1, 1].ToString() + "\t" + Senha_Cofatora[1, 2].ToString() + "\n" +
                    Senha_Cofatora[2, 0].ToString() + "\t" + Senha_Cofatora[2, 1].ToString() + "\t" + Senha_Cofatora[2, 2].ToString(), "Senha Cofatora"
                );
            }
        }

        private void txtSenhaInversa_Click(object sender, EventArgs e)
        {
            if (txtSenhaInversa.Text != "")
            {
                MessageBox.Show
                (
                    Senha_Inversa[0, 0].ToString() + "\t" + Senha_Inversa[0, 1].ToString() + "\t" + Senha_Inversa[0, 2].ToString() + "\n" +
                    Senha_Inversa[1, 0].ToString() + "\t" + Senha_Inversa[1, 1].ToString() + "\t" + Senha_Inversa[1, 2].ToString() + "\n" +
                    Senha_Inversa[2, 0].ToString() + "\t" + Senha_Inversa[2, 1].ToString() + "\t" + Senha_Inversa[2, 2].ToString(), "Senha Inversa"
                );
            }
        }

        private void txtSenhaDescriptografia_Click(object sender, EventArgs e)
        {
            if (txtSenhaDescriptografia.Text != "")
            {
                MessageBox.Show
                (
                    Math.Round(Senha_Descriptografia[0, 0], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[0, 1], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[0, 2], 0).ToString() + "\n" +
                    Math.Round(Senha_Descriptografia[1, 0], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[1, 1], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[1, 2], 0).ToString() + "\n" +
                    Math.Round(Senha_Descriptografia[2, 0], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[2, 1], 0).ToString() + "\t" + Math.Round(Senha_Descriptografia[2, 2], 0).ToString(), "Senha Descriptografia"
                );
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Zerar_Parcial();

            Random Randômico = new Random();

            for (int l = 0; l <= 2; l++)
            {
                for (int c = 0; c <= 2; c++)
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

