using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//classe para chamar os métodos do mysql
using MySql.Data;//classe para chamar os métodos do mysql
using System.Runtime.InteropServices;
using Consultas_medicas.Models;
using Consultas_medicas.BLL;//chamada da classe intermediária
using Consultas_medicas.DAO;//chamada da classe query
using Ferramentas;
using System.Data.SqlClient;
using System.Net;// bibliotecas necessárias para envio de email
using System.Net.Mail;// bibliotecas necessárias para envio de email
using System.Net.Mime;// bibliotecas necessárias para envio de email
using System.Net.Configuration;// bibliotecas necessárias para envio de email
using System.Web.Services;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using Consultas_medicas.Relatorios;
using Consultas_medicas.Formularios;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Consultas_medicas
{            
    public partial class Menu_principal : Form
    {

        //chamada de nova mensagem de texto
        private MailMessage email;        
        Stopwatch Stop = new Stopwatch();



        public Menu_principal()
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            InitializeComponent();
            listar();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            btn_salvar_consulta.Enabled = false;
            listarTipoAnimal();
            lbl_limpar_consulta.Visible = false;
            btn_add_servico.Enabled = false;
            btn_limparLista.Enabled = false;
            listarClientes();
            listarRacaAnimal();
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btn_cancelar_edicao.Enabled = false;
                   
        }

        public Menu_principal(string user, DateTime data)
        {
            InitializeComponent();
            l_nome.Text = user;
            lData.Text = Convert.ToString(data);

        }

        

        private void MostrarLog()
        {
            string entrou = l_nome.Text;
            string entrada = lData.Text;
            Form_log pag = new Form_log(entrou, entrada);
            pag.Show();

        }


        public Menu_principal(String nome_cliente, String cpf_cliente, String tipo_pet, String raca, String nome_pet)
        {           

            InitializeComponent();
            txtNome_cli.Text = nome_cliente;
            txt_cpf_cliente_consulta.Text = cpf_cliente;
            txt_tipo_pet_consulta.Text = tipo_pet;
            txt_raca_pet_consulta.Text = raca;
            txt_nome_pet_consulta.Text = nome_pet;
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            btn_salvar_consulta.Enabled = true;
            listarStatusPag();
            listaServicos();
            listarClientes();
            listarTipoAnimal();
            listarRacaAnimal();
            listarEspecialidades();
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btn_cancelar_edicao.Enabled = false;

            rd_so_servico.Checked = true;

            if (rd_so_servico.Checked == true)
            {
                cb_especialidade.Text = "ESCOLHA UMA ESPECIALIDADE";
                cb_especialidade.Enabled = false;
                cb_veterinario.Enabled = false;
            }
            
            
            
        }

        //variável utilizada para troca de imagem de bloqueio de tela
        static int MetodoGuardar = 0;

        //Método de carregamento do formulário
        private void Menu_principal_Load(object sender, EventArgs e)
        {

            listarNConsultas();
            btn_cancelar_edicao.Enabled = false;
            txt_email.Text = "";
            
            //check box para enviar email ativado, visibilidade desativada
            checkBox1.Checked = true;
            checkBox1.Visible = false;

            //condicional para troca de variável de bloqueio de tela
            if (MetodoGuardar == 1)
            {
                painel_block.Visible = false;
                painel_block2.Visible = false;
            }

            if (MetodoGuardar == 2)
            {
                painel_block.Visible = true;
                painel_block2.Visible = true;
            }

            //colunas de preços e serviços dos itens selecionados pelo cliente
            listView1.Columns.Add("Cód", 50);
            listView1.Columns.Add("Serviços", 200);
            listView1.Columns.Add("Preço", 100);
            listView1.View = View.Details;

            //colunas de preços e serviços dos itens do cliente
            list_cliente.Columns.Add("Produtos e serviços", 160);
            list_cliente.Columns.Add("Preço", 100);
            list_cliente.View = View.Details;


            //a primeira coluna da raça animal fica invisivel
            //dtConsultas.Columns["SERVICOS"].Visible = false;

            listar();
            //limparCampos();
            listarTipoAnimal();
            listarRacaAnimal();
            //listarClientes();
            //painel_bloqueio_inicial.Visible = false;
            //painel_bloqueio_inicial2.Visible = false;
            //listarEmailClientes();
            //txt_email.Text = cb_email_cliente.Text;

            //nome cliente selecionado na consulta, é o nome que vai ser selecionado no cb_cliente
            cb_nome_cliente.Text = txtNome_cli.Text;

            //nome tipo animal selecionado na consulta
            cb_tipo_animal.Text = txt_tipo_pet_consulta.Text;

            //nome raça animal selecionado na consulta
            cb_raca_pet_consulta.Text = txt_raca_pet_consulta.Text;

            //listaServicos();

                //listarConsultas();
            
            //listarProdutos();

            //mostra a data de hoje no label
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy");

            rd_cliente.Checked = true;
            
            //condicional de troca de botões de nova consulta e cancelar consulta
            if (lbl_limpar_consulta.Visible == true)
            {
                lbl_nova_consulta.Visible = false;
                //txtRelato.Enabled = true;
            }

        }


        //Método que coloca os campos de servico e preço no List View
        public void ColunasLista(ListView listView1, string codigo, string servico, string preco)
        {

            ListViewItem item = new ListViewItem(new []{codigo,servico, preco});
            listView1.Items.Add(item);
        }

        //string de conexão
        string strconecta = "server=localhost;user=root;database=petshop_2020;port=3306;pwd = ;";//NOTEBOOK
        MySqlConnection conection = null;
        MySqlCommand comando = null;

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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {


        }

        
        
        private void médicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_veterinario novo = new Form_veterinario();
            novo.ShowDialog();
            this.Visible = false;
        }

        
        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_cliente novo = new Form_cliente();
            novo.ShowDialog();
            this.Visible = false;
        }

        //evento de clique no botão fecha o programa
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //evento de clique no botão fecha o programa
        private void picture_fechar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja Sair ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        //evento de clique no botão minimiza o programa
        private void picture_diminuir_Click(object sender, EventArgs e)
        {//DIMINUI A DIMENSÃO DA TELA
            this.WindowState = FormWindowState.Maximized;
            picture_diminuir.Visible = false;
            picture_restaurar.Visible = true;
            dtConsultas.Width = 1000;
            dtConsultas.Height = 600;
        }

        //evento de clique no botão maximiza o programa
        private void picture_restaurar_Click(object sender, EventArgs e)
        {//RESTAURA A DIMENSÃO DA TELA
            this.WindowState = FormWindowState.Normal;
            picture_restaurar.Visible = false;
            picture_diminuir.Visible = true;
            dtConsultas.Width = 771;
            dtConsultas.Height = 484;
        }

        //evento de clique no botão minimiza o programa
        private void picture_minimizar_Click(object sender, EventArgs e)
        {// MINIMIZA A TELA
            this.WindowState = FormWindowState.Minimized;
        }

        //método que faz o formulário se movimentar com o arrastar do mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        //método que faz o formulário se movimentar com o arrastar do mouse clicando na barra titulo
        private void Barra_Titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        //evento que habilita e desabilita o menu de cadastramento
        private void btn_cadastraa_Click(object sender, EventArgs e)
        {

            if (btn_cad_cliente.Visible == true && btn_cad_funcionario.Visible == true && btn_cad_func.Visible == true && btn_cad_tipodepet.Visible == true && btn_cad_servicos.Visible == true)
            {
                btn_cad_cliente.Visible = false;
                btn_cad_funcionario.Visible = false;
                btn_cad_func.Visible = false;
                btn_cad_tipodepet.Visible = false;
                btn_cad_servicos.Visible = false;
            }
            else
            {
                btn_cad_cliente.Visible = true;
                btn_cad_funcionario.Visible = true;
                btn_cad_pet.Visible = true;
                btn_cad_func.Visible = true;
                btn_cad_tipodepet.Visible = true;
                btn_cad_servicos.Visible = true;
            }




        }

        //evento de clique no botão que abre o formulário para cadastrar novo cliente 
        private void btn_cad_cliente_Click(object sender, EventArgs e)
        {
            Form_cliente novo = new Form_cliente();
            novo.ShowDialog();
            this.Visible = false;
        }

        //evento de clique no botão que abre o formulário para cadastrar novo veterinário 
        private void btn_cad_funcionario_Click(object sender, EventArgs e)
        {
            Form_veterinario n2 = new Form_veterinario();
            n2.ShowDialog();
            this.Visible = false;
        }

        //evento de clique no botão que abre o formulário para cadastrar novo pet
        private void btn_cad_pet_Click(object sender, EventArgs e)
        {
            Form_Rel_Cliente_animal n1 = new Form_Rel_Cliente_animal();
            n1.ShowDialog();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //CONTROLE ESTÁ ASSOCIADO A DATA NO FORMULARIO LOAD, AQUI SÓ ESTÁ DIZENDO
            //QUE A DATA ESTÁ NO LABEL1
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //CONTROLE ESTÁ ASSOCIADO A HORA DO COMANDO TIMER1, AQUI SÓ ESTÁ DIZENDO
            //QUE A DATA ESTÁ NO LABEL2
        }

        //evento de botão que fornece a hora atual
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //evento de clique no botão que abre o formulário para cadastrar novo funcionario
        private void btn_cad_func_Click(object sender, EventArgs e)
        {
            Form_Funcionario novo = new Form_Funcionario();
            novo.ShowDialog();
            this.Visible = false;
        }

        //evento de clique no botão que abre o formulário para cadastrar novo relacionameto cli X pet
        private void btn_cad_pet_Click_1(object sender, EventArgs e)
        {
            Form_Rel_Cliente_animal novo = new Form_Rel_Cliente_animal();
            novo.ShowDialog();
            this.Visible = false;
        }

        //evento de clique no botão que abre o formulário para cadastrar novo funcionario
        private void btn_cad_func_Click_1(object sender, EventArgs e)
        {
            Form_Funcionario novo = new Form_Funcionario();
            novo.ShowDialog();
            this.Visible = false;
        }

        private void Barra_Titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        //Método que analisa o horario limite da consulta

        //Método que salva a consulta
        private void salvar(Consultas consultas)
        {
            try
            {
                string []cod_consulta = new string[listView1.Items.Count];
                string []cod_servico = new string[listView1.Items.Count];
                string[] idCliente = new string[listView1.Items.Count];
                string[] idTipoAnimal = new string[listView1.Items.Count];
                string[] idRaca = new string[listView1.Items.Count];
                string []idVeterinario = new string[listView1.Items.Count];
                DateTime[] iddata = new DateTime[listView1.Items.Count];
                DateTime[] idhora = new DateTime[listView1.Items.Count];

                
                ConsultaBLL consultaBLL = new ConsultaBLL();
                //.Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "")
                int i ;             
                for (i = 0; i < listView1.Items.Count; i++)
                {
                    cod_consulta[i] = cb_proxima_consulta.SelectedValue.ToString();                 
                    cod_servico[i] = listView1.Items[i].SubItems[0].ToString().Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "");
                    idCliente[i] = cb_nome_cliente.SelectedValue.ToString();
                    iddata[i] = Convert.ToDateTime(data_consulta.Text);
                    idhora[i] = Convert.ToDateTime(hora_consulta.Text);
                    idTipoAnimal[i] = cb_tipo_animal.SelectedValue.ToString();
                    idRaca[i] = cb_raca_pet_consulta.SelectedValue.ToString();
                    idVeterinario[i] = cb_veterinario.SelectedValue.ToString();
                }

                for (i = 0; i < listView1.Items.Count; i++){


                    //string idCliente = cb_nome_cliente.SelectedValue.ToString();
                    //string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
                    //string idRaca = cb_raca_pet_consulta.SelectedValue.ToString();
                    //string idVeterinario = cb_veterinario.SelectedValue.ToString();                    


                    consultas.codConsulta = Convert.ToInt32(cod_consulta[i]);
                    consultas.CodCliente = Convert.ToInt32(idCliente[i]);
                    consultas.cod_tipo_animal_consulta = Convert.ToInt32(idTipoAnimal[i]);
                    consultas.cod_raca_animal_consulta = Convert.ToInt32(idRaca[i]);
                    consultas.cod_veterinario = Convert.ToInt32(idVeterinario[i]);
                    consultas.cod_servico = Convert.ToInt32(cod_servico[i]);
                    consultas.dataConsulta = Convert.ToDateTime(iddata[i]);
                    consultas.horaConsulta = Convert.ToDateTime(idhora[i]);
                    consultas.valortotal_consulta = lbl_ListaPrecoTotal.Text;
                    //consultas.status_pagamento = 1;
                    consultaBLL.salvar(consultas);
                }

                if (checkBox1.Checked == true)
                {
                    
                    EnviarEmail();
                    MessageBox.Show("Consulta CADASTRADA com sucesso. !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (checkBox1.Checked == false)
                {
                    consultaBLL.salvar(consultas);
                    MessageBox.Show("Consulta CADASTRADA com sucesso. !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                listarConsultas();
                limparCampos();
                btn_salvar_consulta.Enabled = true;
                lbl_nova_consulta.Enabled = true;
                btn_cancelar_edicao.Enabled = false;
                btn_nova_compra.Enabled = true;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                listView1.Items.Clear();
            }
        }


        //Evento de botão que chama o método salvar consulta
        private void btn_salvar_consulta_Click(object sender, EventArgs e)
        {

            try
            {
                string hora = hora_consulta.Text;

                var horarioInicial = TimeSpan.Parse("09:00");
                var horarioLimite = TimeSpan.Parse("20:00");
                var horarioAtual = TimeSpan.Parse(hora);

                if (horarioLimite < horarioAtual)
                {
                    MessageBox.Show("Horário de consultas até as 20:00 hs", "Horario de consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (horarioInicial > horarioAtual)
                {
                    MessageBox.Show("Horário de consultas a partir das 09:00 hs", "Horario de consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (MessageBox.Show("Confirma os dados ?", "SALVAR CONSULTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        salvaIDcompra();
                        Consultas consultas = new Consultas();
                        salvar(consultas);
                    }
                    
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Horário Inválido\n"+erro.Message,"Alterar Horário",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        //Método que limpa os campos de preenchimento
        private void limparCampos()
        {
            
            txtCodconsulta.Clear();
            //txtRelato.Clear();
            cbCliente.SelectedIndex = -1;
            hora_consulta.Text = string.Empty;//deixa a hora vzaia
            txtNome_cli.Clear();
            txt_email.Clear();
            txt_tipo_pet_consulta.Clear();
            txt_raca_pet_consulta.Clear();
            txt_nome_pet_consulta.Clear();
            listView1.Items.Clear();
            //listView_produtos.Items.Clear();
            txt_cpf_cliente_consulta.Clear();
            btn_nova_compra.Enabled = true;
            btn_add_servico.Enabled = false;
            cb_veterinario.Enabled = false;
            txt_precoUnitario_servico.Enabled = false;
            cb_especialidade.Enabled = false;
            txtRelato.Enabled = false;
            btn_salvar_consulta.Enabled = false;
            lbl_ListaQuantidade.Text = "-";
            lbl_ListaPrecoTotal.Text = "-";
        }

        //Método que Mostra as consultas dentro da tabela(dataTable)
        public void listarConsultas()
        {
            ConsultaBLL consultasbll = new ConsultaBLL();
            dtConsultas.DataSource = consultasbll.listarConsulta();
        }

        public void listarConsultasHoje()
        {
            ConsultaBLL consultasbll = new ConsultaBLL();
            dtConsultas.DataSource = consultasbll.listarConsultaHoje();
        }

        public void listarConsultasMais3Dias()
        {
            ConsultaBLL consultasbll = new ConsultaBLL();
            dtConsultas.DataSource = consultasbll.listarConsultaMais3Dias();
        }

        public void listarConsultasMenos3Dias()
        {
            ConsultaBLL consultasbll = new ConsultaBLL();
            dtConsultas.DataSource = consultasbll.listarConsultaMenos3Dias();
        }

        //método para chamar o campo nome cliente dentro do combobox
        public void listar()
        {
            ConsultaBLL consultaBLL = new ConsultaBLL();
            this.cbCliente.DataSource = consultaBLL.listarClienteConsulta();
            this.cbCliente.ValueMember = "CodCliente";
            this.cbCliente.DisplayMember = "nomeCliente";
        }

        //método para chamar o campo nome cliente dentro do combobox
        public void listarClientes()
        {
            ClienteBLL clienteBll = new ClienteBLL();         
            this.cb_nome_cliente.ValueMember = "CodCliente";
            this.cb_nome_cliente.DisplayMember = "nomeCliente";
            this.cb_nome_cliente.DataSource = clienteBll.listarCliCombobox();
        }

        //método para chamar o campo email cliente dentro do combobox
        /*public void listarEmailClientes()
        {
            ClienteBLL clienteBll = new ClienteBLL();
            this.cb_email_cliente.ValueMember = "CodCliente";
            this.cb_email_cliente.DisplayMember = "emailCliente";
            this.cb_email_cliente.DataSource = clienteBll.listarCliCombobox();
        }*/

        //método para chamar o campo serviços dentro do combobox
        public void listaServicos()
        {
            ServicosBLL servicosBLL = new ServicosBLL();
            this.txtRelato.ValueMember = "cod_servico";
            this.txtRelato.DisplayMember = "nome_servico";
            this.txtRelato.DataSource = servicosBLL.listarServNoCombobox();
        }

        //método para chamar o campo veterinarios dentro do combobox
        public void listaVeterinarios()
        {
            VeterinarioBLL veterinariosBll = new VeterinarioBLL();
            this.cb_veterinario.ValueMember = "codVeterinario";
            this.cb_veterinario.DisplayMember = "nomeVeterinario";
            this.cb_veterinario.DataSource = veterinariosBll.listarVeteriNoCombobox();
        }

        //método para chamar o nome do animal do cliente dentro do combobox
        public void listaNomeAnimalClie()
        {
            AnimalClienteBLL animaisClieBLL = new AnimalClienteBLL();
            this.cb_nomeAnimalCliente.ValueMember = "cod_cadastro";
            this.cb_nomeAnimalCliente.DisplayMember = "nome_animal";
            this.cb_nomeAnimalCliente.DataSource = animaisClieBLL.listarNomeAnimalCliente();
        }

        //método para chamar o campo tipo de animal cliente dentro do combobox
        private void listarTipoAnimal()
        {           
            tipo_animalBLL TipoAnimalBll = new tipo_animalBLL();
            this.cb_tipo_animal.ValueMember = "cod_tipo_animal";
            this.cb_tipo_animal.DisplayMember = "nome_tipo_animal";
            this.cb_tipo_animal.DataSource = TipoAnimalBll.listarTipoAnimais_consulta();
        }

        //método para chamar o campo raça animal dentro do combobox
        private void listarRacaAnimal()
        {
            raca_animalBLL RacaAnimalBll = new raca_animalBLL();

            this.cb_raca_pet_consulta.ValueMember = "cod_raca";
            this.cb_raca_pet_consulta.DisplayMember = "nome_raca_animal";
            this.cb_raca_pet_consulta.DataSource = RacaAnimalBll.listarRacaAnimais_combobox();
        }

        private void listarStatusPag()
        {
            StatusPagamentoBLL status = new StatusPagamentoBLL();

            this.cb_status_pagamento.ValueMember = "cod_status";
            this.cb_status_pagamento.DisplayMember = "nome_status";
            this.cb_status_pagamento.DataSource = status.MostrarStatusCombobox();
        }

        private void listarNConsultas()
        {
            ConsultasClienteBLL cBLL = new ConsultasClienteBLL();

            this.cb_proxima_consulta.ValueMember = "cod_consulta";
            this.cb_proxima_consulta.DisplayMember = "cod_consulta";
            this.cb_proxima_consulta.DataSource = cBLL.MostrarIDCombobox();
        }

        //método para chamar o campo especialidade veterinaria dentro do combobox
        private void listarEspecialidades()
        {
            Especialidade_veterinariaBLL especialidadeBll = new Especialidade_veterinariaBLL();
            this.cb_especialidade.ValueMember = "cod_especialidade";
            this.cb_especialidade.DisplayMember = "nome_especialidade";
            this.cb_especialidade.DataSource = especialidadeBll.listarEspecialidadeNoCombobox();
        }

        //método para editar consultas
        private void editar(Consultas consultas)
        {
            try
            {
                    ConsultaBLL consultaBLL = new ConsultaBLL();

                    string idCliente = cb_nome_cliente.SelectedValue.ToString();
                    string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
                    string idVeterinario = cb_veterinario.SelectedValue.ToString();
                    string idRaca = cb_raca_pet_consulta.SelectedValue.ToString();
                     
                    consultas.codConsulta = Convert.ToInt32(txtCodconsulta.Text);
                    consultas.CodCliente = Convert.ToInt32(idCliente);
                    consultas.cod_tipo_animal_consulta = Convert.ToInt32(idTipoAnimal);
                    consultas.cod_raca_animal_consulta = Convert.ToInt32(idRaca);                  
                    consultas.cod_veterinario = Convert.ToInt32(idVeterinario);
                    consultas.dataConsulta = Convert.ToDateTime(data_consulta.Text);
                    consultas.horaConsulta = Convert.ToDateTime(hora_consulta.Text);
                    consultaBLL.editar(consultas);

                    MessageBox.Show("Consulta ALTERADA com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                    btn_editar.Enabled = false;
                    btn_deletar.Enabled = false;
                    btn_salvar_consulta.Enabled = false;
                    listarConsultas();
                    lbl_ListaPrecoTotal.Text = "-";
                    lbl_ListaQuantidade.Text = "-";
                    hora_consulta.BackColor = Color.FromArgb(23, 32, 40);
                    btn_cancelar_edicao.Enabled = false;
                    btn_nova_compra.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao editar consulta");
            }
        }

        private void RealizarPagamento(Consultas consultas)
        {
            try
            {
                ConsultaBLL consultaBLL = new ConsultaBLL();

                string idCliente = cb_nome_cliente.SelectedValue.ToString();
                string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
                string idVeterinario = cb_veterinario.SelectedValue.ToString();
                string idRaca = cb_raca_pet_consulta.SelectedValue.ToString();
                int idPagamento = cb_status_pagamento.SelectedIndex = 1;
                

                consultas.codConsulta = Convert.ToInt32(txtCodconsulta.Text);
                consultas.CodCliente = Convert.ToInt32(idCliente);
                consultas.cod_tipo_animal_consulta = Convert.ToInt32(idTipoAnimal);
                consultas.cod_raca_animal_consulta = Convert.ToInt32(idRaca);
                consultas.cod_veterinario = Convert.ToInt32(idVeterinario);
                consultas.dataConsulta = Convert.ToDateTime(data_consulta.Text);
                consultas.horaConsulta = Convert.ToDateTime(hora_consulta.Text);
                //consultas.status_pagamento = Convert.ToInt32(idPagamento);
                consultaBLL.editarPagamento(consultas);

                MessageBox.Show("Pagamento efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_consulta.Enabled = false;
                listarConsultas();
                lbl_ListaPrecoTotal.Text = "-";
                lbl_ListaQuantidade.Text = "-";
                hora_consulta.BackColor = Color.FromArgb(23, 32, 40);
                btn_cancelar_edicao.Enabled = false;
                btn_nova_compra.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao editar consulta");
            }
        }

        //evento do botão que chama o método editar consultas
        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                string hora = hora_consulta.Text;

                var horarioInicial = TimeSpan.Parse("09:00");
                var horarioLimite = TimeSpan.Parse("20:00");
                var horarioAtual = TimeSpan.Parse(hora);

                if (horarioLimite < horarioAtual)
                {
                    MessageBox.Show("Horário de consultas até as 20:00 hs", "Horario de consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (horarioInicial > horarioAtual)
                {
                    MessageBox.Show("Horário de consultas a partir das 09:00 hs", "Horario de consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (MessageBox.Show("Confirmar alteração ?", "ALTERAR CONSULTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Consultas consultas = new Consultas();
                    editar(consultas);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Horário Inválido\n" + erro.Message, "Alterar Horário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        //método para excluir consultas
        private void excluir(Consultas consultas)
        //private void excluir(ConsultasCliente consultas)
        {
            try
            {
                
                DateTime dt = Convert.ToDateTime(dtConsultas.CurrentRow.Cells[5].Value.ToString());
                
                
                string nome = cb_nome_cliente.SelectedValue.ToString();

                ConsultaBLL consultaBLL = new ConsultaBLL();

                consultas.CodCliente = Convert.ToInt32(nome);
                consultas.dataConsulta = dt;
                consultas.codConsulta = Convert.ToInt32(txtCodconsulta.Text);
                
                consultaBLL.excluir(consultas);
                 
                /*ConsultaBLL consultaBLL = new ConsultaBLL();
                consultas.cod_consulta = Convert.ToInt32(txtCodconsulta.Text);
                consultaBLL.excluir(consultas);*/
                

                MessageBox.Show("Consulta excluída com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_consulta.Enabled = false;
                listarConsultas();
                hora_consulta.BackColor = Color.FromArgb(23, 32, 40);
                btn_cancelar_edicao.Enabled = false;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível deletar\n" + erro,"DIAGNÓSTICO JÁ EFETUADO",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        //evento do botão que chama o método excluir consultas
        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar cancelamento de consulta ?", "EXCLUIR CONSULTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Consultas consultas = new Consultas();
                excluir(consultas);
            }
        }

        //Evento de duplo clique no formlário de consultas
        private void dtConsultas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_cancelar_edicao.Enabled = true;
            MetodoGuardar = 1;
            hora_consulta.BackColor = Color.OrangeRed;
            //hora_consulta.BackColor = Color.FromArgb(23, 32, 40);
            

            painel_block.Visible = false;
            painel_block2.Visible = false;
            btn_editar.Enabled = true;
            btn_deletar.Enabled = true;
            btn_salvar_consulta.Enabled = false;
            txt_cpf_cliente_consulta.Text = "";
            txt_email.Text = "";

            listaVeterinarios();
            listaServicos();
            listarClientes();
            listarStatusPag();


            txtCodconsulta.Text = dtConsultas.CurrentRow.Cells["CODIGO"].Value.ToString();

            txtNome_cli.Text = dtConsultas.CurrentRow.Cells["CLIENTE"].Value.ToString();
            cb_nome_cliente.Text = txtNome_cli.Text;

            txt_tipo_pet_consulta.Text = dtConsultas.CurrentRow.Cells["TIPO"].Value.ToString();
            cb_tipo_animal.Text = txt_tipo_pet_consulta.Text;

            txt_raca_pet_consulta.Text = dtConsultas.CurrentRow.Cells["RACA"].Value.ToString();
            cb_raca_pet_consulta.Text = txt_raca_pet_consulta.Text;
            cb_status_pagamento.Text = dtConsultas.CurrentRow.Cells["PAGAMENTO"].Value.ToString();

            cb_veterinario.Text = dtConsultas.CurrentRow.Cells["VETERINARIO"].Value.ToString();

            //txtRelato.Text = dtConsultas.CurrentRow.Cells["SERVICOS"].Value.ToString();
            data_consulta.Text = dtConsultas.CurrentRow.Cells["DATA"].Value.ToString();
            hora_consulta.Text = dtConsultas.CurrentRow.Cells["HORA"].Value.ToString();
            //lbl_ListaPrecoTotal.Text = dtConsultas.CurrentRow.Cells["VALOR TOTAL"].Value.ToString();
            txt_email.Text = dtConsultas.CurrentRow.Cells["EMAIL"].Value.ToString();

            txtCodconsulta.Enabled = false;
            txtNome_cli.Enabled = false;
            txt_tipo_pet_consulta.Enabled = false;
            txt_raca_pet_consulta.Enabled = false;
            cb_veterinario.Enabled = false;
            txtRelato.Enabled = false;
            txt_precoUnitario_servico.Enabled = false;

            lbl_limpar_consulta.Enabled = true;
            lbl_nova_consulta.Enabled = true;
            
            
        }

        //método que pesquisa consulta por nome do cliente
        private void pesquisar(Clientes clientes)
        {
            try
            {
                ConsultaBLL consultaBLL = new ConsultaBLL();
                clientes.nomeCliente = txtPesquisar.Text.Trim();
                
                dtConsultas.DataSource = consultaBLL.pesquisar(clientes);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar cliente por nome\n"+erro.Message);
            }
        }

        //método que pesquisa consulta por CPF do cliente
        private void pesquisarPORCodigo(Consultas consultas)
        {
            try
            {
                consultas.codConsulta = Convert.ToInt32(txtPesquisar.Text.Trim());
                ConsultaBLL consultaBLL = new ConsultaBLL();
                dtConsultas.DataSource = consultaBLL.pesquisarCPF(consultas);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao pesquisar cliente por CPF\n" + erro.Message);
            }
        }

        private void TxtRelato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        //evento de botão que chama o método pesquisar
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (rd_cliente.Checked == true)
            {
                if (txtPesquisar.Text == "")
                {
                    ConsultaBLL consultaBLL = new ConsultaBLL();
                    dtConsultas.DataSource = consultaBLL.listarConsulta();
                }
                else
                {
                    Clientes clientes = new Clientes();
                    //Consultas consultas = new Consultas();
                    pesquisar(clientes);
                }
            }

            if (rd_cpf.Checked == true)
            {
                if (txtPesquisar.Text == "")
                {
                    ConsultaBLL consultaBLL = new ConsultaBLL();
                    dtConsultas.DataSource = consultaBLL.listarConsulta();
                }
                else
                {

                    Consultas consultas = new Consultas();
                    pesquisarPORCodigo(consultas);
                }

            }
        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //    if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            //   {

            // e.Handled = true;
            // }
        }

        //evento de botão clique no campo hora
        private void hora_consulta_Click(object sender, EventArgs e)
        {
            hora_consulta.SelectionStart = 0;//quando clica inicia na posição zero
            hora_consulta.Focus();
        }

        private void hora_consulta_Leave(object sender, EventArgs e)
        {

        }

        private void data_consulta_ValueChanged(object sender, EventArgs e)
        {

        }

        //Método que valida a data
        private bool ValidaData(string data)
        {
            bool retorno = true;

            string dataValidacao = DateTime.Now.ToShortDateString();
            DateTime dataValida = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (Convert.ToDateTime(data_consulta.Text) < Convert.ToDateTime(dataValidacao))
            {
                MessageBox.Show("Data inválida ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retorno = false;
            }

            return retorno;
        }

        //Evento que verifica se a data é falsa(antiga)
        private void data_consulta_Leave(object sender, EventArgs e)
        {
            if (ValidaData(data_consulta.Text) == false)
            {
                data_consulta.Focus();
                data_consulta.ResetText();
            }
        }

        //evento de botão que abre nova consuta
        private void label8_Click(object sender, EventArgs e)
        {
            MetodoGuardar = 1;
            Form_busca_cliente novo = new Form_busca_cliente();
            novo.Show();
            this.Visible = false;
            btn_limparLista.Enabled = true;
            //label8.Visible = false;
            lbl_limpar_consulta.Visible = true;
            btn_add_servico.Enabled = true;
            listaVeterinarios();
            listaServicos();
            listarClientes();

            //listarEmailClientes();
            

            if (lbl_limpar_consulta.Visible == true)
            {

                lbl_nova_consulta.Visible = false;
            }

        }

        private void lbl_busca_cliente_Click(object sender, EventArgs e)
        {
            //Form_busca_cliente novo = new Form_busca_cliente();
            //novo.Show();
        }

        //evento de botão no formulário de consulta
        private void dtConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //teste();
            //lbl_xxx.Text = dtConsultas.CurrentRow.Cells[5].Value.ToString();

            richTextBox1.Text = dtConsultas.CurrentRow.Cells[5].Value.ToString();

            //limpa a lista
            list_cliente.Items.Clear();

            //passa o valor da coluna para as variáveis
            //NÃO ESTA FUNCIONANDO, NÃO JOGA OS VALORES PARA A LISTA
            string nome = dtConsultas.CurrentRow.Cells[5].Value.ToString();
            string preco = dtConsultas.CurrentRow.Cells[5].Value.ToString();
            string fim = dtConsultas.CurrentRow.Cells[5].Value.ToString();

            //encontro a posição do nome e do valor
            int posicaoNome = nome.IndexOf("-");
            int posicaoPreco = preco.IndexOf("-");
            int posicaoFim = fim.IndexOf(".");

            


            //nome = nome.Substring(0, posicaoNome);
            //preco = preco.Substring(posicaoNome, posicaoFim);

                //MessageBox.Show("Item"+nome+"Preço:"+preco);

            //ListViewItem item = new ListViewItem(new[] { nome, preco });

            //for (int i = 0; i < list_cliente.Items.Count; i++)
            //{
              //  list_cliente.Items[i].SubItems[0].ToString();
                //list_cliente.Items[i].SubItems[1].ToString();
            //}

            //ColunasLista(list_cliente, nome, preco);

            /*for (int i = 0; i < list_cliente.Items.Count; i++)
            {
                //nome.Substring(0, posicaoNome);
                //preco.Substring(posicaoNome, posicaoFim); 

                //nome += list_cliente.Items[i].SubItems[0].ToString();
                //preco += list_cliente.Items[i].SubItems[1].ToString();

                ColunasLista(list_cliente, nome.Substring(0, posicaoNome), preco.Substring(posicaoNome, posicaoFim));
            }*/



         /*   for (int i = 0; i < 500; i++)
            {
                //após encontrar a posição do nome, conto do 0 até a posição e mostro na lista
                //após encontrar a posição do valor, conto do valor até o final e mostro na lista
                ColunasLista2(list_cliente, nome.Substring(0, posicaoNome), preco.Substring(posicaoNome, posicaoFim));
            }*/
            

           /* string item = "";
            string preco = "";


            for (int i = 0; i < listView1.Items.Count; i++)
            {
                item += list_cliente.Items[i].SubItems[0].ToString().Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "") + "\n";
                preco += list_cliente.Items[i].SubItems[1].ToString().Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "") + "\n";

            }*/

        }

        private void cb_animais_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            lbl_nova_consulta.ForeColor = Color.Blue;
            lbl_nova_consulta.BackColor = Color.White;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            lbl_nova_consulta.ForeColor = Color.Lime;
            lbl_nova_consulta.BackColor = Color.FromArgb(23, 32, 40);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_nova_consulta.ForeColor = Color.Green;
            lbl_nova_consulta.BackColor = Color.Black;
        }

        //evento de botão que chama o formulário de cadastro de animal
        private void btn_cad_tipodepet_Click(object sender, EventArgs e)
        {
            Form_Cadastro_tipo_animal novo = new Form_Cadastro_tipo_animal();
            novo.Show();
        }

        //evento de botão que chama o formulário de serviços
        private void btn_cad_servicos_Click(object sender, EventArgs e)
        {
            Form_servicos novo = new Form_servicos();
            novo.Show();
        }

        //Evento ao alterar combobox relato, buscar seu preço
        private void txtRelato_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbrirConexao();

            if (txtRelato.SelectedValue.ToString() != null)
            {
                //mostra o preco do servico, dependendo do código
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_servico,preco_servico FROM tb_servicos WHERE cod_servico = @cod_servico", conection);
                comando.Parameters.AddWithValue("@cod_servico", txtRelato.SelectedValue.ToString());
                da.SelectCommand = comando;
                da.Fill(dt);
                this.txt_precoUnitario_servico.ValueMember = "cod_servico";
                this.txt_precoUnitario_servico.DisplayMember = "preco_servico";
                this.txt_precoUnitario_servico.DataSource = dt;

                DataTable dtID = new DataTable();
                MySqlDataAdapter daID = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_servico FROM tb_servicos WHERE cod_servico = @cod_servico", conection);
                comando.Parameters.AddWithValue("@cod_servico", txtRelato.SelectedValue.ToString());
                daID.SelectCommand = comando;
                daID.Fill(dtID);
                this.cb_cod_serviço.ValueMember = "cod_servico";
                this.cb_cod_serviço.DisplayMember = "cod_servico";
                this.cb_cod_serviço.DataSource = dtID;

            }

            FecharConexao();
        }

        
        private void txtNome_cli_TextChanged(object sender, EventArgs e)
        {
       /*     AbrirConexao();

            if (txtNome_cli.Text.ToString() != null)
            {
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_cliente,nome_animal FROM tb_clienteanimal WHERE cod_cliente = @cod_cliente", conection);
                comando.Parameters.AddWithValue("@cod_cliente", txtNome_cli.Text.ToString());
                da2.SelectCommand = comando;
                da2.Fill(dt2);
                this.cb_animais_cliente.ValueMember = "cod_cliente";
                this.cb_animais_cliente.DisplayMember = "nome_animal";
                this.cb_animais_cliente.DataSource = dt2;
            }

            FecharConexao();*/

        }

        private void txtNome_cli_ReadOnlyChanged(object sender, EventArgs e)
        {
        }

        //Evento ao alterar nome do cliente no combobox
        private void cb_nome_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbrirConexao();

            //ao ser alterado o nome do cliente, tambem é alterado o email
            if (cb_nome_cliente.SelectedValue.ToString() != null)
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente,emailCliente FROM tb_cliente WHERE CodCliente = @CodCliente", conection);
                comando.Parameters.AddWithValue("@CodCliente", cb_nome_cliente.SelectedValue.ToString());
                da.SelectCommand = comando;
                da.Fill(dt);
                this.cb_email_cliente.ValueMember = "CodCliente";
                this.cb_email_cliente.DisplayMember = "emailCliente";
                this.cb_email_cliente.DataSource = dt;

                txt_email.Text = cb_email_cliente.Text;
                
            }

                /*DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_cliente,nome_animal FROM tb_clienteanimal WHERE cod_cliente = @cod_cliente", conection);
                comando.Parameters.AddWithValue("@cod_cliente", cb_nome_cliente.SelectedValue.ToString());
                da2.SelectCommand = comando;
                da2.Fill(dt2);
                this.cb_animais_cliente.ValueMember = "cod_cliente";
                this.cb_animais_cliente.DisplayMember = "nome_animal";
                this.cb_animais_cliente.DataSource = dt2;

               /* DataTable dt3 = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_cliente,nome_animal FROM tb_clienteanimal WHERE cod_cliente = @cod_cliente", conection);
                comando.Parameters.AddWithValue("@cod_cliente", cb_nome_cliente.SelectedValue.ToString());
                da3.SelectCommand = comando;
                da3.Fill(dt3);
                this.cb_animais_cliente.ValueMember = "cod_cliente";
                this.cb_animais_cliente.DisplayMember = "nome_animal";
                this.cb_animais_cliente.DataSource = dt3;

            }

            FecharConexao();
        */
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //evento ao clicar no botão limpar consulta
        private void lbl_limpar_consulta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja Limpar os dados ?", "CANCELAR ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txt_email.Text = "";
                txt_tipo_pet_consulta.Text = "";
                lbl_nova_consulta.Visible = true;
                txt_nome_pet_consulta.Clear();
                txt_cpf_cliente_consulta.Clear();
                txt_raca_pet_consulta.Clear();
                txtNome_cli.Clear();
                lbl_limpar_consulta.Visible = false;
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_consulta.Enabled = false;
                txtRelato.Enabled = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                lbl_quantidade.Text = "";
                lbl_total_preco.Text = "";
                btn_add_servico.Enabled = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                lbl_quantidade.Text = "-";
                lbl_total_preco.Text = "-";
                listView1.Clear();
                //lbl_ListaQuantidade.Text = "-";
                lbl_ListaPrecoTotal.Text = "-";

            }
 
        }

        //evento de tecla apertada no teclado
        private void Menu_principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                btn_nova_compra.Enabled = false;
                MetodoGuardar = 1;
                Form_busca_cliente novo = new Form_busca_cliente();
                novo.Show();
                this.Visible = false;
                //btn_limparLista.Enabled = true;
                //label8.Visible = false;
                //lbl_limpar_consulta.Visible = true;
                btn_add_servico.Enabled = true;
                listaVeterinarios();
                listaServicos();
                listarClientes();
                btn_salvar_consulta.Enabled = true;

            }

            if (e.KeyCode == Keys.F12)
            {
                Form_produtos_cliente novo = new Form_produtos_cliente();
                this.Close();
                novo.Show();
            }
        }

        //evento de botão adicionar serviço
        private void btn_add_servico_Click(object sender, EventArgs e)
        {
            ColunasLista(listView1,cb_cod_serviço.Text,txtRelato.Text,txt_precoUnitario_servico.Text);
            double z = 0.0;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                z = z + Convert.ToDouble(listView1.Items[i].SubItems[2].Text);

            }
            lbl_ListaPrecoTotal.Text = Convert.ToString("R$ " + z);
            lbl_ListaQuantidade.Text = Convert.ToString(listView1.Items.Count);


             //Consultas consultas = new Consultas();
             //salvar(consultas);
            
        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txt_cpf_cliente_consulta_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_cpf_cliente_consulta_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void txt_cpf_cliente_consulta_Click(object sender, EventArgs e)
        {
            
        }

        //evento de teclado que limita teclas
        private void txt_cpf_cliente_consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }
        }

        //evento de teclado que limita teclas
        private void txtNome_cli_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }
        }

        //evento de teclado que limita teclas
        private void txt_raca_pet_consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
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

            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }
        }

        //evento de teclado que limita teclas
        private void txt_nome_pet_consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }

        }

        //evento de teclado que limita teclas
        private void txtNome_cli_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita delete, só no evento KeyDown
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        //evento de teclado que limita teclas
        private void txt_cpf_cliente_consulta_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita delete, só no evento KeyDown
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        //evento de teclado que limita teclas
        private void txt_raca_pet_consulta_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita delete, só no evento KeyDown
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        //evento de teclado que limita teclas
        private void txt_nome_pet_consulta_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita delete, só no evento KeyDown
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.listBox1.SelectedItem != null && e.KeyCode == Keys.Delete)
            {
                 listBox1.Items.Remove(listBox1.SelectedItem);
                 //listBox2.Items.Remove(listBox2.SelectedItem);

                 double z = 0.0;
                 listBox2.Items.Remove(listBox2.SelectedItem);

                 for (int i = 0; i < listBox1.Items.Count; i++)
                 {
                     z = z - Convert.ToDouble(listBox2.Items[i]);
                 }

                 lbl_quantidade.Text = Convert.ToString(listBox1.Items.Count);
                 lbl_total_preco.Text = Convert.ToString("R$ " + (z*-1));

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            lbl_quantidade.Text = "-";
            lbl_total_preco.Text = "-";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_relatorio_clientes rel_clientes = new Form_relatorio_clientes();
            rel_clientes.Show();
            
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.listBox1.SelectedItem != null && e.KeyCode == Keys.Delete)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                //listBox2.Items.Remove(listBox2.SelectedItem);

                double z = 0.0;
                listBox2.Items.Remove(listBox2.SelectedItem);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    z = z - Convert.ToDouble(listBox2.Items[i]);
                }

                lbl_quantidade.Text = Convert.ToString(listBox1.Items.Count);
                lbl_total_preco.Text = Convert.ToString("R$ " + (z * -1));

            }
        }

        private void txt_tipo_pet_consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            //não aceita backspace
            if (e.KeyChar == (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt_tipo_pet_consulta_KeyDown(object sender, KeyEventArgs e)
        {
            //não aceita delete, só no evento KeyDown
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*
            for (int x = 0; x < listBox1.Items.Count; x++)
            {
                listBox1.SetSelected(x, true);
            }
            for (int y = 0; y < listBox2.Items.Count; y++)
            {
                // Select all items that are not selected.                
                listBox2.SetSelected(y, true);
            }*/

            //EdicaoLista();
            EnviarEmail();
        }

        //evento quando clico com o botão direito do mouse na linha do formulário
        private void dtConsultas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // exibe o ContesteMenuStrip na posição do mouse dentro do gridcontrol
                //CRM.Show(gridControl1.PointToScreen(new Point(e.X, e.Y)));
                subMenu_cliqueDireito.Show(dtConsultas.PointToScreen(new Point(e.X, e.Y)));

            }
        }
        //
        private void btn_visualizarProdutosEServiços_Click(object sender, EventArgs e)
        {
            /*ConsultaBLL consultaBLL = new ConsultaBLL();

            string idCliente = cb_nome_cliente.SelectedValue.ToString();
            string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
            string idVeterinario = cb_veterinario.SelectedValue.ToString();
            string idRaca = cb_raca_pet_consulta.SelectedValue.ToString();

            consultas.codConsulta = Convert.ToInt32(txtCodconsulta.Text);
            consultas.CodCliente = Convert.ToInt32(idCliente);
            consultas.cod_tipo_animal_consulta = Convert.ToInt32(idTipoAnimal);
            consultas.cod_raca_animal_consulta = Convert.ToInt32(idRaca);
            consultas.cod_veterinario = Convert.ToInt32(idVeterinario);
            consultas.dataConsulta = Convert.ToDateTime(data_consulta.Text);
            consultas.horaConsulta = Convert.ToDateTime(hora_consulta.Text);
            consultaBLL.editar(consultas);*/

            if (dtConsultas.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            else
            {

                string nome, codigo;
                string total, status;
                //string data;
                DateTime data = Convert.ToDateTime(dtConsultas.CurrentRow.Cells[5].Value.ToString());
                DateTime hora = Convert.ToDateTime(dtConsultas.CurrentRow.Cells[6].Value.ToString());

                nome = dtConsultas.CurrentRow.Cells[1].Value.ToString();
                //data = dtConsultas.CurrentRow.Cells[5].Value.ToString();
                codigo = dtConsultas.CurrentRow.Cells[0].Value.ToString();
                total = dtConsultas.CurrentRow.Cells[7].Value.ToString();
                status = dtConsultas.CurrentRow.Cells[8].Value.ToString();

                form_prodServ_cliente novo = new form_prodServ_cliente(nome, data, codigo, total, hora, status);
                novo.Show();
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (this.listBox1.SelectedItem != null && e.KeyCode == Keys.Delete)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                //listBox2.Items.Remove(listBox2.SelectedItem);

                double z = 0.0;
                listBox2.Items.Remove(listBox2.SelectedItem);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    z = z - Convert.ToDouble(listBox2.Items[i]);
                }

                lbl_quantidade.Text = Convert.ToString(listBox1.Items.Count);
                lbl_total_preco.Text = Convert.ToString("R$ " + (z * -1));

            }*/
        
                if (e.KeyCode == Keys.Delete)
                {
                   listView1.SelectedItems[0].Remove();
                
                   double z = 0.0;

                   for (int i = 0; i < listView1.Items.Count; i++)
                   {
                       z = z - Convert.ToDouble(listView1.Items[i].SubItems[2].Text);

                   }

                   lbl_ListaPrecoTotal.Text = Convert.ToString("R$ " + (z*-1));
                   lbl_ListaQuantidade.Text = Convert.ToString(listView1.Items.Count);


                   //Consultas consultas = new Consultas();
                   //ConsultaBLL consultaBLL = new ConsultaBLL();

                   //consultas.codConsulta = Convert.ToInt32(txtCodconsulta.Text);
                   //consultas.codConsulta = Convert.ToInt32(listView1.SelectedItems[0]);

                   //consultaBLL.excluir(consultas);


                   //MessageBox.Show("Consulta excluída com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        //método para enviar email
        public void EnviarEmail()
        {
            try
            {
                //nova instancia de mensagem
                email = new MailMessage();

                //email a qual será enviado
                //EMAIL DE TESTE = email.To.Add(new MailAddress(txt_email.Text));
                email.To.Add(new MailAddress(txt_email.Text));

                //email de quem está enviando
                email.From = new MailAddress("Datapet_atendimento@outlook.com");

                //titulo do email
                email.Subject = "Informações de atendimento";

                //ativar o html
                email.IsBodyHtml = true;
                string item = "";
                string preco = "";

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    //vai adicionar a cada looping, o valor das duas colunas
                    item += listView1.Items[i].SubItems[1].ToString().Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "") + "\n<br>";
                    preco += listView1.Items[i].SubItems[2].ToString().Replace("ListViewSubItem:", "").Replace("{", "").Replace("}", "") + "\n<br>";

                    //corpo do email
                    email.Body = "Olá " + txtNome_cli.Text + ".<br><br> " +
                    "Este é um email automático com as informações sobre o agendamento." +
                    "<br>Pet: " + txt_nome_pet_consulta.Text +
                    "<br>Raça: " + txt_raca_pet_consulta.Text +
                    "<br>Veterinário: " + cb_veterinario.Text +
                    "<br><br><table border ='1'><caption>Produtos e serviços</caption>" +
                                                "<tr>" +
                                                    "<th>ITEM</th>" +
                                                     "<th>PREÇO</th>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" + item + "</td>" +
                                                     "<td>" + preco + "</td>" +
                                                 "</tr>" +
                                                 "</table>" +
                     "<br>Data:" + data_consulta.Text + " Hora:" + hora_consulta.Text + " hrs" +
                     "<br>Total:" + lbl_ListaPrecoTotal.Text +
                     "<br><br>Em casa de desistência, entrar em contato com no máximo 1 hora de antecedência"+
                     "<br><br>Atendimento Data Pet.";

                }

                //novo envio de mensagem, usando servidor e porta
                SmtpClient smtp = new SmtpClient("smtp.live.com", 587);//SERVIDOR LIVE
                //SmtpClient smtp = new SmtpClient("smtp.google.com", 587);//SERVIDOR GOOGLE


                //credenciais do email de quem está enviando, email e senha
                System.Net.NetworkCredential nc = new NetworkCredential("Datapet_atendimento@outlook.com", "Datapet@10");
                //smtp.Credentials = new System.Net.NetworkCredential("joaomarcosafricodasilva@gmail.com", "Elenteamo@11");

                smtp.Credentials = nc;

                //Tipo de segurança de envio de mensagem
                smtp.EnableSsl = true;

                //método enviar
                smtp.Send(email);
            }
            catch (Exception e)
            {

                MessageBox.Show("Falha ao enviar Email.\n"+e.Message, "EMAIL",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
  
        }

        private void btn_cancelar_edicao_Click(object sender, EventArgs e)
        {
            limparCampos();
            lbl_ListaPrecoTotal.Text = "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MetodoGuardar = 1;
            Form_busca_cliente novo = new Form_busca_cliente();
            novo.Show();
            this.Visible = false;
            //btn_limparLista.Enabled = true;
            //label8.Visible = false;
            //lbl_limpar_consulta.Visible = true;
            btn_add_servico.Enabled = true;
            listaVeterinarios();
            listaServicos();
            listarClientes();
            btn_salvar_consulta.Enabled = true;
            btn_nova_compra.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja Limpar os dados ?", "CANCELAR ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txt_email.Text = "";
                txt_tipo_pet_consulta.Text = "";
                //lbl_nova_consulta.Visible = true;
                txt_nome_pet_consulta.Clear();
                txt_cpf_cliente_consulta.Clear();
                txt_raca_pet_consulta.Clear();
                txtNome_cli.Clear();
                lbl_limpar_consulta.Visible = false;
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_consulta.Enabled = false;
                txtRelato.Enabled = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                lbl_quantidade.Text = "";
                lbl_total_preco.Text = "";
                btn_add_servico.Enabled = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                lbl_quantidade.Text = "-";
                lbl_total_preco.Text = "-";
                listView1.Items.Clear();
                lbl_ListaQuantidade.Text = "-";
                lbl_ListaPrecoTotal.Text = "-";

            }
        }

        private void hora_consulta_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColunasLista(listView1,cb_cod_serviço.Text, txtRelato.Text, txt_precoUnitario_servico.Text);
            double z = 0.0;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                z = z + Convert.ToDouble(listView1.Items[i].SubItems[1].Text);

            }
            lbl_ListaPrecoTotal.Text = Convert.ToString("R$ " + z);
            lbl_ListaQuantidade.Text = Convert.ToString(listView1.Items.Count);
        }

        private void teste_salvar(Consultas consultas)
        {
            try
            {
                ConsultaBLL consultaBLL = new ConsultaBLL();
                string idCliente = cb_nome_cliente.SelectedValue.ToString();
                string idTipoAnimal = cb_tipo_animal.SelectedValue.ToString();
                string idVeterinario = cb_veterinario.SelectedValue.ToString();
                string idRaca = cb_raca_pet_consulta.SelectedValue.ToString();
                

                consultas.CodCliente = Convert.ToInt32(idCliente);
                consultas.cod_tipo_animal_consulta = Convert.ToInt32(idTipoAnimal);
                consultas.cod_raca_animal_consulta = Convert.ToInt32(idRaca);   
                consultas.cod_veterinario = Convert.ToInt32(idVeterinario);
                //consultas.desc_servicos = Convert.ToInt32(idServico);
                consultas.dataConsulta = Convert.ToDateTime(data_consulta.Text);
                consultas.horaConsulta = Convert.ToDateTime(hora_consulta.Text);
                consultas.valortotal_consulta = lbl_ListaPrecoTotal.Text;
                
                

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string idServico = txtRelato.SelectedValue.ToString();
                    //consultas.desc_servicos =+ Convert.ToInt32(idServico[i]);
                    //consultas.desc_servicos += listView1.Items[i];
                    //consultas.desc_servicos += listView1.Items[i].ToString().Replace("ListViewItem:","").Replace("{","").Replace("}","") + "\t-R$"+ listView1.Items[i].SubItems[1].ToString().Replace("ListViewSubItem:","").Replace("{","").Replace("}","")+".\n";

                }
                
                /*foreach (ListViewItem item in listView1.Items)
                {
                    consultas.desc_servicos += item.Index;
                }*/

                consultaBLL.salvar(consultas);
                limparCampos();
                listarConsultas();
                lbl_nova_consulta.Enabled = true;
                btn_cancelar_edicao.Enabled = false;
                btn_salvar_consulta.Enabled = false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro"+e.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Consultas novo = new Consultas();
            teste_salvar(novo);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_produtos_cliente novo = new Form_produtos_cliente();
            novo.Show();
            this.Visible = false;

        }

        private void cb_produto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subMenu_cliqueDireito_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btn_add_produto_Click(object sender, EventArgs e)
        {

        }

        private void cb_especialidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbrirConexao();

            //Seleciona o veterinario, dependendo da Especialidade
            if (cb_especialidade.SelectedValue.ToString() != null)
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("select nomeVeterinario,codVeterinario,especializacao from tb_veterinario where especializacao = @especializacao", conection);
                comando.Parameters.AddWithValue("@especializacao", cb_especialidade.SelectedValue.ToString());
                da.SelectCommand = comando;
                da.Fill(dt);
                this.cb_veterinario.ValueMember = "codVeterinario";
                this.cb_veterinario.DisplayMember = "nomeVeterinario";
                this.cb_veterinario.DataSource = dt;

            }

            FecharConexao();
        }

        private void rd_so_servico_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd_so_servico_Click(object sender, EventArgs e)
        {
            cb_especialidade.Text = "ESCOLHA UMA ESPECIALIDADE";
            cb_especialidade.Enabled = false;
            cb_veterinario.Enabled = false;
            
        }

        private void rd_consulta_Click(object sender, EventArgs e)
        {
            cb_especialidade.Enabled = true;
            cb_veterinario.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_consultaVeterinario novo = new Form_consultaVeterinario();
            novo.Show();
        }

        private void rd_todos_dias_Click(object sender, EventArgs e)
        {
            listarConsultas();
        }

        public void salvaIDcompra()
        {
            ConsultasCliente c = new ConsultasCliente();
            ConsultasClienteBLL cBLL= new ConsultasClienteBLL();
            
            string idServico = cb_proxima_consulta.SelectedValue.ToString();//novo
            //string idTipoPagamento = cb_forma_pagamento.SelectedValue.ToString();
            //compras.cod_pagamento = Convert.ToInt32(idTipoPagamento);
            c.status_pagamento = 1;
            c.tipo_pagamento = 5;
            c.cod_consulta = Convert.ToInt32(idServico) + 1;
            //compras.cod_compra = Convert.ToInt32(idCompra) + 1;//novo
            cBLL.salvar(c);
            //comprasBLL.salvar(compras);//novo           
            listarNConsultas();
        }

        private void efetuarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            String valor = dtConsultas.CurrentRow.Cells[7].Value.ToString().Replace("R$ ","");
            ComboBox combo = new ComboBox();
            DialogResult resultado = new DialogResult();
            Form_tipo_pagamento pag = new Form_tipo_pagamento(valor);
            resultado = pag.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                if (MessageBox.Show("Confirmar pagamento ?", "NOVA COMPRA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConsultasClienteBLL consultaClienteBll = new ConsultasClienteBLL();
                    ConsultasCliente consultasCliente = new ConsultasCliente();
                    //consultaBll.editarPagamento(consultas);

                }
            }*/
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            if (rd_todos_dias.Checked == true)
            {
                listarConsultas();
            }

            if (rd_hoje.Checked == true)
            {
                listarConsultasHoje();
            }

            if (rd_3dias.Checked == true)
            {
                listarConsultasMais3Dias();
            }

            if (rd_menos3dias.Checked == true)
            {
                listarConsultasMenos3Dias();
            }
        }

        private void rd_hoje_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd_hoje_Click(object sender, EventArgs e)
        {
            listarConsultasHoje();
        }

        private void rd_3dias_Click(object sender, EventArgs e)
        {
            listarConsultasMais3Dias();
        }

        private void rd_menos3dias_Click(object sender, EventArgs e)
        {
            listarConsultasMenos3Dias();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            MostrarLog();
        }

        private void consultaSelecionadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void exportarPDFTodasConsultas(DataGridView dt, String strPDF, string strHead)
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
            //autor.Add(new Chunk("\nCliente : " + lbl_nome_cliente.Text, Fontautor));
            autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
            //autor.Add(new Chunk("\nTotal:" + lbl_total_geral.Text, Fontautor));
            autor.Add(new Chunk("\nQuantidade de consultas:" + dtConsultas.RowCount, Fontautor));
            //autor.Add(new Chunk("\nTotal :" + lbl_TotalDasCompras.Text, Fontautor));

            autor.Add(new Chunk(" " + "", Fontautor));
            doc.Add(autor);

            //
            doc.Add(new Chunk("\n", fntHead));

            //TABELA
            PdfPTable pdfTable = new PdfPTable(dtConsultas.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dtConsultas.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);

            }

            //Adding DataRow
            foreach (DataGridViewRow row in dtConsultas.Rows)
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


        private void todasConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtConsultas.Rows.Count == 0)
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

                exportarPDFTodasConsultas(dtConsultas, @"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RConsultas " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf", "Relatório de Consultas");
                System.Diagnostics.Process.Start(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RConsultas " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf");
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
        }

   }
        
}
    
