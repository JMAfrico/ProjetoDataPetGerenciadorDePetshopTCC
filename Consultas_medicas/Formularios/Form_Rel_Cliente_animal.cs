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
    public partial class Form_Rel_Cliente_animal : Form
    {
        public Form_Rel_Cliente_animal()
        {
            InitializeComponent();
            listarAnimais();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            listarTipoAnimal();
            listarNomeCliente();
            ListarVacinas();
           
        }

        private void form_animal_Load(object sender, EventArgs e)
        {
            listarAnimais();
            listarTipoAnimal(); //****
            listarNomeCliente();
            //cb_tipo_animal.SelectedIndex = 0;
            msg.SetToolTip(img_help, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n" +
            "\tPara pesquisar selecione o tipo de pesquisa e digite no campo de pesquisa");
            ListarVacinas();

            
            cb_sexo.Text = "Escolha o sexo";
            cb_peso.Text = "g";
            cb_tamanho.Text = "cm";
            cb_idade.Text = "Idade";
            //cb_tipo_animal.SelectedIndex = -1;
            //cb_raca_animal.SelectedIndex = -1;
            //cb_cliente_animal.SelectedIndex = -1;
            //cb_vacinas.SelectedIndex = -1;
            
        }

        string strconecta = "server=localhost;user=root;database=petshop_2020;port=3306;pwd = ;";//NOTEBOOK
        MySqlConnection conection = null;
        MySqlCommand comando = null;

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

        private void limparCampos()
        {
            txt_nome_animal.Text = "";
            txt_peso_animal.Text = "";
            txt_cor_animal.Text = "";
            txt_altura_animal.Text = "";
            cb_peso.SelectedIndex = -1;
            cb_idade.SelectedIndex = -1;
            cb_sexo.SelectedIndex = -1;
            cb_tamanho.SelectedIndex = -1;
            txt_vacinas_novas.Clear();
            txt_historico_medico.Clear();


        }

        //string RacaSelection;

        //salvar relacionamento cliente x animal
        private void salvar(AnimaisCliente animaisCliente)
        {
                 try
               {
            		if(cb_cliente_animal.Text == string.Empty/* || cb_tipo_animal.Text == string.Empty || cb_cliente_animal.Text == string.Empty ||
                            txt_nome_animal.Text == string.Empty || txt_peso_animal.Text == string.Empty || txt_altura_animal.Text == string.Empty || txt_cor_animal.Text == string.Empty*/)
            		{
            			MessageBox.Show("Informações obrigatórias não preenchidas","Atenção" ,MessageBoxButtons.OK , MessageBoxIcon.Error);
            	    }
            		else
            	    {                       
                        string idCliente = cb_cliente_animal.SelectedValue.ToString();
                        string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
                        string idRacaAnimal = cb_raca_animal.SelectedValue.ToString();
                        //string idRacaAnimal = cb_raca_animal.SelectedIndex.ToString();


                        AnimalClienteBLL animaisBll = new AnimalClienteBLL();

                        animaisCliente.cod_cliente = Convert.ToInt32(idCliente);
                        animaisCliente.cod_tipo_animal = Convert.ToInt32(idTipoAnimal);
                        animaisCliente.cod_raca_animal = Convert.ToInt32(idRacaAnimal);
                        animaisCliente.nome_animal = txt_nome_animal.Text;
                        animaisCliente.peso_animal = txt_peso_animal.Text +" "+cb_peso.Text;
                        animaisCliente.altura_animal = txt_altura_animal.Text +" "+cb_tamanho.Text;
                        animaisCliente.cor_animal = txt_cor_animal.Text;
                        animaisCliente.idade_animal = cb_idade.Text;
                        animaisCliente.sexo_animal = cb_sexo.Text;
                        animaisCliente.historico_vacinas = txt_vacinas_novas.Text;
                        animaisCliente.historico_medico = txt_historico_medico.Text;
                        
                        animaisBll.salvar(animaisCliente);

                        MessageBox.Show("CADASTRO Efetuado com sucesso!", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listarAnimais();
                        limparCampos();
                        btn_salvar_medico.Enabled = true;
                        btn_editar.Enabled = false;
                        btn_deletar.Enabled = false;
                        
            	}


                       }
                     catch (Exception erro)
                   {
                       MessageBox.Show(erro.Message, "Não foi possível salvar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
          
                    }
        }

        //excluir relacionamento de cliente e animal
        private void excluir(AnimaisCliente animaisCliente)
        {
            try
            {
                AnimalClienteBLL animaisBll = new AnimalClienteBLL();

                animaisCliente.cod_cadastro = Convert.ToInt32(lbl_cad.Text);

                animaisBll.excluir(animaisCliente);
                //ou Excluir com maiusculo
                MessageBox.Show("Animal EXCLUÍDO com sucesso!", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_medico.Enabled = true;
                listarAnimais();
                modoNormal();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Você não tem permissão para deletar" + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //listar na tabela o relacionamento de cliente a animal
        private void listarAnimais()
        {
            AnimalClienteBLL animalBLL = new AnimalClienteBLL();
            dtAnimal.DataSource = animalBLL.listarAnimais();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            //Menu_principal novo = new Menu_principal();
            //novo.Show();
            //this.Visible = false;
            if (MessageBox.Show("Quer mesmo cancelar ?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limparCampos();
                modoNormal();
                btn_deletar.Enabled = false;
                btn_editar.Enabled = false;
                btn_salvar_medico.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR ANIMAL ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                AnimaisCliente animais = new AnimaisCliente();
                salvar(animais);
            }


        }



        private void txtRaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }

        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private void dtAnimal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //editar
        private void editar(AnimaisCliente animaisCliente)
        {
               try
               {
                   if (cb_cliente_animal.Text == string.Empty/* || cb_tipo_animal.Text == string.Empty || cb_cliente_animal.Text == string.Empty ||
                            txt_nome_animal.Text == string.Empty || txt_peso_animal.Text == string.Empty || txt_altura_animal.Text == string.Empty || txt_cor_animal.Text == string.Empty*/)
                   {
                       MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
                   else
                   {

                       string idCliente = cb_cliente_animal.SelectedValue.ToString();
                       string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
                       string idRacaAnimal = cb_raca_animal.SelectedValue.ToString();

                       AnimalClienteBLL animaisBll = new AnimalClienteBLL();

                       animaisCliente.cod_cadastro = Convert.ToInt32(lbl_cad.Text);
                       animaisCliente.cod_cliente = Convert.ToInt32(idCliente);
                       animaisCliente.cod_tipo_animal = Convert.ToInt32(idTipoAnimal);
                       animaisCliente.cod_raca_animal = Convert.ToInt32(idRacaAnimal);
                       animaisCliente.nome_animal = txt_nome_animal.Text;
                       animaisCliente.peso_animal = txt_peso_animal.Text +cb_peso.Text;
                       animaisCliente.altura_animal = txt_altura_animal.Text +cb_tamanho.Text;
                       animaisCliente.cor_animal = txt_cor_animal.Text;
                       animaisCliente.idade_animal = cb_idade.Text;
                       animaisCliente.sexo_animal = cb_sexo.Text;
                       animaisCliente.historico_vacinas = txt_vacinas_novas.Text;
                       animaisCliente.historico_medico = txt_historico_medico.Text;

                       animaisBll.editar(animaisCliente);

                       MessageBox.Show("ALTERADO com sucesso!", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       listarAnimais();
                       limparCampos();
                       btn_salvar_medico.Enabled = true;
                       btn_editar.Enabled = false;
                       btn_deletar.Enabled = false;
                       modoNormal();
                   }

               }
               catch (Exception erro)
               {
                   MessageBox.Show("Não foi possível Alterar \n" + erro.Message, "Erro ao alterar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração ?", "ALTERAR ANIMAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AnimaisCliente animais = new AnimaisCliente();
                editar(animais);
            }

        }

        private void pesquisar(AnimaisCliente animaisCliente)
        {
            /*  try
              {
                  animaisCliente.descricaoAnimal = textBox1.Text.Trim();
                  AnimalClienteBLL animaisBll = new AnimalClienteBLL();
                  dtAnimal.DataSource = animaisBll.pesquisar(animaisCliente);
              }
              catch(Exception erro)
              {
                  throw erro;
              }*/
        }

        // private void pesquisarPORNOME(Animais animais)
        //  {
        /*   try
           {
               animais.nomeAnimal = textBox1.Text.Trim();
               AnimalBLL animaisBll = new AnimalBLL();
               dtAnimal.DataSource = animaisBll.pesquisarPETNOME(animais);
           }
           catch (Exception erro)
           {
               throw erro;
           }*/
        //  }


        private void txtRaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (rd_nome_pet.Checked == true)
            {
                if (txtPesquisarRelacionamento.Text == "")
                {
                    AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                    dtAnimal.DataSource = animalClienteBll.listarAnimais();

                }
                else
                {
                    AnimaisCliente animaisCliente = new AnimaisCliente();
                    pesquisarNomePet(animaisCliente);
                }
            }

            if (rd_nome_cliente.Checked == true)
            {
                if (txtPesquisarRelacionamento.Text == "")
                {
                    AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                    dtAnimal.DataSource = animalClienteBll.listarAnimais();

                }
                else
                {
                    Clientes animaisCliente = new Clientes();
                    pesquisarNomeCliente(animaisCliente);
                }
            }

            if (rd_cadastro_rel.Checked == true)
            {
                if (txtPesquisarRelacionamento.Text == "")
                {
                    AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                    dtAnimal.DataSource = animalClienteBll.listarAnimais();

                }
                else
                {
                    //txtPesquisarRelacionamento.
                    Clientes animaisCliente = new Clientes();
                    pesquisarCPFCliente(animaisCliente);
                }
            }


        }


        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar exclusão ?", "EXCLUIR ANIMAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AnimaisCliente animais = new AnimaisCliente();
                excluir(animais);
            }
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_cod_cadastro_TextChanged(object sender, EventArgs e)
        {

        }

        public void listarTipoAnimal()
        {//método para chamar o campo nome tipoAnimal dentro do combobox
            AnimalClienteBLL animalclientebll = new AnimalClienteBLL();        
            this.cb_tipo_animal.ValueMember = "cod_tipo_animal";
            this.cb_tipo_animal.DisplayMember = "nome_tipo_animal";
            this.cb_tipo_animal.DataSource = animalclientebll.listarTipoAnimalCombobox();
            //no cb_tipo_animal, o datasource é refenciado e mostra o comando que esta no método listar, que vem da classe clienteDAO
        }

        public void listarNomeCliente()
        {//método para chamar o campo nome cliente dentro do combobox

            AnimalClienteBLL animalclientebll = new AnimalClienteBLL();
            this.cb_cliente_animal.ValueMember = "CodCliente";
            this.cb_cliente_animal.DisplayMember = "nomeCliente";
            this.cb_cliente_animal.DataSource = animalclientebll.listarNomedoCliente();
         }

        private void ListarVacinas()
        {
            VacinasBLL vacinasBLL = new VacinasBLL();
            
            this.cb_vacinas.ValueMember = "cod_vacina";
            this.cb_vacinas.DisplayMember = "nome_vacina";
            this.cb_vacinas.DataSource = vacinasBLL.MostrarVacinasCombobox();
        }

       //string idRaca;//pegando o texto do combobox selecionado

        private void cb_raca_animal_SelectedIndexChanged(object sender, EventArgs e)
        {

        /*    if (cb_raca_animal.SelectedValue.ToString() != null)
            {

                    this.idRaca = cb_raca_animal.SelectedIndex.ToString();
                    MessageBox.Show("raça selecionada =" + this.idRaca);

          }*/
            
        }

        //combobox tipo do animal
        private void cb_tipo_animal_SelectedIndexChanged(object sender, EventArgs e)
        {       

           if (cb_tipo_animal.SelectedValue.ToString() != null)
            {
                AbrirConexao();

               //quando seleciono do tipo do animal, mostra as raças cadastradas daquele tipo
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT nome_raca_animal,cod_tipo_animal,cod_raca FROM tb_raca WHERE cod_tipo_animal = @cod_tipo_animal", conection);
                comando.Parameters.AddWithValue("@cod_tipo_animal", cb_tipo_animal.SelectedValue.ToString());
                da.SelectCommand = comando;
                da.Fill(dt);
                this.cb_raca_animal.ValueMember = "cod_raca";
                this.cb_raca_animal.DisplayMember = "nome_raca_animal";
                this.cb_raca_animal.DataSource = dt;

                //RacaSelection = cb_tipo_animal.SelectedValue.ToString();

            }


        }

        //combobox nome do cliente
        private void cb_cliente_animal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            AbrirConexao();

            if (cb_cliente_animal.SelectedValue.ToString() != null)
            {    
                //quando seleciono o cliente no combobox, é mostrado no textbox o cpf do cliente
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente,cpfCliente FROM tb_cliente WHERE CodCliente = @CodCliente", conection);
                comando.Parameters.AddWithValue("@CodCliente", cb_cliente_animal.SelectedValue.ToString());
                da.SelectCommand = comando;
                da.Fill(dt);
                this.txt_cpf_cliente.ValueMember = "CodCliente";
                this.txt_cpf_cliente.DisplayMember = "cpfCliente";
                this.txt_cpf_cliente.DataSource = dt;

                //quando seleciono o cliente no combobox, é mostrado no textbox o codigo do cliente
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente,cpfCliente FROM tb_cliente WHERE CodCliente = @CodCliente", conection);
                comando.Parameters.AddWithValue("@CodCliente", cb_cliente_animal.SelectedValue.ToString());
                da2.SelectCommand = comando;
                da2.Fill(dt2);
                this.cb_cod_cadastro.ValueMember = "CodCliente";
                this.cb_cod_cadastro.DisplayMember = "CodCliente";
                this.cb_cod_cadastro.DataSource = dt2;

            }

            FecharConexao();

        }

        private void txt_cod_cadastro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_cpf_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        string TipoSelecionado;
        string RacaSelecionada;

        private void dtAnimal_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            modoEdicao();
            btn_salvar_medico.Enabled = false;
            btn_editar.Enabled = true;
            btn_deletar.Enabled = true;

            lbl_cad.Text = dtAnimal.CurrentRow.Cells[0].Value.ToString();
            cb_cliente_animal.Text = dtAnimal.CurrentRow.Cells[1].Value.ToString();

            TipoSelecionado = dtAnimal.CurrentRow.Cells["TIPO"].Value.ToString();
            cb_tipo_animal.Text = TipoSelecionado;

            RacaSelecionada = dtAnimal.CurrentRow.Cells[3].Value.ToString();
            cb_raca_animal.Text = RacaSelecionada;

            txt_nome_animal.Text = dtAnimal.CurrentRow.Cells[4].Value.ToString();

            txt_peso_animal.Text = dtAnimal.CurrentRow.Cells[5].Value.ToString().Replace("g", "").Replace("k", "");
            txt_altura_animal.Text = dtAnimal.CurrentRow.Cells[6].Value.ToString().Replace("cm","").Replace("m","");

            txt_cor_animal.Text = dtAnimal.CurrentRow.Cells[7].Value.ToString();
            cb_idade.Text = dtAnimal.CurrentRow.Cells[8].Value.ToString();
            cb_sexo.Text = dtAnimal.CurrentRow.Cells[9].Value.ToString();
            txt_vacinas_novas.Text = dtAnimal.CurrentRow.Cells[10].Value.ToString();
            txt_historico_medico.Text = dtAnimal.CurrentRow.Cells[11].Value.ToString();

        }

        private void cb_cliente_animal_Click(object sender, EventArgs e)
        {

        }

        private void cb_tipo_animal_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        //método para pesquisar cliente por nome do pet
        private void pesquisarNomePet(AnimaisCliente animaisCliente)
        {
            try
            {
                animaisCliente.nome_animal = txtPesquisarRelacionamento.Text.Trim();
                AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                dtAnimal.DataSource = animalClienteBll.pesquisarNomePet(animaisCliente);

            }
            catch (System.Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar.\n\n" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //método para pesquisar cliente por nome do Cliente
        private void pesquisarNomeCliente(Clientes clientes)
        {
            try
            {
                clientes.nomeCliente = txtPesquisarRelacionamento.Text.Trim();
                AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                dtAnimal.DataSource = animalClienteBll.pesquisarNomeCliente(clientes);

            }
            catch (System.Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar.\n\n"+ erro.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //método para pesquisar cliente por nome do Cliente
        private void pesquisarCPFCliente(Clientes clientes)
        {
            try
            {
                clientes.nomeCliente = txtPesquisarRelacionamento.Text.Trim();
                AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                dtAnimal.DataSource = animalClienteBll.pesquisarCPFCliente(clientes);

            }
            catch (System.Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar.\n\n" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisarRelacionamento_TextChanged(object sender, EventArgs e)
        {
            if (rd_nome_pet.Checked == true)
            {
                if (txtPesquisarRelacionamento.Text == "")
                {
                    AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                    dtAnimal.DataSource = animalClienteBll.listarAnimais();

                }
                else
                {
                    AnimaisCliente animaisCliente = new AnimaisCliente();
                    pesquisarNomePet(animaisCliente);
                }
            }

            if (rd_nome_cliente.Checked == true)
            {
                if (txtPesquisarRelacionamento.Text == "")
                {
                    AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                    dtAnimal.DataSource = animalClienteBll.listarAnimais();

                }
                else
                {
                    Clientes animaisCliente = new Clientes();
                    pesquisarNomeCliente(animaisCliente);
                }
            }

            if (rd_cadastro_rel.Checked == true)
            {
                if (txtPesquisarRelacionamento.Text == "")
                {
                    AnimalClienteBLL animalClienteBll = new AnimalClienteBLL();
                    dtAnimal.DataSource = animalClienteBll.listarAnimais();

                }
                else
                {                   
                    Clientes animaisCliente = new Clientes();
                    pesquisarCPFCliente(animaisCliente);
                }
            }
        }

        public void modoEdicao()
        {
            //txt_nome_servico.BackColor = Color.Green;
            cb_cod_cadastro.BackColor = Color.Green;
            cb_cliente_animal.BackColor = Color.Green;
            txt_cpf_cliente.BackColor = Color.Green;
            cb_tipo_animal.BackColor = Color.Green;
            cb_raca_animal.BackColor = Color.Green;
            txt_nome_animal.BackColor = Color.Green;
            txt_peso_animal.BackColor = Color.Green;
            txt_cor_animal.BackColor = Color.Green;
            txt_altura_animal.BackColor = Color.Green;
            cb_sexo.BackColor = Color.Green;
            cb_idade.BackColor = Color.Green;
            txt_vacinas_novas.BackColor = Color.Green;
            txt_historico_medico.BackColor = Color.Green;
            cb_tamanho.BackColor = Color.Green;
            cb_peso.BackColor = Color.Green;
            


        }

        public void modoNormal()
        {
            //txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            cb_cod_cadastro.BackColor = Color.FromArgb(23, 32, 40);
            cb_cliente_animal.BackColor = Color.FromArgb(23, 32, 40);
            txt_cpf_cliente.BackColor = Color.FromArgb(23, 32, 40);
            cb_tipo_animal.BackColor = Color.FromArgb(23, 32, 40);
            cb_raca_animal.BackColor = Color.FromArgb(23, 32, 40);
            txt_nome_animal.BackColor = Color.FromArgb(23, 32, 40);
            txt_peso_animal.BackColor = Color.FromArgb(23, 32, 40);
            txt_cor_animal.BackColor = Color.FromArgb(23, 32, 40);
            txt_altura_animal.BackColor = Color.FromArgb(23, 32, 40);
            cb_sexo.BackColor = Color.FromArgb(23, 32, 40);
            cb_idade.BackColor = Color.FromArgb(23, 32, 40);
            txt_vacinas_novas.BackColor = Color.FromArgb(23, 32, 40);
            txt_historico_medico.BackColor = Color.FromArgb(23, 32, 40);
            cb_tamanho.BackColor = Color.FromArgb(23, 32, 40);
            cb_peso.BackColor = Color.FromArgb(23, 32, 40);


        }

        private void btn_add_vacina_Click(object sender, EventArgs e)
        {
            listBox_vacinas.Items.Add(cb_vacinas.Text);
            txt_vacinas_novas.Text += cb_vacinas.Text + "\n";
        }

        private void txt_vacinas_novas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_vacinas_novas_MouseClick(object sender, MouseEventArgs e)
        {
            cb_vacinas.Focus();
        }

        private void cb_vacinas_Click(object sender, EventArgs e)
        {
            ListarVacinas();
        }

        private void cb_tipo_animal_Click(object sender, EventArgs e)
        {

        }

        private void cb_sexo_Click(object sender, EventArgs e)
        {
            cb_sexo.Items.Remove("Escolha o sexo");
        }

        private void cb_idade_Click(object sender, EventArgs e)
        {
            cb_idade.Items.Remove("Idade");
        }

        private void txt_cor_animal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txt_peso_animal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_altura_animal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        

        
    }
}
