using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.BLL;
using Consultas_medicas.DAO;
using Consultas_medicas.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace Consultas_medicas.Formularios
{
    public partial class Form_tipo_pagamento : Form
    {
        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void Barra_Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        public Form_tipo_pagamento()
        {
            InitializeComponent();
            //ListarTipoPagamento();
        }

        public Form_tipo_pagamento(String valor)
        {         
            InitializeComponent();
            ListarTipoPagamento();
            txt_total_pagar.Text = valor;
        }

        
        private void btn_efetuar_pagamento_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ListarTipoPagamento()
        {
            ComprasBLL comprasBll = new ComprasBLL();
            this.cb_forma_pagamento.ValueMember = "cod_pagamento";
            this.cb_forma_pagamento.DisplayMember = "nome_pagamento";
            this.cb_forma_pagamento.DataSource = comprasBll.MostrarTipoPagamentoCombobox();
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_troco_Click(object sender, EventArgs e)
        {

        }

        public void CalcularTroco()
        {
            try
            {
                double troco = 0.0, total = 0.0, dinheiro = 0.0;
                dinheiro = Convert.ToDouble(txt_dinheiro.Text);
                total = Convert.ToDouble(txt_total_pagar.Text);

                troco = (total - dinheiro) * -1;
                txt_troco.Text = Convert.ToString(troco);

                if (troco < 0)
                {
                    btn_efetuar_pagamento.Enabled = false;
                    MessageBox.Show("Verifique o valor");
                }

                if (troco > 0)
                {
                    btn_efetuar_pagamento.Enabled = true;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao calcular troco" + erro.Message);
            }

        }

        private void txt_dinheiro_Leave(object sender, EventArgs e)
        {
            
        }

        private void txt_dinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularTroco();
                btn_efetuar_pagamento.Focus();
            }
        }

        private void Form_tipo_pagamento_Load(object sender, EventArgs e)
        {
            btn_efetuar_pagamento.Enabled = false;
        }

        private void txt_total_pagar_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita tecla delete
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void txt_total_pagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }

            //não aceita letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }

            //não aceita números
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt_troco_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }

            //não aceita letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }

            //não aceita números
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt_troco_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita tecla delete
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

       /*public DialogResult Result { get; private set; }

        public static DialogResult Mostrar(string pagar)
        {
            var msgBox = new Form_tipo_pagamento();
            msgBox.txt_total_pagar.Text = pagar;
            msgBox.ShowDialog();
            return msgBox.Result;
        }*/

    }
}
