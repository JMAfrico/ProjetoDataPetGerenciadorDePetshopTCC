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


namespace Consultas_medicas
{
    public partial class Form_busca_cliente : Form 
    {
        public Form_busca_cliente()
        {	
            InitializeComponent();
            listarClientes();

        }



        private void button1_Click(object sender, EventArgs e)
        {   //BOTÃO QUE AO SER ACIONADO MUDA DE FORMULÁRIO(NOVA INSTANCIA DE OBJETO) E TORNA INVISÍVEL E FORMULARIO ATUAL
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;//propriedade que torna inativo o formulário atual
            
			//------------------------------------------//------------------------------------------------//
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {//NADA
        }//////
		
			//MÉTODO 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
        
        private void salvar(Clientes clientes)
        {

                               
        }



        

        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {//método para selecionar cliente da lista de outro form. Crio uma sobrecarga de método e passo o valor
            //os dois paramentros são a colona um da tabela que é referente ao nome do cliente e a coluna 2 que é o cpf

            Menu_principal novo = new Menu_principal(dtCliente.CurrentRow.Cells[1].Value.ToString(), dtCliente.CurrentRow.Cells[0].Value.ToString(), dtCliente.CurrentRow.Cells[2].Value.ToString(),dtCliente.CurrentRow.Cells[3].Value.ToString(),dtCliente.CurrentRow.Cells[4].Value.ToString());
            novo.Show();
            this.Close();
    
        }

        private void listarClientes()
        {
            AnimalClienteBLL AnimalclienteBLL = new AnimalClienteBLL();
            dtCliente.DataSource = AnimalclienteBLL.EscolherClienteConsulta();

        }

        /*private void listarClientes()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            dtCliente.DataSource = clienteBLL.listarClientes();

        }*/

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form_paciente_Load(object sender, EventArgs e)
        {
            listarClientes();
            txtAnimal.SelectedIndex = -1;
            rd_cliente.Checked = true;
            msg.SetToolTip(img_help, "Para escolhe o cliente, clique sobre ele e aperte o botão selecionar\n ou \n"+
            "dê um duplo clique sobre ele");
             
        }

        private void buscar(Clientes clientes)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       /* private void txtPesquisa_TextChanged(object sender, EventArgs e)
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
                    AnimalClienteBLL animalClienteBLL = new AnimalClienteBLL();
                    dtCliente.DataSource = animalClienteBLL.EscolherClienteConsulta();
                }
                else
                {

                    Clientes clientes = new Clientes();
                    pesquisarPORCPF(clientes);
                }
            }
        }*/

        private void dtCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //método para selecionar cliente da lista de outro form. Crio uma sobrecarga de método e passo o valor
            //os dois paramentros são a colona um da tabela que é referente ao nome do cliente e a coluna 2 que é o cpf

            Menu_principal novo = new Menu_principal(dtCliente.CurrentRow.Cells[1].Value.ToString(), dtCliente.CurrentRow.Cells[0].Value.ToString(), dtCliente.CurrentRow.Cells[2].Value.ToString(),dtCliente.CurrentRow.Cells[3].Value.ToString(),dtCliente.CurrentRow.Cells[4].Value.ToString());
            novo.Show();
            this.Close();

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

			
        }
    

        

        public void pq()
        {

            string pesquisar = txtPesquisa.Text;
            var indice = -1;

            dtCliente.ClearSelection();

            if (rd_cliente.Checked == true)//pequisar por nome selecionada
            {
                dtCliente.ClearSelection();

                if (txtPesquisa.Text == string.Empty)
                {
                    MessageBox.Show("Campo pesquisa em branco","ERRO",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                 
                }

                foreach (DataGridViewRow row in dtCliente.Rows)
                {
                    if (row.Cells["CLIENTE"].Value != null)
                    {

                        if (row.Cells["CLIENTE"].Value.ToString().Equals(pesquisar))
                        {
                            row.Selected = true;
                            indice = row.Index;
                            MessageBox.Show("Cliente localizado! posição = "+ indice);
                            break;
                        }

                    }

                }
            }

            else if (rd_cpf.Checked == true)//pesquisa por cpf selecionada
            {
                dtCliente.ClearSelection();

                foreach (DataGridViewRow row in dtCliente.Rows)
                {
                    if (row.Cells["CPF"].Value != null)
                    {

                        if (row.Cells["CPF"].Value.ToString().Equals(pesquisar))
                        {
                            row.Selected = true;
                            indice = row.Index;
                            MessageBox.Show("Cliente localizado!");
                            break;
                        }

                    }
                }
            }

            if (indice != -1)//cliente encontrado, vai pra posição
            {
                dtCliente.CurrentCell = dtCliente.Rows[indice].Cells[0];
            }

            if (indice == -1)//cliente não encontrado, mostra mensagem
            {
                MessageBox.Show("Cliente Não encontrado");
            }
            txtPesquisa.Clear();

        }



        private void btn_deletar_Click(object sender, EventArgs e)
        {

        }
		
		//-----------novos--------------------------
       /* private void pesquisar(Clientes clientes)
		{
            try
            {
                clientes.nomeCliente = txtPesquisa.Text.Trim();
                ClienteBLL clienteBLL = new ClienteBLL();
                dtCliente.DataSource = clienteBLL.pesquisar(clientes);
            }
            catch(Exception erro)
            {
                throw erro;
            }
		}

        private void pesquisarPORCPF(Clientes clientes)
        {
            try
            {

                clientes.cpfCliente = txtPesquisa.Text.Trim();
                ClienteBLL clienteBLL = new ClienteBLL();
                dtCliente.DataSource = clienteBLL.pesquisarCPF(clientes);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }*/



        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCPF2_Leave(object sender, EventArgs e)
        {

            
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {

        }

        private void txtelFixo_Leave(object sender, EventArgs e)
        {
 
        }

        private void txttelCelular_Leave(object sender, EventArgs e)
        {

        }

        private void dtCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Um clique na tabela, mostra os dados da tabela nos labels

            lbl_cpf.Text = dtCliente.CurrentRow.Cells[0].Value.ToString();
            lbl_nome.Text = dtCliente.CurrentRow.Cells[1].Value.ToString();
            lbl_tipo.Text = dtCliente.CurrentRow.Cells[2].Value.ToString();
            lbl_raca.Text = dtCliente.CurrentRow.Cells[3].Value.ToString();
            lbl_nomepet.Text = dtCliente.CurrentRow.Cells[4].Value.ToString();
            /*    
            lbl_nomepet.Text = dtCliente.CurrentRow.Cells[6].Value.ToString();
            lbl_cep.Text = dtCliente.CurrentRow.Cells[7].Value.ToString();
            lbl_bairro.Text = dtCliente.CurrentRow.Cells[8].Value.ToString();
            lbl_numero.Text = dtCliente.CurrentRow.Cells[9].Value.ToString();
            lbl_complemento.Text = dtCliente.CurrentRow.Cells[10].Value.ToString();
            lbl_email.Text = dtCliente.CurrentRow.Cells[3].Value.ToString();
            lbl_tipo.Text = dtCliente.CurrentRow.Cells[5].Value.ToString();
            lbl_raca.Text = dtCliente.CurrentRow.Cells[4].Value.ToString();

            string idSelecionado = dtCliente.CurrentRow.Cells[1].Value.ToString();
            cbNome.SelectedText= idSelecionado;
            //lblAnimal.Text = dtCliente.CurrentRow.Cells[1].Value.ToString();
            */
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            //pq();
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;//propriedade que torna inativo o formulário atual
        }

        private void txtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                pq();
            }*/

        }

        //MÉTODO PARA PESQUISAR POR NOME
        private void pesquisarNome(Clientes clientes)
        {
            try
            {
                AnimalClienteBLL animalcliente= new AnimalClienteBLL();
                clientes.nomeCliente = txtPesquisa.Text.Trim();

                dtCliente.DataSource = animalcliente.PesquisarNomeEscolherClienteConsulta(clientes);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar cliente por nome\n" + erro.Message);
            }
        }

        //MÉTODO PARA PESQUISAR POR CPF
        private void pesquisarCPF(Clientes clientes)
        {
            try
            {
                AnimalClienteBLL animalcliente = new AnimalClienteBLL();
                clientes.cpfCliente = txtPesquisa.Text.Trim();

                dtCliente.DataSource = animalcliente.PesquisarCPFEscolherClienteConsulta(clientes);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar cliente por cpf\n" + erro.Message);
            }
        }


        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (rd_cliente.Checked == true)
            {
                if (txtPesquisa.Text == "")
                {
                    AnimalClienteBLL animalcliente = new AnimalClienteBLL();
                    dtCliente.DataSource = animalcliente.EscolherClienteConsulta();
                }
                else
                {
                    Clientes clientes = new Clientes();
                    pesquisarNome(clientes);
                }
            }

            if (rd_cpf.Checked == true)
            {
                if (txtPesquisa.Text == "")
                {
                    AnimalClienteBLL animalcliente = new AnimalClienteBLL();
                    dtCliente.DataSource = animalcliente.EscolherClienteConsulta();
                }
                else
                {
                    Clientes clientes = new Clientes();
                    pesquisarCPF(clientes);
                }
            }
        }

    }
}
