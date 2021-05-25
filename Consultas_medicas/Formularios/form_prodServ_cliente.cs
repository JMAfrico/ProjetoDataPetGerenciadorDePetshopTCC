using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.DAO;
using Consultas_medicas.BLL;
using Consultas_medicas.Models;
using System.Runtime.InteropServices;


namespace Consultas_medicas
{
    public partial class form_prodServ_cliente : Form
    {
        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);





        public form_prodServ_cliente()
        {
            InitializeComponent();
            listarServicoCli();
            //dt_itens_servicos1.Columns["DATA"].Width = 1000;
            
            
        }

       

        public form_prodServ_cliente(String nome,DateTime data ,String cod, String preco, DateTime hora,String status)
        {           
            InitializeComponent();
            lbl_status_pagamento.Text = status;
            lbl_hora.Text = hora.ToString().Substring(11);
            lbl_nome_cliente.Text = nome;
            lbl_codigo.Text = cod;
            lbl_total_geral.Text = (preco);
            lbl_data.Text = data.ToString().Substring(0,10);
            listarServicoCli();
            txtCliente.Text = lbl_nome_cliente.Text;
            txtData.Text = lbl_data.Text;
            txt_cod.Text = lbl_codigo.Text;
            //converterdata();
            Clientes cliente = new Clientes();
            Consultas consultas = new Consultas();
            pesquisarCliente(cliente, consultas);
            //ListarTipoPagamento();
            txt_total_pagar.Enabled = false;
            txt_dinheiro.Enabled = false;
            txt_troco.Enabled = false;
            listarStatusPag();
            
            
        }

        private void converterdata(){
            DateTime dat = new DateTime();
            dat = Convert.ToDateTime(this.lbl_data.Text);
            MessageBox.Show(dat.ToString().Substring(0,10));
        }




        private void ListarTipoPagamento()
        {
            ComprasBLL comprasBll = new ComprasBLL();
            this.cb_forma_pagamento.ValueMember = "cod_pagamento";
            this.cb_forma_pagamento.DisplayMember = "nome_pagamento";
            this.cb_forma_pagamento.DataSource = comprasBll.MostrarTipoPagamentoCombobox();
        }
        
        private void form_prodServ_cliente_Load(object sender, EventArgs e)
        {
            //pesquisaData();
            

        }

        public void listarServicoCli()
        {
            ConsultaBLL consultasbll = new ConsultaBLL();
            dt_itens_servicos1.DataSource = consultasbll.listarItensServicoCliente();
        }


        private void pesquisarCliente(Clientes cliente,Consultas consultas)
        {
            try
            {
                ConsultaBLL consultasbll = new ConsultaBLL();

                cliente.nomeCliente = txtCliente.Text.Trim();
                consultas.dataConsulta = Convert.ToDateTime(txtData.Text.Trim());
                consultas.horaConsulta = Convert.ToDateTime(lbl_hora.Text.Trim());

                dt_itens_servicos1.DataSource = consultasbll.pesquisarItensServicoCliente(cliente,consultas);
           

            }
            catch (System.Exception erro)
            {
                throw erro;
            }

        }

        private void pesquisarData(Consultas consulta)
        {
           /* try
            {
                
                consulta.dataConsulta = Convert.ToDateTime(txtData.Text);

                ConsultaBLL consultasbll = new ConsultaBLL();

                dt_itens_servicos.DataSource = consultasbll.listarItensServicoClienteData(consulta);

            }
            catch (System.Exception erro)
            {
                throw erro;
            }*/

        }

        

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            /*if (txtCliente.Text != "")
            {
                Clientes cliente = new Clientes();
                Consultas consultas = new Consultas();
                pesquisarCliente(cliente,consultas);
            }*/

            /*if (txtData.Text != "")
            {
                Clientes cliente = new Clientes();
                Consultas consultas = new Consultas();
                pesquisarCliente(cliente, consultas);
            }*/
                          
        }

        private void lbl_nome_cliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            /*Consultas consulta = new Consultas();

            if (txtData.Text != "")
            {

                pesquisarData(consulta);
            }*/
        }

        private void txt_cod_TextChanged(object sender, EventArgs e)
        {

        }


        public void pesquisaData()
        {
            string pesquisar = txtData.Text;
            var indice = -1;

            foreach (DataGridViewRow row in dt_itens_servicos1.Rows)
            {

                if (row.Cells["DATA"].Value.ToString().Equals(pesquisar))
                {
                    row.Selected = true;
                    indice = row.Index;
                    MessageBox.Show("Data Localizada posição = " + indice);
                    break;
                }
            }
            
    
            if (indice != -1)//cliente encontrado, vai pra posição
            {
                dt_itens_servicos1.CurrentCell = dt_itens_servicos1.Rows[indice].Cells[0];
            }

            if (indice == -1)//cliente não encontrado, mostra mensagem
            {
                MessageBox.Show("Data não encontrada");              
            }
            //txtPesquisa.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Clientes cliente = new Clientes();
            Consultas consultas = new Consultas();
            pesquisarCliente(cliente, consultas);*/
            //DataGridViewRow row = dt_itens_servicos1.Rows[0];
            //row.Height = 50;
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

        private void cb_forma_pagamento_SelectedIndexChanged(object sender, EventArgs e)
        {

            //cb_forma_pagamento.SelectedValue = 2;

            if (cb_forma_pagamento.Text == "DINHEIRO")
            {
                txt_total_pagar.Text = lbl_total_geral.Text.Replace("R$ ","");
                txt_total_pagar.Enabled = true;
                txt_dinheiro.Enabled = true;
                txt_troco.Enabled = true;
            }

            if (cb_forma_pagamento.Text != "DINHEIRO")
            {
                txt_total_pagar.Text = string.Empty;
                txt_total_pagar.Enabled = false;
                txt_dinheiro.Enabled = false;
                txt_troco.Enabled = false;
            }
        }

        private void txt_dinheiro_Leave(object sender, EventArgs e)
        {
            double valor = Convert.ToDouble(txt_dinheiro.Text);
            if (valor > 0)
            {
                CalcularTroco();
                btn_efetuar_pagamento.Focus();
            }
        }

        private void cb_forma_pagamento_Click(object sender, EventArgs e)
        {
            ListarTipoPagamento();
        }

        private void txt_dinheiro_KeyDown(object sender, KeyEventArgs e)
        {           

            if (e.KeyCode == Keys.Enter)
            {
                double valor = Convert.ToDouble(txt_dinheiro.Text);
                if (valor > 0)
                {
                    CalcularTroco();
                    btn_efetuar_pagamento.Focus();
                }
            }
        }

        private void listarStatusPag()
        {
            StatusPagamentoBLL status = new StatusPagamentoBLL();

            this.cb_status_pagamento.ValueMember = "cod_status";
            this.cb_status_pagamento.DisplayMember = "nome_status";
            this.cb_status_pagamento.DataSource = status.MostrarStatusCombobox();
        }

        private void RealizarPagamento(ConsultasCliente consultasCliente)
        {
            try
            {
                ConsultasClienteBLL ConsultaClienteBll = new ConsultasClienteBLL();
               // ConsultaBLL consultaBLL = new ConsultaBLL();

                string idConsulta = lbl_codigo.Text;

                string idPagamento = cb_forma_pagamento.SelectedValue.ToString();

                consultasCliente.cod_consulta = Convert.ToInt32(idConsulta);
                consultasCliente.status_pagamento = 2;
                consultasCliente.tipo_pagamento = Convert.ToInt32(idPagamento);
                ConsultaClienteBll.editarPagamento(consultasCliente);
                MessageBox.Show("Pagamento efetuado com sucesso");
                this.Dispose();


            }catch(Exception erro)
            {
                throw erro;
            }
        }

        private void btn_efetuar_pagamento_Click(object sender, EventArgs e)
        {

                if (MessageBox.Show("Confirmar pagamento ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lbl_status_pagamento.Text.Equals("PAGO"))
                    {
                        MessageBox.Show("Essa consulta já foi paga","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ConsultasCliente consultasCliente = new ConsultasCliente();
                        RealizarPagamento(consultasCliente);
                    }
                    
                }
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
      
        }
        

    }
}
