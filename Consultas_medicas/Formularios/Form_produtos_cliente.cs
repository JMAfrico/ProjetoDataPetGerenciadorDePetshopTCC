using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.BLL;
using Consultas_medicas.DAO;
using Consultas_medicas.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.xml;
using iTextSharp.awt;
using iTextSharp.xmp;
using System.IO;
using System.Diagnostics;

namespace Consultas_medicas.Formularios
{
    public partial class Form_produtos_cliente : Form
    {
        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        //string de conexão
        string strconecta = "server=localhost;user=root;database=petshop_2020;port=3306;pwd = ;";//NOTEBOOK
        MySqlConnection conection = null;
        MySqlCommand comando = null;


        public Form_produtos_cliente()
        {
            InitializeComponent();
            rd_semCliente.Checked = true;
            txtPesquisar.Focus();
            TotalVendas();

        }

        private void Form_produtos_cliente_Load(object sender, EventArgs e)
        {
            listarNumCompra();
            //listarProdutosCliente();
            ListarTipoPagamento();
            tipoCompra();
            CabecalhoListas();
            //carregarProdutos();
            lbl_data.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtPesquisar.Focus();
            TotalVendas();
            btn_exportPDF_itensCliente.Enabled = false;
            btn_export_itensCliente.Enabled = false;
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Barra_Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void cb_veterinario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void listarClientes()
        {
            ClienteBLL clienteBll = new ClienteBLL();
            this.cb_cliente.ValueMember = "CodCliente";
            this.cb_cliente.DisplayMember = "nomeCliente";
            this.cb_cliente.DataSource = clienteBll.listarCliCombobox();
            
        }

        public void listarNumCompra()
        {
            ComprasBLL comprasbll = new ComprasBLL();
            this.cb_cod_compra.ValueMember = "cod_compra";
            this.cb_cod_compra.DisplayMember = "cod_compra";
            this.cb_cod_compra.DataSource = comprasbll.MostrarIDcompraCombobox();
            
        }

        private void ListarTipoPagamento()
        {
            ComprasBLL comprasBll = new ComprasBLL();
            this.cb_forma_pagamento.ValueMember = "cod_pagamento";
            this.cb_forma_pagamento.DisplayMember = "nome_pagamento";
            this.cb_forma_pagamento.DataSource = comprasBll.MostrarTipoPagamentoCombobox();
        }


        public void tipoCompra()
        {
            if (rd_comCliente.Checked == true)
            {
                listarClientes();
            }

            if (rd_semCliente.Checked == true)
            {
                listarClientes();
                cb_cliente.Enabled = false;
                cb_cliente.Text = "COMPRA SEM CLIENTE";
            }
        }

        private void rd_comCliente_CheckedChanged(object sender, EventArgs e)
        {
            cb_cliente.Enabled = true;
            listarClientes();
        }

        private void rd_semCliente_CheckedChanged(object sender, EventArgs e)
        {
            cb_cliente.Enabled = false;
            cb_cliente.SelectedIndex = -1;
        }

        private void btn_cad_cliente_Click(object sender, EventArgs e)
        {
            Form_cliente novo = new Form_cliente();
            novo.Show();
            this.Close();
        }

        //CRIA O TITULO DAS COLUNAS DAS TABELAS
        public void CabecalhoListas()
        {
            listview_produtos.Columns.Add("Código", 70, HorizontalAlignment.Left);
            listview_produtos.Columns.Add("Produto", 280, HorizontalAlignment.Left);
            listview_produtos.Columns.Add("Preço", 70, HorizontalAlignment.Left);
            listview_produtos.View = View.Details;
            listview_cliente.Columns.Add("Código", 70, HorizontalAlignment.Left);
            listview_cliente.Columns.Add("Produto", 280, HorizontalAlignment.Left);
            listview_cliente.Columns.Add("Preço", 70, HorizontalAlignment.Left);
            listview_cliente.Columns.Add("Quant", 70, HorizontalAlignment.Left);
            listview_cliente.View = View.Details;
        }

        //CARREGA OS PRODUTOS DA TABELA DO MYSQL NA LISTVIEW
        public void carregarProdutos(){

            try
            {

                DataSet ds = new DataSet();
                DataTable dtservico = new DataTable();
                MySqlDataAdapter da;
                

                AbrirConexao();
                comando = new MySqlCommand("SELECT * from tb_produtos", conection);
                da = new MySqlDataAdapter(comando);
                da.Fill(ds, "TABELA");


                dtservico = ds.Tables["TABELA"];
                int i;
                for (i = 0; i < dtservico.Rows.Count; i++)
                {
                    listview_produtos.Items.Add(dtservico.Rows[i].ItemArray[0].ToString());//linha 1 coluna 1
                    listview_produtos.Items[i].SubItems.Add(dtservico.Rows[i].ItemArray[1].ToString());//linha 1 coluna 2
                    listview_produtos.Items[i].SubItems.Add(dtservico.Rows[i].ItemArray[2].ToString());//linha 1 coluna 3               
                }

            }
            catch (Exception)
            {
                     MessageBox.Show("Erro ao carregar Lista de produtos");
            }
            finally 
            { 
                     FecharConexao();
            }
        }        
    



        //método que abre a conexão com o banco de dados
        public void AbrirConexao()
        {
            try
            {
                conection = new MySqlConnection(strconecta);
                conection.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //método que fecha a conexão com o banco de dados
        public void FecharConexao()
        {
            try
            {
                conection = new MySqlConnection(strconecta);
                conection.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void btn_carregar_produtos_Click(object sender, EventArgs e)
        {
            
        }

        //duplo clique na linha e adicionar na lista do cliente
        private void listview_produtos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            adicionarNaListaCliente();
            calcular();
            

            /*for(int i = 1; i < listview_cliente.Items.Count; i++)
            {
                lbl_verificar.Text = listview_cliente.Items[i].SubItems[1].Text;
            }*/

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //clicar no botão e adicionar na lista do cliente
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            btn_add_produto.BackColor = Color.Green;
            adicionarNaListaCliente();
            calcular();
        }

        //CALCULA A QUANTIDADE DE ITENS E O VALOR TOTAL DA LISTA DO CLIENTE
        private void calcular()
        {
            double total = 0.0;

            for (int i = 0; i < listview_cliente.Items.Count; i++)
            {
                total = total + Convert.ToDouble(listview_cliente.Items[i].SubItems[2].Text);
                
            }
           
            lbl_total_produtos.Text = Convert.ToString(total);
            lbl_quantidade_produtos.Text = Convert.ToString(listview_cliente.Items.Count);
            

        }

        //ADICIONA O ITEM SELECIONADO NA TABELA DO CLIENTE
        private void adicionarNaListaCliente()
        {
            //cada vez que seleciono o item da lista de produtos, copia para a lista do cliente
            foreach (ListViewItem item in listview_produtos.Items)
            {

                if (item.Selected)
                {
                    listview_cliente.Items.Add((ListViewItem)item.Clone());
                }
     
            }
            //cada vez que dou enter no produto, o foco do mouse vai pra pesquisar o produto
            txtPesquisar.Focus();
        }


        private void btn_add_produto_MouseLeave(object sender, EventArgs e)
        {
            //btn_add_produto.ForeColor = Color.Lime;
            btn_add_produto.BackColor = Color.FromArgb(23, 32, 40);
        }

        private void btn_add_produto_MouseHover(object sender, EventArgs e)
        {
            btn_add_produto.ForeColor = Color.Blue;
            btn_add_produto.BackColor = Color.White;
        }

        private void btn_add_produto_MouseDown(object sender, MouseEventArgs e)
        {
            //btn_add_produto.ForeColor = Color.Green;
            //btn_add_produto.BackColor = Color.Green;
        }



        //Método que salva a consulta
        private void salvar(ProdutosCliente produtoscliente)//novo
        {
            try
            {
                
                ProdutosClienteBLL produtoCliBLL = new ProdutosClienteBLL();
                int i;

                string[] cod_compra = new string[listview_cliente.Items.Count];//novo
                string[] produto = new string[listview_cliente.Items.Count];
                string[] idCliente = new string[listview_cliente.Items.Count];
                DateTime[] iddata = new DateTime[listview_cliente.Items.Count];
                DateTime[] idhora = new DateTime[listview_cliente.Items.Count];
                //string cod_compra = cb_cod_compra.Text.ToString();
                //produtoscliente.cod_compra = Convert.ToInt32(cod_compra);

                for (i = 0; i < listview_cliente.Items.Count; i++)
                {
                    cod_compra[i] = cb_cod_compra.Text.ToString();//novo
                    produto[i] = listview_cliente.Items[i].SubItems[0].ToString().Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "");
                    idCliente[i] = cb_cliente.SelectedValue.ToString();
                    iddata[i] = Convert.ToDateTime(lbl_data.Text);
                    idhora[i] = Convert.ToDateTime(lbl_hora.Text);
                }

                for (i = 0; i < listview_cliente.Items.Count; i++)
                {
                  
                    produtoscliente.cod_produto = Convert.ToInt32(produto[i]);                                    
                    produtoscliente.cod_cliente = Convert.ToInt32(idCliente[i]);
                    produtoscliente.data_compra = Convert.ToDateTime(iddata[i]);
                    produtoscliente.hora_compra = Convert.ToDateTime(idhora[i]);
                    produtoscliente.total_compra = lbl_total_produtos.Text;
                    produtoscliente.cod_compra = Convert.ToInt32(cod_compra[i]);//novo
                    produtoCliBLL.salvar(produtoscliente);
                }
                listarProdutosCliente();
                limparCampos();
                   //string idCliente = cb_cliente.SelectedValue.ToString();                     
                MessageBox.Show("Compra efetuada com sucesso. !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível salvar\n"+erro.Message);
                
            }
        }

        private void calcularTroco()
        {
            if (cb_forma_pagamento.Text == "DINHEIRO")
            {
                String valor = lbl_total_produtos.Text;
                DialogResult resultado = new DialogResult();
                Form_tipo_pagamento pag = new Form_tipo_pagamento(valor);
                resultado = pag.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    if (MessageBox.Show("Confirmar compra ?", "NOVA COMPRA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        salvaIDcompra();
                        ProdutosCliente produtosCliente = new ProdutosCliente();
                        Compra compras = new Compra();
                        salvar(produtosCliente);
                    }
                }
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (listview_cliente.Items.Count == 0)
            {
                MessageBox.Show("Selecione ao menos 1 item");
            }
            else
            {
                calcularTroco();

                if (cb_forma_pagamento.Text != "DINHEIRO")
                {
                    if (MessageBox.Show("Confirmar compra ?", "NOVA COMPRA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                        salvaIDcompra();
                    ProdutosCliente produtosCliente = new ProdutosCliente();
                    Compra compras = new Compra();
                    salvar(produtosCliente);
                }
            }
        }

        private void lbl_data_Click(object sender, EventArgs e)
        {
            //lbl_data.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void lbl_hora_Click(object sender, EventArgs e)
        {

        }

        private void listarProdutosCliente()
        {
            ProdutosClienteBLL prodClienteBLL = new ProdutosClienteBLL();
            dt_compras_efetuadas.DataSource = prodClienteBLL.listarProdutosdoCliente();

        }

        private void dt_compras_efetuadas_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Right)
            {
                // exibe o ContesteMenuStrip na posição do mouse dentro do gridcontrol
                //CRM.Show(gridControl1.PointToScreen(new Point(e.X, e.Y)));
                subMenu_cliqueDireito.Show(dt_compras_efetuadas.PointToScreen(new Point(e.X, e.Y)));

            }*/
        }

        private void visualizarDetalhesDaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    

        private void dt_compras_efetuadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_exportPDF_itensCliente.Enabled = true;
            btn_export_itensCliente.Enabled = true;
            lbl_num_compra.Text = dt_compras_efetuadas.CurrentRow.Cells[0].Value.ToString();
            lbl_nome_cliente.Text = dt_compras_efetuadas.CurrentRow.Cells[1].Value.ToString();
            lbl_total_geral.Text = dt_compras_efetuadas.CurrentRow.Cells[2].Value.ToString();
            lbl_data_compra_efetuada.Text = dt_compras_efetuadas.CurrentRow.Cells[3].Value.ToString().Substring(0,10);
            lbl_hora_compra_efetuada.Text = dt_compras_efetuadas.CurrentRow.Cells[4].Value.ToString();

            Clientes cliente = new Clientes();
            ProdutosCliente produtos = new ProdutosCliente();
            pesquisarProdutosCliente(cliente, produtos);

            dt_detalhes_compras.Columns["NOME"].Visible = false;
            dt_detalhes_compras.Columns["TOTAL"].Visible = false;
            dt_detalhes_compras.Columns["DATA"].Visible = false;
            dt_detalhes_compras.Columns["HORA"].Visible = false;
            TotalVendas();
        }

        

        public void TotalVendas()
        {

            double total;
            total = 0;
            foreach (DataGridViewRow data in dt_compras_efetuadas.Rows)
            {

                    total = total + Convert.ToDouble(data.Cells[2].Value);
                
            }
            lbl_TotalDasCompras.Text = Convert.ToString(total);
        }

        private void pesquisarProdutosCliente(Clientes cliente, ProdutosCliente produtos)
        {
            try
            {
                ProdutosClienteBLL produtosClienteBLL = new ProdutosClienteBLL();

                cliente.nomeCliente = lbl_nome_cliente.Text.Trim();
                produtos.data_compra = Convert.ToDateTime(lbl_data_compra_efetuada.Text.Trim());
                produtos.hora_compra = Convert.ToDateTime(lbl_hora_compra_efetuada.Text.Trim());


                dt_detalhes_compras.DataSource = produtosClienteBLL.pesquisarItensProdutosCliente(cliente,produtos);


            }
            catch (System.Exception erro)
            {
                throw erro;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quer mesmo cancelar ?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limparCampos();
            }
        }

        private void limparCampos()
        {
            listview_cliente.Items.Clear();
            lbl_quantidade_produtos.Text = "-";
            lbl_total_produtos.Text = "-";
            cb_cliente.Text = "COMPRA SEM CLIENTE";
            
        }

        private void listview_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            //remove item da lista e subtraio valor total
            if (e.KeyCode == Keys.Delete)
            {
                listview_cliente.SelectedItems[0].Remove();

                double tot = 0.0;

                for (int i = 0; i < listview_cliente.Items.Count; i++)
                {
                    tot = tot - Convert.ToDouble(listview_cliente.Items[i].SubItems[2].Text);

                }

                lbl_total_produtos.Text = Convert.ToString(tot * -1);
                lbl_quantidade_produtos.Text = Convert.ToString(listview_cliente.Items.Count);
            }
        }

        private void rd_cliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_compras_cliente_TextChanged(object sender, EventArgs e)
        {

            if (rd_cliente.Checked == true)
            {
                if (txtPesquisa_compras_cliente.Text == "")
                {
                    ProdutosClienteBLL prodClienteBLL = new ProdutosClienteBLL();
                    dt_compras_efetuadas.DataSource = prodClienteBLL.listarProdutosdoCliente();
                }
                else
                {
                    Clientes clientes = new Clientes();
                    pesquisarNome(clientes);

                }
            }

            if (rd_cpf.Checked == true)
            {
                if (txtPesquisa_compras_cliente.Text == "")
                {
                    ProdutosClienteBLL prodClienteBLL = new ProdutosClienteBLL();
                    dt_compras_efetuadas.DataSource = prodClienteBLL.listarProdutosdoCliente();
                }
                else
                {
                    ProdutosCliente produtoCli = new ProdutosCliente();
                    pesquisarCod(produtoCli);
                }


            }
        }

        //MÉTODO PARA PESQUISAR COMPRA POR NOME CLIENTE
        private void pesquisarNome(Clientes clientes)
        {
            try
            {
                ProdutosClienteBLL produtosClieBll = new ProdutosClienteBLL();
                clientes.nomeCliente = txtPesquisa_compras_cliente.Text.Trim();

                dt_compras_efetuadas.DataSource = produtosClieBll.PesquisarComprasCliente(clientes);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar cliente por nome\n" + erro.Message);
            }
        }

        //MÉTODO PARA PESQUISAR COMPRA POR COD COMPRA
        private void pesquisarCod(ProdutosCliente produtoCli)
        {
            try
            {
                ProdutosClienteBLL produtosClieBll = new ProdutosClienteBLL();
                produtoCli.cod_compra = Convert.ToInt32(txtPesquisa_compras_cliente.Text.Trim());

                dt_compras_efetuadas.DataSource = produtosClieBll.PesquisarComprasClienteCod(produtoCli);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar cliente por cpf\n" + erro.Message);
            }
        }

        private void pesquisaProdutos()
        {
            listview_produtos.Items.Clear();
            carregarProdutos();
            string pesquisar = txtPesquisar.Text;

            //PESQUISA NA LISTVIEW O TEXTO DIGITADO,TRUE PARA INCLUIR SUBTEXT. 0 PARA ONDE INICIAR A PESQUISA E TRUE PARA TEXTOS RELACIONADOS
            ListViewItem item = listview_produtos.FindItemWithText(pesquisar, true, 0, true);
            
            
            if (item != null) {
                listview_produtos.Focus();
                //MessageBox.Show("Encontrado");
                //item.BackColor = Color.Gold;
                //item.ForeColor = Color.Black;
                item.Selected = true;
                item.Focused = true;
                txtPesquisar.Clear();

            }
            else
            {
                MessageBox.Show("Nao encontrado");
            }
                         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                {
                    pesquisaProdutos();
                }
        }

        private void listview_produtos_KeyDown(object sender, KeyEventArgs e)
        {
           
            adicionarNaListaCliente();
            calcular();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {


        }

        public void salvaIDcompra()
        {
            Compra compras = new Compra();
            ComprasBLL comprasBLL = new ComprasBLL();  //novo
            string idCompra = cb_cod_compra.SelectedValue.ToString();//novo
            string idTipoPagamento = cb_forma_pagamento.SelectedValue.ToString();
            compras.cod_pagamento = Convert.ToInt32(idTipoPagamento);
            compras.cod_compra = Convert.ToInt32(idCompra) + 1;//novo
            comprasBLL.salvar(compras);//novo           
            listarNumCompra();//novo
        }

        /*private void salvarPagamentoConsulta()
        {
            Consultas consultas = new Consultas();
            ConsultaBLL consultasBll = new ConsultaBLL();

        }*/

        private void rd_semCliente_Click(object sender, EventArgs e)
        {
            cb_cliente.Text = "COMPRA SEM CLIENTE";
        }

        private void cb_forma_pagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_forma_pagamento_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void Form_produtos_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                if (listview_cliente.Items.Count == 0)
                {
                    MessageBox.Show("Selecione ao menos 1 item");
                }
                else
                {
                    calcularTroco();

                    if (cb_forma_pagamento.Text != "DINHEIRO")
                    {
                        if (MessageBox.Show("Confirmar compra ?", "NOVA COMPRA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            salvaIDcompra();
                        ProdutosCliente produtosCliente = new ProdutosCliente();
                        Compra compras = new Compra();
                        salvar(produtosCliente);
                    }
                }
            }
        }

        //EXPORTAR PARA O EXCEL
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
        

        private void exportaExcelTodasCompras()
        {
            if (dt_compras_efetuadas.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            
            else
            {
                try
                {                   
                    //XcelApp.Cells[1, 2] = lbl_num_compra.Text;
                    //XcelApp.Cells[1, 2] = "LISTA GERAL DE COMPRAS EFETUADAS";
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dt_compras_efetuadas.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dt_compras_efetuadas.Columns[i-1].HeaderText;//LINHA
                    }
                    //
                    for (int i = 0; i <= dt_compras_efetuadas.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dt_compras_efetuadas.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dt_compras_efetuadas.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //
                    //XcelApp.get_Range
                    XcelApp.Columns.AutoFit();
                    
                    //
                    XcelApp.Visible = true;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

        private void btn_export_excel_Click(object sender, EventArgs e)
        {
            exportaExcelTodasCompras();
        }

        private void exportaExcelItensCliente()
        {
            if (dt_compras_efetuadas.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }

            else
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dt_detalhes_compras.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dt_detalhes_compras.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i <= dt_detalhes_compras.Rows.Count -1 ; i++)
                    {
                        for (int j = 0; j < dt_detalhes_compras.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dt_detalhes_compras.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

        private void btn_export_itensCliente_Click(object sender, EventArgs e)
        {
            exportaExcelItensCliente();
        }

        private void exportarPDFTodasCompras(DataGridView dt, String strPDF, string strHead)
        {
            try {

                    System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
                    Document doc = new Document();
                    doc.SetPageSize(iTextSharp.text.PageSize.A2);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    //CABEÇALHO
                    BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 22, 1, iTextSharp.text.BaseColor.BLACK);
                    Paragraph paragrafo = new Paragraph();
                    paragrafo.Alignment = Element.ALIGN_CENTER;
                    paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
                    doc.Add(paragrafo);

                    //DADOS
                    Paragraph autor = new Paragraph();
                    BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
                    autor.Alignment = Element.ALIGN_LEFT;
                    autor.Add(new Chunk("Autor : JOAO MARCOS", Fontautor));
                    //autor.Add(new Chunk("\nCliente : " + lbl_nome_cliente.Text, Fontautor));
                    autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
                    //autor.Add(new Chunk("\nTotal:" + lbl_total_geral.Text, Fontautor));
                    autor.Add(new Chunk("\nQuantidade compras:" + dt_compras_efetuadas.RowCount, Fontautor));
                    autor.Add(new Chunk("\nTotal :" + lbl_TotalDasCompras.Text, Fontautor));

                    autor.Add(new Chunk(" " + "", Fontautor));
                    doc.Add(autor);

                    //
                    doc.Add(new Chunk("\n", fntHead));

                    //TABELA
                    PdfPTable pdfTable = new PdfPTable(dt_compras_efetuadas.ColumnCount);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 50;
                    pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    pdfTable.DefaultCell.BorderWidth = 1;

                    foreach (DataGridViewColumn column in dt_compras_efetuadas.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                        pdfTable.AddCell(cell);

                    }

                    //Adding DataRow
                    foreach (DataGridViewRow row in dt_compras_efetuadas.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();
                    writer.Close();
                    fs.Close();
                

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao gerar PDF\n"+erro);
            }

        }

        private void exportarPDFItensCliente(DataGridView dt, String strPDF, string strHead)
        {
            try
            {
                System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize.A2);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                //CABEÇALHO
                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 22, 1, iTextSharp.text.BaseColor.BLACK);
                Paragraph paragrafo = new Paragraph();
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
                doc.Add(paragrafo);

                //DADOS
                Paragraph autor = new Paragraph();
                BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
                autor.Alignment = Element.ALIGN_LEFT;
                autor.Add(new Chunk("Autor : JOAO MARCOS", Fontautor));
                autor.Add(new Chunk("\nCliente : " + lbl_nome_cliente.Text, Fontautor));
                autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
                autor.Add(new Chunk("\nTotal:" + lbl_total_geral.Text, Fontautor));
                autor.Add(new Chunk("\nQuantidade de itens:" + dt_detalhes_compras.RowCount, Fontautor));
                autor.Add(new Chunk(" " + "", Fontautor));
                doc.Add(autor);

                //
                doc.Add(new Chunk("\n", fntHead));

                //TABELA
                PdfPTable pdfTable = new PdfPTable(dt_detalhes_compras.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 50;
                pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                pdfTable.DefaultCell.BorderWidth = 1;

                foreach (DataGridViewColumn column in dt_detalhes_compras.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);

                }

                //Adding DataRow
                foreach (DataGridViewRow row in dt_detalhes_compras.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }

                doc.Add(pdfTable);
                doc.Close();
                writer.Close();
                fs.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao gerar PDF" + erro);
            }
                
        }

        

        private void btn_export_pdf_tudo_Click(object sender, EventArgs e)
        {
            if (dt_compras_efetuadas.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            else
            {
                TotalVendas();
                String dia = Convert.ToString(DateTime.Now.Day);
                String mes = Convert.ToString(DateTime.Now.Month);
                String ano = Convert.ToString(DateTime.Now.Year);
                String hora = Convert.ToString(DateTime.Now.Hour);
                String minuto = Convert.ToString(DateTime.Now.Minute);
                String segundo = Convert.ToString(DateTime.Now.Second);

                exportarPDFTodasCompras(dt_detalhes_compras, @"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RCompras" + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf", "Relatório de Compras do Cliente");
                System.Diagnostics.Process.Start(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RCompras" + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf");
                string docImpressao = "J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RCompras" + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf";
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }

 
        }

        private void btn_exportPDF_itensCliente_Click(object sender, EventArgs e)
        {
            if (dt_compras_efetuadas.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            else
            {

                String dia = Convert.ToString(DateTime.Now.Day);
                String mes = Convert.ToString(DateTime.Now.Month);
                String ano = Convert.ToString(DateTime.Now.Year);
                String hora = Convert.ToString(DateTime.Now.Hour);
                String minuto = Convert.ToString(DateTime.Now.Minute);
                String segundo = Convert.ToString(DateTime.Now.Second);

                exportarPDFItensCliente(dt_detalhes_compras, @"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RCliente" + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf", "Relatório de Compras do Cliente");
                System.Diagnostics.Process.Start(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RCliente" + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf");
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
        }

        private void testeImpressao(DataGridView dt,String strPDF, string strHead)
        {
            System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            doc.SetPageSize(iTextSharp.text.PageSize.A2);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //CABEÇALHO
            BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 22, 1,iTextSharp.text.BaseColor.BLACK);
            Paragraph paragrafo = new Paragraph();
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
            doc.Add(paragrafo);

            //DADOS
            Paragraph autor = new Paragraph();
            BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
            autor.Alignment = Element.ALIGN_LEFT;
            autor.Add(new Chunk("Autor : JOAO MARCOS", Fontautor));
            autor.Add(new Chunk("\nCliente : "+lbl_nome_cliente.Text, Fontautor));
            autor.Add(new Chunk("\nData do Relatório:" +DateTime.Now,Fontautor));
            autor.Add(new Chunk("\nTotal:" + lbl_total_geral.Text, Fontautor));
            autor.Add(new Chunk("\nQuantidade de itens:" + dt_detalhes_compras.RowCount, Fontautor));
            autor.Add(new Chunk(" " +"", Fontautor));
            doc.Add(autor);

            //
            doc.Add(new Chunk("\n", fntHead));

            //TABELA
            PdfPTable pdfTable = new PdfPTable(dt_detalhes_compras.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 50;
            pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dt_detalhes_compras.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);

            }

            //Adding DataRow
            foreach (DataGridViewRow row in dt_detalhes_compras.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }
            
            doc.Add(pdfTable);
            doc.Close();
            writer.Close();
            fs.Close();
            


        }

        private void dt_compras_efetuadas_DataSourceChanged(object sender, EventArgs e)
        {
           //TotalVendas();
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_carregar_produtos_Click_1(object sender, EventArgs e)
        {
            carregarProdutos();
        }

        private void btn_buscar_historico_Click(object sender, EventArgs e)
        {
            listarProdutosCliente();
        }
    }
}
