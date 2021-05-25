using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Consultas_medicas.Models;
using Consultas_medicas.BLL;
using Consultas_medicas.DAO;
using MySql.Data.MySqlClient;

namespace Consultas_medicas
{
    public partial class Form_servicos : Form
    {
        public Form_servicos()
        {
            InitializeComponent();
            listarServicos();
            listarProdutos();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            btn_salvar.Enabled = true;
            btn_salvar_produto.Enabled = true;
            btn_editar_produto.Enabled = false;
            btn_deletar_produto.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //método lista os serviços no datasource(NA TABELA)
        private void listarServicos()
        {
            ServicosBLL servicosBLL = new ServicosBLL();
            dt_servicos.DataSource = servicosBLL.listarServicos();
            
        }

        //método lista os produtos no datasource(NA TABELA)
        private void listarProdutos()
        {
            ProdutosBLL produtosBll = new ProdutosBLL();
            dt_produtos.DataSource = produtosBll.listarProdutos();


        }

        private void Cad_consulta_Load(object sender, EventArgs e)
        {
            listarServicos();
            listarProdutos();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            btn_salvar.Enabled = true;
            btn_salvar_produto.Enabled = true;
            btn_editar_produto.Enabled = false;
            btn_deletar_produto.Enabled = false;
            msg.SetToolTip(img_help, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n"+
            "Para pesquisar digite no campo de pesquisa");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void salvar(Consultas consultas)
        {
            try
            {

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }



        private void listarConsultas()
        {


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

        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            //Menu_principal novo = new Menu_principal();
            //novo.Show();
            //this.Visible = false;
            if (MessageBox.Show("Quer mesmo cancelar ?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limpar();
                modoNormal();
                btn_deletar.Enabled = false;
                btn_editar.Enabled = false;
                btn_salvar.Enabled = true;
            }
        }

        //evento botão salvar
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salvar novo serviço?", "NOVO SERVIÇO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Servicos servicos = new Servicos();
                salvar(servicos);
            }
        }
        //Método para salvar servicos no banco de dados
        private void salvar(Servicos servico)
        {
            try
            {
                if (txt_nome_servico.Text == string.Empty || txt_preco.Text == string.Empty)
                    
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ServicosBLL servicoBLL= new ServicosBLL();

                    servico.nome_servico = txt_nome_servico.Text;
                    servico.preco_servico = txt_preco.Text;

                    servicoBLL.salvar(servico);

                    MessageBox.Show("Cadastro de serviço efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); listarServicos();
                    btn_editar.Enabled = false;
                    btn_deletar.Enabled = false;
                    btn_salvar.Enabled = true;
                    limpar();
                }

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Não foi possível salvar um novo serviço.\n"+erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void modoEdicao()
        {
            txt_nome_servico.BackColor = Color.Green;
            txt_preco.BackColor = Color.Green;
            txt_codigo_servico.BackColor = Color.Green;
            txt_cod_produto.BackColor = Color.Green;
            txt_nome_produto.BackColor = Color.Green;
            txt_preco_produto.BackColor = Color.Green;
        }

        public void modoNormal()
        {
            txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            txt_preco.BackColor = Color.FromArgb(23, 32, 40);
            txt_codigo_servico.BackColor = Color.FromArgb(23, 32, 40);
            txt_cod_produto.BackColor = Color.FromArgb(23, 32, 40);
            txt_nome_produto.BackColor = Color.FromArgb(23, 32, 40);
            txt_preco_produto.BackColor = Color.FromArgb(23, 32, 40);
        }


        //evento de botão para editar serviço
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Alterar serviço?", "ALTERAR SERVIÇO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Servicos servicos = new Servicos();
                editar(servicos);
            }
        }

        //método para editar serviços
        private void editar(Servicos servicos)
        {
            try
            {
                if (txt_nome_servico.Text == string.Empty || txt_preco.Text == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ServicosBLL servicosBLL = new ServicosBLL();

                    servicos.cod_servico = Convert.ToInt32(txt_codigo_servico.Text);
                    servicos.nome_servico = txt_nome_servico.Text;
                    servicos.preco_servico = txt_preco.Text;


                    servicosBLL.editar(servicos);

                    MessageBox.Show("Alteração de serviço efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); listarServicos();
                    btn_editar.Enabled = false;
                    btn_deletar.Enabled = false;
                    btn_salvar.Enabled = true;
                    limpar();
                    modoNormal();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento de botão excluir serviços
        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apagar serviço?", "DELETAR SERVIÇO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Servicos servicos = new Servicos();
                excluir(servicos);
            }
        }

        //método para EXCLUIR serviços
        private void excluir(Servicos servicos)
        {
            try
            {

                    ServicosBLL servicosBLL = new ServicosBLL();

                    servicos.cod_servico = Convert.ToInt32(txt_codigo_servico.Text);

                    servicosBLL.excluir(servicos);

                    MessageBox.Show("Serviço excluído com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarServicos();
                    btn_editar.Enabled = false;
                    btn_deletar.Enabled = false;
                    btn_salvar.Enabled = true;
                    limpar();
                    modoNormal();
                
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Não foi possível apagar o serviço.\n"+erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        //duplo clique na tabela de serviços
        private void dt_servicos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modoEdicao();
            btn_editar.Enabled = true;
            btn_deletar.Enabled = true;
            btn_salvar.Enabled = false;

            txt_codigo_servico.Text = dt_servicos.CurrentRow.Cells[0].Value.ToString();
            txt_nome_servico.Text = dt_servicos.CurrentRow.Cells[1].Value.ToString();
            txt_preco.Text = dt_servicos.CurrentRow.Cells[2].Value.ToString();

        }

        public void limpar()
        {
            txt_preco.Clear();
            txt_nome_servico.Clear();
            txt_codigo_servico.Clear();
        }

        public void limparProd()
        {
            txt_cod_produto.Clear();
            txt_nome_produto.Clear();
            txt_preco_produto.Clear();
        }

        //método para pesquisar servicos por nome
        private void pesquisarServicos(Servicos servicos)
        {
            try
            {
                servicos.nome_servico = txtPesquisaServico.Text.Trim();
                ServicosBLL servicosBll = new ServicosBLL();
                dt_servicos.DataSource = servicosBll.pesquisar(servicos);
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }
        //evento para digitar no txt e buscar o que foi digitado no banco de dados
        private void txtPesquisaServico_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtPesquisaServico.Text == "")
                {
                    ServicosBLL servicosBll = new ServicosBLL();
                    dt_servicos.DataSource = servicosBll.listarServicos();
                }
                else
                {
                    Servicos servicos = new Servicos();
                    pesquisarServicos(servicos);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao pesquisar");
            }
            
        }

        private void dt_produtos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modoEdicao();
            btn_editar_produto.Enabled = true;
            btn_deletar_produto.Enabled = true;
            btn_salvar_produto.Enabled = false;

            txt_cod_produto.Text = dt_produtos.CurrentRow.Cells[0].Value.ToString();
            txt_nome_produto.Text = dt_produtos.CurrentRow.Cells[1].Value.ToString();
            txt_preco_produto.Text = dt_produtos.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_cancelar_edicao_produto_Click(object sender, EventArgs e)
        {
            limparProd();
        }

        //Método para salvar PRODUTOS no banco de dados
        private void salvarProd(Produtos produtos)
        {
            try
            {
                if (txt_nome_produto.Text == string.Empty || txt_preco_produto.Text == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ProdutosBLL produtosBll = new ProdutosBLL();

                    produtos.nome_produto = txt_nome_produto.Text;
                    produtos.preco_produto = txt_preco_produto.Text;

                    produtosBll.salvar(produtos);

                    MessageBox.Show("Cadastro de produto efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); listarServicos();
                    btn_editar_produto.Enabled = false;
                    btn_deletar_produto.Enabled = false;
                    btn_salvar_produto.Enabled = true;
                    listarProdutos();
                    limparProd();
                }

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Não foi possível salvar um novo serviço.\n" + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_salvar_produto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salvar produto?", "SALVAR PRODUTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Produtos produto = new Produtos();
                salvarProd(produto);
            }
        }

        //método para editar PRODUTOS
        private void editarProd(Produtos produtos)
        {
            try
            {
                if (txt_nome_produto.Text == string.Empty || txt_preco_produto.Text == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ProdutosBLL produtosBll = new ProdutosBLL();

                    produtos.cod_produto = Convert.ToInt32(txt_cod_produto.Text);
                    produtos.nome_produto = txt_nome_produto.Text;
                    produtos.preco_produto = txt_preco_produto.Text;

                    produtosBll.editar(produtos);

                    MessageBox.Show("Alteração de produto efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); listarServicos();
                    btn_editar_produto.Enabled = false;
                    btn_deletar_produto.Enabled = false;
                    btn_salvar_produto.Enabled = true;
                    listarProdutos();
                    limparProd();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_produto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Editar produto?", "EDITAR PRODUTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Produtos produto = new Produtos();
                editarProd(produto);
            }
        }

        //método para EXCLUIR produtos
        private void excluirProd(Produtos produtos)
        {
            try
            {

                
                ProdutosBLL produtosBll = new ProdutosBLL();

                produtos.cod_produto = Convert.ToInt32(txt_cod_produto.Text);

                produtosBll.excluir(produtos);

                MessageBox.Show("Produto excluído com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarServicos();
                btn_editar_produto.Enabled = false;
                btn_deletar_produto.Enabled = false;
                btn_salvar_produto.Enabled = true;
                listarProdutos();
                limparProd();

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Não foi possível apagar o produto.\n" + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deletar_produto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deletar produto?", "DELETAR PRODUTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Produtos produto = new Produtos();
                excluirProd(produto);
            }
        }

        //método para pesquisar PRODUTOS por nome
        private void pesquisarProdutos(Produtos produtos)
        {
            try
            {
                produtos.nome_produto = txt_pesquisar_produto.Text.Trim();
                ProdutosBLL produtosBll = new ProdutosBLL();
                dt_produtos.DataSource = produtosBll.pesquisar(produtos);

            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //evento de botão para pesquisar
        private void txt_pesquisar_produto_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txt_pesquisar_produto.Text == "")
                {
                    ProdutosBLL produtosBll = new ProdutosBLL();
                    dt_produtos.DataSource = produtosBll.listarProdutos();
                }
                else
                {
                    Produtos produtos = new Produtos();
                    pesquisarProdutos(produtos);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao pesquisar");
            }
        }
    }
}
