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
using Ferramentas;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Consultas_medicas
{
    using WebServiceCorreios;

    
    public partial class Form_cliente : Form 
    {
        

        public Form_cliente()
        {	
            InitializeComponent();       
            listarClientes();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            
        }

        private void Form_paciente_Load(object sender, EventArgs e)
        {
            listarClientes();
            rd_cliente.Checked = true;
            msg.SetToolTip(img_help, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n" +
            "Para pesquisar digite no campo de pesquisa");
        }

        private void LocalizaCep(string cep)
        {
            try
            {
                using (var ws = new AtendeClienteClient())
                {
                    var resposta = ws.consultaCEP(cep);

                    txtEndereco.Text = resposta.end;
                    txtBairro.Text = resposta.bairro;
                    txt_cidade.Text = resposta.cidade;
                    txt_estado.Text = resposta.uf;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Atenção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            /*Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;*/
            if (MessageBox.Show("Quer mesmo cancelar ?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limparCampos();
                modoNormal();
                btn_deletar.Enabled = false;
                btn_editar.Enabled = false;
                btn_salvar_medico.Enabled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
		
        //Método para movimentar a tela
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

		
        //método para limpar os campos depois de preenchidos
		private void limparCampos()
		{
			
				txtcodCliente.Clear();
				txtNome.Clear();
				txtEmail.Clear();
				txttelCelular.Clear();
				txtelFixo.Clear();
				txtEndereco.Clear();
				txtNumero.Clear();
                txtBairro.Clear();
                txt_cidade.Clear();
                txt_estado.Clear();
                txtCep.Clear();
                txtComplemento.Clear();
                txtCPF2.Clear();
                txt_referencia_cliente.Clear();
            
        }


        //Método para salvar cliente no banco de dados
        private void salvar(Clientes clientes)
        {
            try
            {
                if (txtNome.Text.Trim() == string.Empty ||
                    txtEmail.Text.Trim() == string.Empty ||
                    txttelCelular.Text.Trim() == string.Empty ||
                    txtelFixo.Text.Trim() == string.Empty ||
                    txtEndereco.Text.Trim() == string.Empty ||
                    txtNumero.Text.Trim() == string.Empty ||
                    txtBairro.Text.Trim() == string.Empty ||
                    txtCep.Text.Trim() == string.Empty ||
                    txtComplemento.Text.Trim() == string.Empty ||
                    txtCPF2.Text.Trim() == string.Empty ) 
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClienteBLL clienteBLL = new ClienteBLL();

                    clientes.nomeCliente = txtNome.Text;
                    clientes.emailCliente = txtEmail.Text;
                    clientes.telefoneCelularCli = Convert.ToInt64(txttelCelular.Text);
                    clientes.telefoneFixoCli = Convert.ToInt64(txtelFixo.Text);
                    clientes.enderecoCliente = txtEndereco.Text;
                    clientes.estadoCliente = txt_estado.Text;
                    clientes.cidadeCliente = txt_cidade.Text;
                    clientes.numeroResidenciaCliente = Convert.ToInt32(txtNumero.Text);
                    clientes.bairroCliente = txtBairro.Text;
                    clientes.cepCliente = txtCep.Text;
                    clientes.ComplementoCliente = txtComplemento.Text;
                    clientes.cpfCliente = txtCPF2.Text;
                    clientes.referencia_cliente = txt_referencia_cliente.Text;

                    clienteBLL.salvar(clientes);

                    MessageBox.Show("Cadastro de Cliente efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                    listarClientes();
                    lblCPF.Visible = false;
                }

            }
            catch(MySqlException erro)
            {
                MessageBox.Show("Já existe cliente associado a este CPF \n" + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                                       
        }

        //evento do botão salvar cliente no banco de dados
        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR CLIENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Clientes clientes = new Clientes();
                salvar(clientes);
            }
                  

        }

        //Método para editar cliente 
        private void editar(Clientes clientes)
        {
            try
            {
                if (txtNome.Text.Trim() == string.Empty ||
                    txtEmail.Text.Trim() == string.Empty || 
                    txttelCelular.Text.Trim() == string.Empty ||
                    txtEndereco.Text.Trim() == string.Empty ||
                    txtNumero.Text.Trim() == string.Empty ||
                    txtBairro.Text.Trim() == string.Empty ||
                    txtCep.Text.Trim() == string.Empty || 
                    txtComplemento.Text.Trim() == string.Empty ||
                    txtCPF2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                else
                {
                    ClienteBLL clienteBLL = new ClienteBLL();


                    clientes.CodCliente = Convert.ToInt32(txtcodCliente.Text);
                    clientes.nomeCliente = txtNome.Text;
                    clientes.emailCliente = txtEmail.Text;
                    clientes.telefoneCelularCli = Convert.ToInt64(txttelCelular.Text);
                    clientes.telefoneFixoCli = Convert.ToInt64(txtelFixo.Text);
                    clientes.enderecoCliente = txtEndereco.Text;
                    clientes.estadoCliente = txt_estado.Text;
                    clientes.cidadeCliente = txt_cidade.Text;
                    clientes.numeroResidenciaCliente = Convert.ToInt32(txtNumero.Text);
                    clientes.bairroCliente = txtBairro.Text;
                    clientes.cepCliente = txtCep.Text;
                    clientes.ComplementoCliente = txtComplemento.Text;
                    clientes.cpfCliente = txtCPF2.Text;
                    clientes.referencia_cliente = txt_referencia_cliente.Text;


                    clienteBLL.editar(clientes);//modificado

                    MessageBox.Show("Alteração de Cliente efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                    btn_editar.Enabled = false;
                    btn_deletar.Enabled = false;
                    btn_salvar_medico.Enabled = true;
                    lblCPF.Visible = false;
                    listarClientes();
                    modoNormal();
                }
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //evento do botão para editar cliente
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração ?", "ALTERAR CLIENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Clientes clientes = new Clientes();
                editar(clientes);
            }

        }

        //método para deletar cliente
        private void excluir(Clientes clientes)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();

                clientes.CodCliente = Convert.ToInt32(txtcodCliente.Text);

                clienteBLL.excluir(clientes);//modificado

                MessageBox.Show("Cliente excluído com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_medico.Enabled = true;
                lblCPF.Visible = false;
                listarClientes();
                modoNormal();

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Permissão negada : Cliente não pode ser excluído \n " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //evento do botão para deletar cliente
        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar excluir cliente ?", "EXClUIR CLIENTE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Clientes clientes = new Clientes();
                excluir(clientes);
            }
        }

        //evento do botão para listar clientes
        private void listarClientes()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            dtCliente.DataSource = clienteBLL.listarClientes();

        }

        //evento do botão para pesquisar cliente, de acordo com o radio button selecionado
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (rd_cliente.Checked == true)
            {
                if (txtPesquisa.Text == "")
                {

                    ClienteBLL clienteBLL = new ClienteBLL();
                    dtCliente.DataSource = clienteBLL.listarClientes();
                }
                else
                {
                    Clientes clientes = new Clientes();
                    pesquisar(clientes);
                }
            }


            if (rd_cpf.Checked == true)
            {
                if (txtPesquisa.Text == "")
                {
                    ClienteBLL clienteBLL = new ClienteBLL();
                    dtCliente.DataSource = clienteBLL.listarClientes();
                }
                else
                {

                    Clientes clientes = new Clientes();
                    pesquisarPORCPF(clientes);
                }
            }
        }

        //método para pesquisar cliente por nome
        private void pesquisar(Clientes clientes)
        {
            try
            {
                clientes.nomeCliente = txtPesquisa.Text.Trim();
                ClienteBLL clienteBLL = new ClienteBLL();
                dtCliente.DataSource = clienteBLL.pesquisar(clientes);
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //método para pesquisar cliente por cpf
        private void pesquisarPORCPF(Clientes clientes)
        {
            try
            {

                clientes.cpfCliente = txtPesquisa.Text.Trim();
                ClienteBLL clienteBLL = new ClienteBLL();
                dtCliente.DataSource = clienteBLL.pesquisarCPF(clientes);
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }



        private void buscar(Clientes clientes)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txtAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //evento de duplo clique na tabela
        private void dtCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modoEdicao();
            btn_editar.Enabled = true;
            btn_deletar.Enabled = true;
            btn_salvar_medico.Enabled = false;

            lbl_nome.Text = dtCliente.CurrentRow.Cells[1].Value.ToString();
            lbl_cpf.Text = dtCliente.CurrentRow.Cells[2].Value.ToString();
            lbl_endereco.Text = dtCliente.CurrentRow.Cells[6].Value.ToString();
            lbl_cep.Text = dtCliente.CurrentRow.Cells[9].Value.ToString();
            lbl_bairro.Text = dtCliente.CurrentRow.Cells["BAIRRO"].Value.ToString();
            lbl_numero.Text = dtCliente.CurrentRow.Cells[11].Value.ToString();
            lbl_complemento.Text = dtCliente.CurrentRow.Cells["COMPLEMENTO"].Value.ToString();
            lbl_email.Text = dtCliente.CurrentRow.Cells[3].Value.ToString();
            lbl_fixo.Text = dtCliente.CurrentRow.Cells[5].Value.ToString();
            lbl_cel.Text = dtCliente.CurrentRow.Cells[4].Value.ToString();
            lblRef.Text = dtCliente.CurrentRow.Cells["REFERENCIA"].Value.ToString();
            lblCidade.Text = dtCliente.CurrentRow.Cells["CIDADE"].Value.ToString();
            lblEstado.Text = dtCliente.CurrentRow.Cells["ESTADO"].Value.ToString();


            txtcodCliente.Text = dtCliente.CurrentRow.Cells["CODIGO"].Value.ToString();
            txtNome.Text = dtCliente.CurrentRow.Cells[1].Value.ToString();
            txtCPF2.Text = dtCliente.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = dtCliente.CurrentRow.Cells[6].Value.ToString();
            txt_cidade.Text = dtCliente.CurrentRow.Cells["CIDADE"].Value.ToString();
            txt_estado.Text = dtCliente.CurrentRow.Cells["ESTADO"].Value.ToString();
            txtCep.Text = dtCliente.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = dtCliente.CurrentRow.Cells[10].Value.ToString();
            txtNumero.Text = dtCliente.CurrentRow.Cells[11].Value.ToString();
            txtComplemento.Text = dtCliente.CurrentRow.Cells[12].Value.ToString();
            txtEmail.Text = dtCliente.CurrentRow.Cells[3].Value.ToString();
            txtelFixo.Text = dtCliente.CurrentRow.Cells[5].Value.ToString();
            txttelCelular.Text = dtCliente.CurrentRow.Cells[4].Value.ToString();
            txt_referencia_cliente.Text = dtCliente.CurrentRow.Cells[13].Value.ToString();

        }



		


        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        //evento do botão que chama o método pesquisar CPF
        private void txtCPF2_Leave(object sender, EventArgs e)
        {
            if (txtCPF2.Text != "" || (txtCPF2.Text.Length >= 1 && txtCPF2.Text.Length < 11))
            {
                string validarCPF = txtCPF2.Text;

                if (Validacao.ValidaCPF(validarCPF))
                {
                    lblCPF.Visible = true;
                }
                else
                {
                    MessageBox.Show("CPF Inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCPF2.Clear();

                    txtCPF2.BackColor = Color.DimGray;

                }
            }
            
        }

        //evento do botão que chama o método pesquisar CEP
        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (txtCep.Text != "" || (txtCep.Text.Length >= 1 && txtCep.Text.Length < 8))
            {
                LocalizaCep(txtCep.Text);
            }
            else
            {
                MessageBox.Show("Cep Inválido, tente novamente");
            }
       
        }

        private void txtelFixo_Leave(object sender, EventArgs e)
        {
            if (txtelFixo.Text.Length >= 1 && txtelFixo.Text.Length < 10)
            {
                MessageBox.Show("Telefone inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtelFixo.Clear();
            }
        }

        private void txttelCelular_Leave(object sender, EventArgs e)
        {
            if (txttelCelular.Text.Length >= 1 && txttelCelular.Text.Length < 10)
            {
                MessageBox.Show("Celular inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txttelCelular.Clear();

            }
        }

        private void txtelFixo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtEndereco_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_cidade_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txtBairro_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_estado_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        public void modoEdicao()
        {
            //txt_nome_servico.BackColor = Color.Green;
            txtcodCliente.BackColor = Color.Green;
            txtNome.BackColor = Color.Green;
            txtCPF2.BackColor = Color.Green;
            txtEndereco.BackColor = Color.Green;
            txtBairro.BackColor = Color.Green;
            txtCep.BackColor = Color.Green;
            txtNumero.BackColor = Color.Green;
            txtComplemento.BackColor = Color.Green;
            txtEmail.BackColor = Color.Green;
            txtelFixo.BackColor = Color.Green;
            txttelCelular.BackColor = Color.Green;
            txt_cidade.BackColor = Color.Green;
            txt_estado.BackColor = Color.Green;
            txtEmail.BackColor = Color.Green;
            txt_referencia_cliente.BackColor = Color.Green;
        }

        public void modoNormal()
        {
            //txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            txtcodCliente.BackColor = Color.FromArgb(23, 32, 40);
            txtNome.BackColor = Color.FromArgb(23, 32, 40);
            txtCPF2.BackColor = Color.FromArgb(23, 32, 40);
            txtEndereco.BackColor = Color.FromArgb(23, 32, 40);
            txtBairro.BackColor = Color.FromArgb(23, 32, 40);
            txtCep.BackColor = Color.FromArgb(23, 32, 40);
            txtNumero.BackColor = Color.FromArgb(23, 32, 40);
            txtComplemento.BackColor = Color.FromArgb(23, 32, 40);
            txtEmail.BackColor = Color.FromArgb(23, 32, 40);
            txtelFixo.BackColor = Color.FromArgb(23, 32, 40);
            txttelCelular.BackColor = Color.FromArgb(23, 32, 40);
            txt_cidade.BackColor = Color.FromArgb(23, 32, 40);
            txt_estado.BackColor = Color.FromArgb(23, 32, 40);
            txtEmail.BackColor = Color.FromArgb(23, 32, 40);
            txt_referencia_cliente.BackColor = Color.FromArgb(23, 32, 40);

        }
    }
}
