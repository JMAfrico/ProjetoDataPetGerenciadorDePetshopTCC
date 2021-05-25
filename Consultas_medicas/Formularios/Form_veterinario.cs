using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Consultas_medicas.BLL; // ADICIONAR ONDE ESTA OS COMANDO
using Consultas_medicas.Models; // ADICIONAR ONDE ESTÁ OS PARAMETROS
using MySql.Data.MySqlClient;

namespace Consultas_medicas
{
    using WebServiceCorreios;

    public partial class Form_veterinario : Form
    {
        public Form_veterinario()
        {
            InitializeComponent();
            listarVeterinarios();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            listaEspecialidade();
            listarEspeciNOdt();
            modoNormalEsp();
        }

        private void Form_medico_Load(object sender, EventArgs e)
        {
            listarVeterinarios();
            rd_nomemed.Checked = true;
            msg.SetToolTip(img_help, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n" +
            "Para pesquisar digite no campo de pesquisa");
            modoNormalEsp();
        }

        private void LocalizaCep(string cep)
        {
            try
            {
                using (var ws = new AtendeClienteClient())
                {
                    var resposta = ws.consultaCEP(cep);

                    txtEnd.Text = resposta.end;
                    txtBairro.Text = resposta.bairro;
                    txt_cidade.Text = resposta.cidade;
                    txt_estado.Text = resposta.uf;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
		
        //método para limpar os campos digitados
		private void limparCampos()
		{
			txtNome.Clear();
			//txt_Sobrenome.Clear();
			txtCRMV.Clear();
			txtEspecializacao.Clear();
			txtEnd.Clear();
			txtBairro.Clear();
			txtCep.Clear();
            txt_cidade.Clear();
            txt_estado.Clear();
			txtNum.Clear();
			txtComplem.Clear();
			txtEmail.Clear();
			txtelfixo.Clear();
			txtelCelular.Clear();
			txtCodveterinario.Clear();
            txtCRMV.BackColor = Color.Black;

        }

        public void listaEspecialidade()
        {
            Especialidade_veterinariaBLL especialidadeBLL = new Especialidade_veterinariaBLL();
            this.cb_especialidade.ValueMember = "cod_especialidade";
            this.cb_especialidade.DisplayMember = "nome_especialidade";
            this.cb_especialidade.DataSource = especialidadeBLL.listarEspecialidadeNoCombobox();
        }
        // Método para mover arrastar a tela
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Método para salvar veterinario no banco de dados
        private void salvar(Veterinarios veterinarios)//esse método deve ser privado
        {
            try
            {
                if (txtNome.Text.Trim() == string.Empty || 
                    //txt_Sobrenome.Text.Trim() == string.Empty ||
                    txtCRMV.Text.Trim() == string.Empty ||
                    txtEnd.Text.Trim() == string.Empty || 
                    txtBairro.Text.Trim() == string.Empty ||
                    txtCep.Text.Trim() == string.Empty || 
                    txtNum.Text.Trim() == string.Empty || 
                    txtComplem.Text.Trim() == string.Empty || 
                    txtEmail.Text.Trim() == string.Empty ||
                    txtelfixo.Text.Trim() == string.Empty || 
                    txtelCelular.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    VeterinarioBLL veterinariosBLL = new VeterinarioBLL();

                    string idEspecialidade = cb_especialidade.SelectedValue.ToString();

                    veterinarios.nomeVeterinario = txtNome.Text;
                    //veterinarios.sobrenomeVeterinario = txt_Sobrenome.Text;
                    veterinarios.crmv = txtCRMV.Text;
                    veterinarios.especializacao = Convert.ToInt32(idEspecialidade);
                    veterinarios.enderecoVeterinario = txtEnd.Text;
                    veterinarios.cidadeVeterinario = txt_cidade.Text;
                    veterinarios.estadoVeterinario = txt_estado.Text;
                    veterinarios.bairroVeterinario = txtBairro.Text;
                    veterinarios.cepVeterinario = txtCep.Text;
                    veterinarios.numeroResidenciaVeterinario = Convert.ToInt32(txtNum.Text);
                    veterinarios.complementoVeterinario = txtComplem.Text;
                    veterinarios.emailVeterinario = txtEmail.Text;
                    veterinarios.telefoneFixoVet = Convert.ToInt64(txtelfixo.Text);
                    veterinarios.telefoneCelularVet = Convert.ToInt64(txtelCelular.Text);

                    veterinariosBLL.salvar(veterinarios);

                    MessageBox.Show("Cadastro de Veterinário efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); limparCampos();
                    listarVeterinarios();
                }

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("CRMV já existe \n " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCRMV.BackColor = Color.DimGray;
                txtCRMV.Focus();

            }
        }

        //evento do botão salvar
        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR VETERINARIO ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Veterinarios veterinarios = new Veterinarios();
                salvar(veterinarios);
            }
        }
		
		
        //Método para excluir veterinario no banco de dados
		private void excluir(Veterinarios veterinarios)//esse método deve ser privado
        {
            try
            {
                VeterinarioBLL veterinariosBLL = new VeterinarioBLL();
				veterinarios.codVeterinario = Convert.ToInt32(txtCodveterinario.Text);

                veterinariosBLL.excluir(veterinarios);
					//ou excluir com maiuscula
                MessageBox.Show("Veterinário excluído com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                btn_editar.Enabled = false;
                btn_deletar.Enabled = false;
                btn_salvar_medico.Enabled = true;
                listarVeterinarios();
                modoNormal();

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Você não tem permissão para Excluir " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento do botão excluir
        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma excluir veterinário ?", "EXCLUIR VETERINÁRIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Veterinarios veterinarios = new Veterinarios();
                excluir(veterinarios);
            }
        }

        //Método para editar veterinario no banco de dados
        private void editar(Veterinarios veterinarios)
        {
            try
            {
                if (txtNome.Text.Trim() == string.Empty || 
                    //txt_Sobrenome.Text.Trim() == string.Empty || 
                    txtCRMV.Text.Trim() == string.Empty ||
                txtEnd.Text.Trim() == string.Empty || 
                txtBairro.Text.Trim() == string.Empty ||
                txtCep.Text.Trim() == string.Empty || 
                txtNum.Text.Trim() == string.Empty || 
                txtComplem.Text.Trim() == string.Empty ||
                txtEmail.Text.Trim() == string.Empty ||
                txtelfixo.Text.Trim() == string.Empty || 
                txtelCelular.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    VeterinarioBLL veterinariosBLL = new VeterinarioBLL();

                    string idEspecialidade = cb_especialidade.SelectedValue.ToString();

                    veterinarios.codVeterinario = Convert.ToInt32(txtCodveterinario.Text);
                    veterinarios.nomeVeterinario = txtNome.Text;
                    //veterinarios.sobrenomeVeterinario = txt_Sobrenome.Text;
                    veterinarios.crmv = txtCRMV.Text;
                    veterinarios.especializacao = Convert.ToInt32(idEspecialidade);
                    veterinarios.enderecoVeterinario = txtEnd.Text;
                    veterinarios.cidadeVeterinario = txt_cidade.Text;
                    veterinarios.estadoVeterinario = txt_estado.Text;
                    veterinarios.bairroVeterinario = txtBairro.Text;
                    veterinarios.cepVeterinario = txtCep.Text;
                    veterinarios.numeroResidenciaVeterinario = Convert.ToInt32(txtNum.Text);
                    veterinarios.complementoVeterinario = txtComplem.Text;
                    veterinarios.emailVeterinario = txtEmail.Text;
                    veterinarios.telefoneFixoVet = Convert.ToInt64(txtelfixo.Text);
                    veterinarios.telefoneCelularVet = Convert.ToInt64(txtelCelular.Text);

                    veterinariosBLL.editar(veterinarios);

                    MessageBox.Show("Alteração de veterinário efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); limparCampos();
                    btn_editar.Enabled = false;
                    btn_deletar.Enabled = false;
                    btn_salvar_medico.Enabled = true;
                    listarVeterinarios();
                    modoNormal();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Você não tem permissão para Alterar, CRMV já existe " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento do botão editar
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração ?", "ALTERAR VETERINARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Veterinarios veterinarios = new Veterinarios();
                editar(veterinarios);
            }
        }

        //método lista os veterinarios no datasource(NA TABELA)
        private void listarVeterinarios()
        {
            VeterinarioBLL veterinarioBLL = new VeterinarioBLL();
            dtVeterinario.DataSource = veterinarioBLL.listarVeterinarios();
        }

        private void listarEspeciNOdt()
        {
            Especialidade_veterinariaBLL especBll= new Especialidade_veterinariaBLL();
            dt_especialidades.DataSource = especBll.listarEspecialidades();
        }


        private void button1_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //


        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {//SOMENTE NÚMEROS COM BACKSPACE = funcionando
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {//SOMENTE LETRAS COM BACKSPACE = funcionando
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txtCRMV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt_Sobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }*/
        }

        private void txtEspecializacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txtEnd_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtVeterinario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modoEdicao();
            btn_editar.Enabled = true;
            btn_deletar.Enabled = true;
            btn_salvar_medico.Enabled = false;

            lblNome.Text = dtVeterinario.CurrentRow.Cells["NOME"].Value.ToString();
            //lblSobrenome.Text = dtVeterinario.CurrentRow.Cells["SOBRENOME"].Value.ToString();
            lblCRMV.Text = dtVeterinario.CurrentRow.Cells["CRMV"].Value.ToString();
            cb_especialidade.Text = dtVeterinario.CurrentRow.Cells["ESPECIALIZACAO"].Value.ToString();
            lblEnd.Text = dtVeterinario.CurrentRow.Cells["ENDERECO"].Value.ToString();
            lblBairro.Text = dtVeterinario.CurrentRow.Cells["BAIRRO"].Value.ToString();
            lblCep.Text = dtVeterinario.CurrentRow.Cells["CEP"].Value.ToString();
            lblNum.Text = dtVeterinario.CurrentRow.Cells["NUMERO"].Value.ToString();
            lblComplemento.Text = dtVeterinario.CurrentRow.Cells["COMPLEMENTO"].Value.ToString();
            lblEmail.Text = dtVeterinario.CurrentRow.Cells["EMAIL"].Value.ToString();
            lblFixo.Text = dtVeterinario.CurrentRow.Cells["FIXO"].Value.ToString();
            lblCel.Text = dtVeterinario.CurrentRow.Cells["CELULAR"].Value.ToString();
            lbl_cidade.Text = dtVeterinario.CurrentRow.Cells["CIDADE"].Value.ToString();
            lbl_estado.Text = dtVeterinario.CurrentRow.Cells["ESTADO"].Value.ToString();

            txtCodveterinario.Text = dtVeterinario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dtVeterinario.CurrentRow.Cells[1].Value.ToString();
            //txt_Sobrenome.Text = dtVeterinario.CurrentRow.Cells[2].Value.ToString();
            txtCRMV.Text = dtVeterinario.CurrentRow.Cells[2].Value.ToString();
            lblEspec.Text = dtVeterinario.CurrentRow.Cells[3].Value.ToString();
            txt_estado.Text = dtVeterinario.CurrentRow.Cells[6].Value.ToString();
            txt_cidade.Text = dtVeterinario.CurrentRow.Cells[5].Value.ToString();
            txtEnd.Text = dtVeterinario.CurrentRow.Cells[4].Value.ToString();
            txtBairro.Text = dtVeterinario.CurrentRow.Cells[7].Value.ToString();
            txtCep.Text = dtVeterinario.CurrentRow.Cells[8].Value.ToString();
            txtNum.Text = dtVeterinario.CurrentRow.Cells[9].Value.ToString();
            txtComplem.Text = dtVeterinario.CurrentRow.Cells[10].Value.ToString();
            txtEmail.Text = dtVeterinario.CurrentRow.Cells[11].Value.ToString();
            txtelfixo.Text = dtVeterinario.CurrentRow.Cells[12].Value.ToString();
            txtelCelular.Text = dtVeterinario.CurrentRow.Cells[13].Value.ToString();

        }


        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }


		
		//Método para pesquisar veterinario por nome
		private void pesquisar(Veterinarios veterinarios)
		{
            try
            {
                veterinarios.nomeVeterinario = txtPesquisar.Text.Trim();

                VeterinarioBLL veterinariosBLL = new VeterinarioBLL();

                dtVeterinario.DataSource = veterinariosBLL.pesquisar(veterinarios);
            }
            catch(System.Exception erro)
            {
                throw erro;
            }
		}

        //Método para pesquisar veterinario por CRMV
        private void pesquisarCRMV(Veterinarios veterinarios)
        {
            try
            {
                veterinarios.crmv = txtPesquisar.Text.Trim();

                VeterinarioBLL veterinariosBLL = new VeterinarioBLL();

                dtVeterinario.DataSource = veterinariosBLL.pesquisarCRMV(veterinarios);
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //evento do botão pesquisar
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (rd_nomemed.Checked == true)
            {
                if (txtPesquisar.Text == "")
                {
                    VeterinarioBLL veterinariosBLL = new VeterinarioBLL();
                    dtVeterinario.DataSource = veterinariosBLL.listarVeterinarios();
                }
                else
                {

                    Veterinarios veterinarios = new Veterinarios();
                    pesquisar(veterinarios);
                }
            }
            if (rd_crmv.Checked == true)
            {
                if (txtPesquisar.Text == "")
                {
                    VeterinarioBLL veterinariosBLL = new VeterinarioBLL();
                    dtVeterinario.DataSource = veterinariosBLL.listarVeterinarios();
                }
                else
                {

                    Veterinarios veterinarios = new Veterinarios();
                    pesquisarCRMV(veterinarios);
                }
            }



        }



        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //evento ao sair do textbox para executar método localiza cep
        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (txtCep.Text != "" || (txtCep.Text.Length >= 1 && txtCep.Text.Length < 8))
            {
                LocalizaCep(txtCep.Text);
            }
            
        }

        private void txtCRMV_Leave(object sender, EventArgs e)
        {
            if(txtCRMV.Text.Length >=1 && txtCRMV.Text.Length < 5)
            {
                MessageBox.Show("CRMV inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCRMV.Clear();
            }
        }

        private void txtelfixo_Leave(object sender, EventArgs e)
        {
            if (txtelfixo.Text.Length >=1 && txtelfixo.Text.Length < 10)
            {
                MessageBox.Show("Telefone inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtelfixo.Clear();
            }
        }

        private void txtelCelular_Leave(object sender, EventArgs e)
        {
            if (txtelCelular.Text.Length >= 1 && txtelCelular.Text.Length < 11)
            {
                MessageBox.Show("Celular inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtelCelular.Clear();
            }
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void txtCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtBairro_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_cidade_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_estado_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txtEnd_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        public void modoEdicao()
        {
            //txt_nome_servico.BackColor = Color.Green;
            txtCodveterinario.BackColor = Color.Green;
            txtNome.BackColor = Color.Green;
            //txt_Sobrenome.BackColor = Color.Green;
            txtCRMV.BackColor = Color.Green;
            txtEnd.BackColor = Color.Green;
            txtBairro.BackColor = Color.Green;
            txtCep.BackColor = Color.Green;
            txtNum.BackColor = Color.Green;
            txtComplem.BackColor = Color.Green;
            txtEmail.BackColor = Color.Green;
            txtelfixo.BackColor = Color.Green;
            txtelCelular.BackColor = Color.Green;
            txt_cidade.BackColor = Color.Green;
            txt_estado.BackColor = Color.Green;
            txtEmail.BackColor = Color.Green;
            txtEspecializacao.BackColor = Color.Green;
            cb_especialidade.BackColor = Color.Green;
        }

        public void modoEdicaoEsp()
        {
            btn_deletar_especialidade.Enabled = true;
            btn_editar_especialidade.Enabled = true;
            btn_salvar_especialidade.Enabled = false;
            txt_cod_especialidade.BackColor = Color.Green;
            txt_nome_especialidade.BackColor = Color.Green;
        }

        public void modoNormalEsp()
        {
            btn_deletar_especialidade.Enabled = false;
            btn_editar_especialidade.Enabled = false;
            btn_salvar_especialidade.Enabled = true;
            txt_cod_especialidade.BackColor = Color.FromArgb(23, 32, 40);
            txt_nome_especialidade.BackColor = Color.FromArgb(23, 32, 40);
            txt_nome_especialidade.Clear();
            txt_cod_especialidade.Clear();
        }


        public void modoNormal()
        {
            //txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            txtCodveterinario.BackColor = Color.FromArgb(23, 32, 40);
            //txt_Sobrenome.BackColor = Color.FromArgb(23, 32, 40);
            txtNome.BackColor = Color.FromArgb(23, 32, 40);
            txtCRMV.BackColor = Color.FromArgb(23, 32, 40);
            txtEnd.BackColor = Color.FromArgb(23, 32, 40);
            txtBairro.BackColor = Color.FromArgb(23, 32, 40);
            txtCep.BackColor = Color.FromArgb(23, 32, 40);
            txtNum.BackColor = Color.FromArgb(23, 32, 40);
            txtComplem.BackColor = Color.FromArgb(23, 32, 40);
            txtEmail.BackColor = Color.FromArgb(23, 32, 40);
            txtelfixo.BackColor = Color.FromArgb(23, 32, 40);
            txtelCelular.BackColor = Color.FromArgb(23, 32, 40);
            txt_cidade.BackColor = Color.FromArgb(23, 32, 40);
            txt_estado.BackColor = Color.FromArgb(23, 32, 40);
            txtEmail.BackColor = Color.FromArgb(23, 32, 40);
            txtEspecializacao.BackColor = Color.FromArgb(23, 32, 40);
            cb_especialidade.BackColor = Color.FromArgb(23, 32, 40);

        }

        private void txtCRMV_TextChanged(object sender, EventArgs e)
        {

        }

        private void img_help_Click(object sender, EventArgs e)
        {

        }

        public void SalvarEspecialidade(Especializacao_veterinaria especialidade)
        {
            try
            {
                if (txt_nome_especialidade.Text == string.Empty)
                {
                    MessageBox.Show("Campo nome vazio");

                }
                else
                {
                    Especialidade_veterinariaBLL especialidadeBLL = new Especialidade_veterinariaBLL();
                    especialidade.nome_especialidade = txt_nome_especialidade.Text;
                    especialidadeBLL.salvar(especialidade);
                    MessageBox.Show("Cadastro de Especialidade efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); limparCampos();
                    listarEspeciNOdt();
                    modoNormalEsp();
                }
            }
            catch (System.Exception erro)
            {
                MessageBox.Show("Não foi possível salvar", erro.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR ESPECIALIDADE ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Especializacao_veterinaria especialidade = new Especializacao_veterinaria();
                SalvarEspecialidade(especialidade);
            }
        }

        private void dt_especialidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cod_especialidade.Text = dt_especialidades.CurrentRow.Cells[0].Value.ToString();
            txt_nome_especialidade.Text = dt_especialidades.CurrentRow.Cells[1].Value.ToString();
            modoEdicaoEsp();            
        }

        public void EditarEsp(Especializacao_veterinaria especialidade)
        {
            try
            {

                Especialidade_veterinariaBLL especialidadeBLL = new Especialidade_veterinariaBLL();
                especialidade.cod_especialidade = Convert.ToInt32(txt_cod_especialidade.Text);
                especialidade.nome_especialidade = txt_nome_especialidade.Text;

                especialidadeBLL.editar(especialidade);

                //ou excluir com maiuscula
                MessageBox.Show("Especialidade alterada com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarEspeciNOdt();
                modoNormalEsp();

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Você não tem permissão para Alterar " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_especialidade_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "ALTERAR ESPECIALIDADE ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Especializacao_veterinaria especialidade = new Especializacao_veterinaria();
                EditarEsp(especialidade);
            }
        }

        public void ExcluirEsp(Especializacao_veterinaria especialidade)
        {
            try
            {

                Especialidade_veterinariaBLL especialidadeBLL = new Especialidade_veterinariaBLL();
                especialidade.cod_especialidade = Convert.ToInt32(txt_cod_especialidade.Text);

                especialidadeBLL.excluir(especialidade);

                //ou excluir com maiuscula
                MessageBox.Show("Especialidade excluída com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarEspeciNOdt();
                modoNormalEsp();

            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Você não tem permissão para Excluir " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deletar_especialidade_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "ALTERAR ESPECIALIDADE ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Especializacao_veterinaria especialidade = new Especializacao_veterinaria();
                ExcluirEsp(especialidade);
            }
        }
    }
}
