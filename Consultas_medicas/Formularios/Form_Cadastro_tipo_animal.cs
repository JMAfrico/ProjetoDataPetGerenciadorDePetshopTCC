using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.Models;//importar
using Consultas_medicas.BLL;//importar
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;


namespace Consultas_medicas
{
    public partial class Form_Cadastro_tipo_animal : Form
    {
        public Form_Cadastro_tipo_animal()
        {
            InitializeComponent();
            listarTipoAnimais();
            listarRacaAnimais();
            listarTodosAnimais();
            btn_editar_animal.Enabled = false;
            btn_deletar_tipo_animal.Enabled = false;
            btn_editar_raca_pet.Enabled = false;
            btn_deletar_raca_pet.Enabled = false;
            listarTipoAnimalCombobox();
            cb_racaTipo_pet.SelectedIndex = -1;
        }
        string strconecta = "server=localhost;user=root;database=petshop_2020;port=3306;pwd = ;";//NOTEBOOK
        MySqlConnection conection = null;
        

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

        private void Form_Cadastro_tipo_animal_Load(object sender, EventArgs e)
        {
            listarTipoAnimais();
            listarRacaAnimais();
            listarTodosAnimais();
            btn_editar_animal.Enabled = false;
            btn_deletar_tipo_animal.Enabled = false;
            btn_editar_raca_pet.Enabled = false;
            btn_deletar_raca_pet.Enabled = false;
            listarTipoAnimalCombobox();
            cb_racaTipo_pet.SelectedIndex = -1;
            msn.SetToolTip(img_help, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n" +
            "Para pesquisar digite no campo de pesquisa");

            msg2.SetToolTip(img_help_raca, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n" +
            "Para pesquisar digite no campo de pesquisa");
        }



        //Método para movimentar a tela
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        //listar tipo de animais
        private void listarTipoAnimais()
        {
            tipo_animalBLL animalBLL = new tipo_animalBLL();
            dtListar_tipo_animais.DataSource = animalBLL.listarTipoAnimais();//coloquei um datagrid view e dei o nome de dtListar_animais

        }
        //listar raca de animais
        private void listarRacaAnimais()
        {
            raca_animalBLL Raca_animalBLL = new raca_animalBLL();
            dt_raca_animal.DataSource = Raca_animalBLL.listarRacaAnimais();
            //dt_raca_animal.Columns[0].Visible = false;//a primeira coluna da raça animal fica invisivel

        }
        //listar todos animais
        private void listarTodosAnimais()
        {
            raca_animalBLL Raca_animalBLL = new raca_animalBLL();
            dt_todos_animais.DataSource = Raca_animalBLL.listarTodosAnimais();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            txt_codigo_tipo_pet.Text = "";
            txt_nome_tipo_animal.Text = "";
            btn_deletar_tipo_animal.Enabled = false;
            btn_editar_animal.Enabled = false;
            btn_salvar_animal.Enabled = true;
            txt_codigo_tipo_pet.BackColor = Color.FromArgb(23, 32, 40);
            txt_nome_tipo_animal.BackColor = Color.FromArgb(23, 32, 40);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //evento botão salvar tipo de animal
        private void btn_salvar_animal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR NOVO TIPO DE ANIMAL? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tipo_animal tipo_animal = new tipo_animal();
                salvar(tipo_animal);              
            }
        }
        //método salvar tipo de animal
        private void salvar(tipo_animal tipo_animal)//esse método deve ser privado
        {
            try
            {
                if (txt_nome_tipo_animal.Text == String.Empty)
                {
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tipo_animalBLL Tipo_animalBLL = new tipo_animalBLL();

                    tipo_animal.nome_tipo_animal = txt_nome_tipo_animal.Text;

                    Tipo_animalBLL.salvar(tipo_animal);
                    MessageBox.Show("Tipo de Animal CADASTRADO com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarRacaAnimais();
                    listarTipoAnimais();
                    listarTodosAnimais();
                    txt_nome_tipo_animal.Clear();
                    txt_codigo_tipo_pet.Clear();
                    btn_editar_animal.Enabled = false;
                    btn_deletar_tipo_animal.Enabled = false;
                    btn_salvar_animal.Enabled = true;
                    btn_voltar.Enabled = true;
                    listarTipoAnimalCombobox();
                    
                }

            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message + "\n\n Não foi possível salvar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //evento deletar tipo de animal
        private void btn_deletar_tipo_animal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir ?", "Excluir Animal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tipo_animal Tipo_animal = new tipo_animal();
                excluir(Tipo_animal);
            }
        }

        //método deletar tipo de animal
        private void excluir(tipo_animal Tipo_animal)//esse método deve ser privado
        {
            try
            {
                tipo_animalBLL Tipo_animalBLL = new tipo_animalBLL();

                Tipo_animal.cod_tipo_animal = Convert.ToInt32(txt_codigo_tipo_pet.Text);

                Tipo_animalBLL.excluir(Tipo_animal);
  
                MessageBox.Show("Tipo EXCLUÍDO com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarRacaAnimais();
                listarTipoAnimais();
                listarTodosAnimais();
                txt_nome_tipo_animal.Clear();
                txt_codigo_tipo_pet.Clear();
                btn_editar_animal.Enabled = false;
                btn_deletar_tipo_animal.Enabled = false;
                btn_salvar_animal.Enabled = true;
                btn_voltar.Enabled = true;
                listarTipoAnimalCombobox();
                modoNormalTipo();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Você não tem permissão para Excluir \n" + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                modoNormalTipo();
            }
        }

        //evento para editar tipo de animal
        private void btn_editar_animal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração ?", "Excluir Animal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tipo_animal Tipo_animal = new tipo_animal();
                editar(Tipo_animal);
            }
        }

        //Método para editar tipo de animal no banco de dados
        private void editar(tipo_animal Tipo_animal)
        {
            try
            {
                if (txt_nome_tipo_animal.Text == String.Empty)
                {
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tipo_animalBLL Tipo_animalBLL = new tipo_animalBLL();

                    Tipo_animal.cod_tipo_animal = Convert.ToInt32(txt_codigo_tipo_pet.Text);
                    Tipo_animal.nome_tipo_animal = txt_nome_tipo_animal.Text;

                    Tipo_animalBLL.editar(Tipo_animal);

                    MessageBox.Show("Animal ALTERADO com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarRacaAnimais();
                    listarTipoAnimais();
                    listarTodosAnimais();
                    txt_nome_tipo_animal.Clear();
                    txt_codigo_tipo_pet.Clear();
                    btn_editar_animal.Enabled = false;
                    btn_deletar_tipo_animal.Enabled = false;
                    btn_salvar_animal.Enabled = true;
                    btn_voltar.Enabled = true;
                    listarTipoAnimalCombobox();
                    modoNormalTipo();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Você não tem permissão para Excluir \n"+erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento duplo clique na tabela tipo_animais
        private void dtListar_tipo_animais_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_editar_animal.Enabled = true;
            btn_deletar_tipo_animal.Enabled = true;
            btn_salvar_animal.Enabled = false;

            txt_codigo_tipo_pet.Text = dtListar_tipo_animais.CurrentRow.Cells[0].Value.ToString();
            txt_nome_tipo_animal.Text = dtListar_tipo_animais.CurrentRow.Cells[1].Value.ToString();
            modoEdicaoTipo();

        }

        //evento salvar raca de animal
        private void btn_salvar_raca_pet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR NOVO TIPO DE ANIMAL? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                raca_animal RACA_ANIMAL = new raca_animal();
                salvar(RACA_ANIMAL);
            }
        }

        //método salvar raca de animal
        private void salvar(raca_animal RACA_ANIMAL)//esse método deve ser privado
        {
            try
            {
                if (txt_raca_pet.Text == String.Empty)
                {
                    
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
     
                }
                else
                {

                    string idSelecionado = cb_racaTipo_pet.SelectedValue.ToString();

                    raca_animalBLL RACA_ANIMALBLL = new raca_animalBLL();

                    RACA_ANIMAL.nome_raca_animal = txt_raca_pet.Text;
                    RACA_ANIMAL.cod_raca_animal = Convert.ToInt32(idSelecionado);


                    RACA_ANIMALBLL.salvar(RACA_ANIMAL);
                    MessageBox.Show("Raça CADASTRADA com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    listarRacaAnimais();
                    listarTipoAnimais();
                    listarTodosAnimais();
                    txt_raca_pet.Clear();
                    btn_editar_raca_pet.Enabled = false;
                    btn_deletar_raca_pet.Enabled = false;
                    btn_salvar_raca_pet.Enabled = true;
                    btn_voltar_raca_pet.Enabled = true;
                    listarTipoAnimalCombobox();
                    
                }

            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        

        private void cb_racaTipo_pet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //método para chamar o campo nome tipoAnimal dentro do combobox
        public void listarTipoAnimalCombobox()
        {
            raca_animalBLL Raca_animalBLL = new raca_animalBLL();
            this.cb_racaTipo_pet.ValueMember = "cod_tipo_animal";
            this.cb_racaTipo_pet.DisplayMember = "nome_tipo_animal";
            this.cb_racaTipo_pet.DataSource = Raca_animalBLL.listarTipoAnimalCombobox();
            //no cb_tipo_animal, o datasource é refenciado e mostra o comando que esta no método listar, que vem da classe clienteDAO
        }

        private void dtListar_tipo_animais_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //evento botão editar
        private void btn_editar_raca_pet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração ?", "ALTERAR Animal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                raca_animal Raca_animal = new raca_animal();
                editar(Raca_animal);
                
            }
        }

        //Método para editar raca de animal no banco de dados
        private void editar(raca_animal Raca_animal)
        {
            try
            {
                if (txt_raca_pet.Text == String.Empty)
                {
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string idSelecionado = cb_racaTipo_pet.SelectedValue.ToString();

                    raca_animalBLL RACA_ANIMALBLL = new raca_animalBLL();
                   
                    Raca_animal.codigo_index_raca = Convert.ToInt32(txt_cod_cadastro_raca.Text);                   
                    Raca_animal.nome_raca_animal = txt_raca_pet.Text;
                    Raca_animal.cod_raca_animal = Convert.ToInt32(idSelecionado);
                    

                    RACA_ANIMALBLL.editar(Raca_animal);

                    MessageBox.Show("Alterado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listarTodosAnimais();
                    listarTipoAnimais();
                    listarRacaAnimais();
                    btn_editar_raca_pet.Enabled = false;
                    btn_deletar_raca_pet.Enabled = false;
                    btn_salvar_raca_pet.Enabled = true;
                    btn_voltar_raca_pet.Enabled = true;
                    modoNormalRaca();

                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        string idSelecionado;
        //evento duplo clique dentro da tabela de raças
        private void dt_raca_animal_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            btn_editar_raca_pet.Enabled = true;
            btn_deletar_raca_pet.Enabled = true;
            btn_salvar_raca_pet.Enabled = false;

            txt_cod_cadastro_raca.Text = dt_raca_animal.CurrentRow.Cells[0].Value.ToString();
            txt_raca_pet.Text = dt_raca_animal.CurrentRow.Cells[2].Value.ToString();
            //abaixo para selecionar o item da tabela e jogar no combobox
            idSelecionado = dt_raca_animal.CurrentRow.Cells[1].Value.ToString();
            cb_racaTipo_pet.SelectedValue = idSelecionado;
            modoEdicaoRaca();

        }

        private void btn_voltar_raca_pet_Click(object sender, EventArgs e)
        {
            txt_raca_pet.BackColor = Color.FromArgb(23, 32, 40);
            cb_racaTipo_pet.BackColor = Color.FromArgb(23, 32, 40);
            txt_cod_cadastro_raca.BackColor = Color.FromArgb(23, 32, 40);
            txt_cod_cadastro_raca.Text = "";
            txt_raca_pet.Text = "";
            btn_editar_raca_pet.Enabled = false;
            btn_deletar_raca_pet.Enabled = false;
            btn_salvar_raca_pet.Enabled = true;
        }
        
        //evento botão deletar
        private void btn_deletar_raca_pet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar Excluir ?", "EXCLUIR Animal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                raca_animal Raca_animal = new raca_animal();
                excluir(Raca_animal);
            }
        }
        //Método para excluir raca de animal no banco de dados
        private void excluir(raca_animal Raca_animal)
        {
            try
            {
                if (txt_raca_pet.Text == String.Empty)
                {
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //string idSelecionado = cb_racaTipo_pet.SelectedValue.ToString();
                    raca_animalBLL RACA_ANIMALBLL = new raca_animalBLL();

                    //Raca_animal.nome_raca_animal = txt_raca_pet.Text;
                    //Raca_animal.cod_raca_animal = Convert.ToInt32(idSelecionado);
                    Raca_animal.codigo_index_raca = Convert.ToInt32(txt_cod_cadastro_raca.Text);

         
                    RACA_ANIMALBLL.excluir(Raca_animal);

                    MessageBox.Show("Raça Excluída com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarRacaAnimais();
                    listarTipoAnimais();
                    listarTodosAnimais();
                    cb_racaTipo_pet.SelectedValue = -1;
                    txt_raca_pet.Clear();
                    btn_editar_raca_pet.Enabled = false;
                    btn_deletar_raca_pet.Enabled = false;
                    btn_salvar_raca_pet.Enabled = true;
                    btn_voltar_raca_pet.Enabled = true;
                    listarTipoAnimalCombobox();
                    modoNormalRaca();

                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Você não tem altorização para deletar.\n"+e.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_raca_animal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //evento do textbox geral digitar e fazer a pesquisa
        private void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            if (rb_raca_animal.Checked == true)
            {
                if (txt_pesquisar.Text == "")
                {
                    raca_animalBLL RacaAnimalBll = new raca_animalBLL();
                    dt_todos_animais.DataSource = RacaAnimalBll.listarTodosAnimais();
                }
                else
                {
                    raca_animal animal = new raca_animal();
                    pesquisarRaca(animal);
                }
            }

            if (rb_tipo_animal.Checked == true)
            {
                if (txt_pesquisar.Text == "")
                {
                    tipo_animalBLL TipoAnimalBLL = new tipo_animalBLL();
                    dt_todos_animais.DataSource = TipoAnimalBLL.listarTodosAnimais();
                }
                else
                {
                    tipo_animal TipoAnimal = new tipo_animal();
                    pesquisarTIPO(TipoAnimal);
                }
            }
        }

        //método para pesquisar animal por raça no formulario geral
        private void pesquisarRaca(raca_animal RacaAnimal)
        {
            try
            {
                RacaAnimal.nome_raca_animal = txt_pesquisar.Text.Trim();

                raca_animalBLL RacaAnimalBll = new raca_animalBLL();

                dt_todos_animais.DataSource = RacaAnimalBll.pesquisar(RacaAnimal);

            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //método para pesquisar animal por Tipo no form geral
        private void pesquisarTIPO(tipo_animal TipoAnimal)
        {
            try
            {
                TipoAnimal.nome_tipo_animal = txt_pesquisar.Text.Trim();

                tipo_animalBLL TipoAnimalBLL = new tipo_animalBLL();

                dt_todos_animais.DataSource = TipoAnimalBLL.pesquisar(TipoAnimal);

            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //método para pesquisar animal por Tipo no form de tipos de animais
        private void pesquisarSoTipos(tipo_animal TipoAnimal)
        {
            try
            {
                TipoAnimal.nome_tipo_animal = txt_pesquisar_tipo.Text.Trim();

                tipo_animalBLL TipoAnimalBLL = new tipo_animalBLL();

                dtListar_tipo_animais.DataSource = TipoAnimalBLL.pesquisarTipos(TipoAnimal);

            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //método para pesquisar animal por raca no form de raca de animais
        private void pesquisarSoRacas(raca_animal raca_ani)
        {
            try
            {
                raca_ani.nome_raca_animal = txt_pesquisar_raca.Text.Trim();

                raca_animalBLL raca_aniBLL = new raca_animalBLL();

                dt_raca_animal.DataSource = raca_aniBLL.pesquisar_txt_raca(raca_ani);


            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        public void modoEdicaoTipo()
        {
            //txt_nome_servico.BackColor = Color.Green;
            txt_codigo_tipo_pet.BackColor = Color.Green;
            txt_nome_tipo_animal.BackColor = Color.Green;
            btn_deletar_tipo_animal.Enabled = true;
            btn_editar_animal.Enabled = true;
            btn_salvar_animal.Enabled = false;

        }

        public void modoNormalTipo()
        {
            //txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            txt_codigo_tipo_pet.BackColor = Color.FromArgb(23, 32, 40);
            txt_nome_tipo_animal.BackColor = Color.FromArgb(23, 32, 40);
            btn_deletar_tipo_animal.Enabled = false;
            btn_editar_animal.Enabled = false;
            btn_salvar_animal.Enabled = true;
            txt_codigo_tipo_pet.Text = "";
            txt_nome_tipo_animal.Text = "";

        }

        public void modoEdicaoRaca()
        {
            //txt_nome_servico.BackColor = Color.Green;
            txt_cod_cadastro_raca.BackColor = Color.Green;
            txt_raca_pet.BackColor = Color.Green;
            cb_racaTipo_pet.BackColor = Color.Green;
            btn_editar_raca_pet.Enabled = true;
            btn_deletar_raca_pet.Enabled = true;
            btn_salvar_raca_pet.Enabled = false;

        }

        public void modoNormalRaca()
        {
            //txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            txt_cod_cadastro_raca.BackColor = Color.FromArgb(23, 32, 40);
            txt_raca_pet.BackColor = Color.FromArgb(23, 32, 40);
            cb_racaTipo_pet.BackColor = Color.FromArgb(23, 32, 40);
            btn_editar_raca_pet.Enabled = false;
            btn_deletar_raca_pet.Enabled = false;
            btn_salvar_raca_pet.Enabled = true;
            txt_raca_pet.Text = "";


        }

        //pesquisa de TIPOS ao digitar no textbox da tabela TIPOS
        private void txt_pesquisar_tipo_TextChanged(object sender, EventArgs e)
        {
            if (txt_pesquisar_tipo.Text == "")
            {
                tipo_animalBLL TipoAnimalBLL = new tipo_animalBLL();
                dtListar_tipo_animais.DataSource = TipoAnimalBLL.listarTipoAnimais();
            }
            else
            {
                tipo_animal TipoAnimal = new tipo_animal();
                pesquisarSoTipos(TipoAnimal);
            }
        }

        //pesquisa de raça ao digitar no textbox da tabela raças
        private void txt_pesquisar_raca_TextChanged(object sender, EventArgs e)
        {
            if (txt_pesquisar_raca.Text == "")
            {
                raca_animalBLL raca_aniBLL = new raca_animalBLL();
                dt_raca_animal.DataSource = raca_aniBLL.listarRacaAnimais();
               
            }
            else
            {
                raca_animal racaAnimal = new raca_animal();
                pesquisarSoRacas(racaAnimal);
            }
        }
    }
}
