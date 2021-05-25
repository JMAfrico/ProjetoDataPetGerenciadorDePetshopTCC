using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Consultas_medicas.BLL;
using Consultas_medicas.Models;
using Ferramentas;
using System.Net;
using System.IO;

namespace Consultas_medicas
{
    using WebServiceCorreios;

    public partial class Form_Funcionario : Form
    {
        public Form_Funcionario()
        {
            InitializeComponent();
            listarFuncionarios();
            btn_editar.Enabled = false;
            btn_deletar.Enabled = false;
            txtNome.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }
        //método para localizar cep
        private void LocalizaCep(string cep)
        {
            try
            {
                using (var ws = new AtendeClienteClient())
                {
                    var resposta = ws.consultaCEP(cep);

                    txtEndereco.Text = resposta.end;
                    txtBairro.Text = resposta.bairro;
                    txt_cidade_func.Text = resposta.cidade;
                    txt_estado_func.Text = resposta.uf;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "SALVAR FUNCIONARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Funcionarios funcionarios = new Funcionarios();
                salvar(funcionarios);
            }
        }

        private void limparCampos()
        {

            txtcodfunci.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtCel.Clear();
            txttelFixo.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txt_cidade_func.Clear();
            txt_estado_func.Clear();
            txtCep.Clear();
            txtCel.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();

        }
        private void salvar(Funcionarios funcionarios)
        {
            try
            {
                if (txtNome.Text.Trim() == string.Empty || 
                    txtEndereco.Text.Trim() == string.Empty || 
                    txtBairro.Text.Trim() == string.Empty ||
                    txtCep.Text.Trim() == string.Empty || 
                    txtNumero.Text.Trim() == string.Empty || 
                    txtComplemento.Text.Trim() == string.Empty ||
                    txtEmail.Text.Trim() == string.Empty ||
                    txttelFixo.Text.Trim() == string.Empty || 
                    txtCel.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

                    //funcionarios.codFuncionario = Convert.ToInt32(txtcodfunci.Text);
                    funcionarios.nomeFuncionario = txtNome.Text;
                    funcionarios.emailFuncionario = txtEmail.Text;
                    funcionarios.telefoneCelularFunc = Convert.ToInt64(txtCel.Text);
                    funcionarios.telefoneFixoFunc = Convert.ToInt64(txttelFixo.Text);
                    funcionarios.enderecoFuncionario = txtEndereco.Text;
                    funcionarios.estadoFuncionario = txt_estado_func.Text;
                    funcionarios.cidadeFuncionario = txt_cidade_func.Text;
                    funcionarios.bairroFuncionario = txtBairro.Text;
                    funcionarios.cepFuncionario = txtCep.Text;
                    funcionarios.numeroResidenciaFuncionario = Convert.ToInt32(txtNumero.Text);
                    funcionarios.complementoFuncionario = txtComplemento.Text;

                    funcionarioBLL.salvar(funcionarios);

                    MessageBox.Show("Cadastro de Funcionário     efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); limparCampos();
                    txtCep.BackColor = Color.Black;
                    btn_salvar_medico.Enabled = true;
                    btn_deletar.Enabled = false;
                    btn_editar.Enabled = false;
                    listarFuncionarios();
                }
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        //--------------
        private void excluir(Funcionarios funcionarios)
        {
            try
            {
                FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

                funcionarios.codFuncionario = Convert.ToInt32(txtcodfunci.Text);

                funcionarioBLL.excluir(funcionarios);

                MessageBox.Show("Funcionário Excluído com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                btn_salvar_medico.Enabled = true;
                btn_deletar.Enabled = false;
                btn_editar.Enabled = false;
                listarFuncionarios();
                modoNormal();
                
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }


        private void listarFuncionarios()
        {
            FuncionarioBLL funcionarioBll = new FuncionarioBLL();
            dtFuncionario.DataSource = funcionarioBll.listarFuncionarios();

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
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

        private void txtSobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }*/
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

        private void txtCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtFuncionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            modoEdicao();
            btn_salvar_medico.Enabled = false;
            btn_deletar.Enabled = true;
            btn_editar.Enabled = true;

            lbl_nome.Text = dtFuncionario.CurrentRow.Cells[1].Value.ToString();
            //lblSobrenome.Text = dtFuncionario.CurrentRow.Cells[2].Value.ToString();
            lblEmail.Text = dtFuncionario.CurrentRow.Cells[2].Value.ToString();
            lblFixo.Text = dtFuncionario.CurrentRow.Cells[3].Value.ToString();
            lblCel.Text = dtFuncionario.CurrentRow.Cells[4].Value.ToString();
            lblEndereco.Text = dtFuncionario.CurrentRow.Cells[5].Value.ToString();
            lbl_cidade.Text = dtFuncionario.CurrentRow.Cells[6].Value.ToString();
            lbl_estado.Text = dtFuncionario.CurrentRow.Cells[7].Value.ToString();
            lblBairro.Text = dtFuncionario.CurrentRow.Cells[8].Value.ToString();
            lblCep.Text = dtFuncionario.CurrentRow.Cells[9].Value.ToString();
            lblNumero.Text = dtFuncionario.CurrentRow.Cells[10].Value.ToString();
            lblComplemento.Text = dtFuncionario.CurrentRow.Cells[11].Value.ToString();

        
            txtcodfunci.Text = dtFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dtFuncionario.CurrentRow.Cells[1].Value.ToString();
            //txtSobrenome.Text = dtFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dtFuncionario.CurrentRow.Cells[2].Value.ToString();
            txttelFixo.Text = dtFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtCel.Text = dtFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtEndereco.Text = dtFuncionario.CurrentRow.Cells[5].Value.ToString();
            txt_cidade_func.Text = dtFuncionario.CurrentRow.Cells[6].Value.ToString();
            txt_estado_func.Text = dtFuncionario.CurrentRow.Cells[7].Value.ToString();
            txtBairro.Text = dtFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtCep.Text = dtFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtNumero.Text = dtFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtComplemento.Text = dtFuncionario.CurrentRow.Cells[11].Value.ToString();

        }

        private void dtFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar alteração ?", "ALTERAR FUNCIONARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Funcionarios funcionarios = new Funcionarios();
                editar(funcionarios);
            }

        }

        private void editar(Funcionarios funcionarios)
        {
            try
            {
                if (txtNome.Text.Trim() == string.Empty || 
                    txtEndereco.Text.Trim() == string.Empty || 
                    txtBairro.Text.Trim() == string.Empty ||
                    txtCep.Text.Trim() == string.Empty || 
                    txtNumero.Text.Trim() == string.Empty || 
                    txtComplemento.Text.Trim() == string.Empty ||
                    txtEmail.Text.Trim() == string.Empty ||
                    txttelFixo.Text.Trim() == string.Empty || 
                    txtCel.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("--Não foi possível salvar.\n--Verifique os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

                    funcionarios.codFuncionario = Convert.ToInt32(txtcodfunci.Text);
                    funcionarios.nomeFuncionario = txtNome.Text;
                    funcionarios.emailFuncionario = txtEmail.Text;
                    funcionarios.telefoneCelularFunc = Convert.ToInt64(txtCel.Text);
                    funcionarios.telefoneFixoFunc = Convert.ToInt64(txttelFixo.Text);
                    funcionarios.enderecoFuncionario = txtEndereco.Text;
                    funcionarios.estadoFuncionario = txt_estado_func.Text;
                    funcionarios.cidadeFuncionario = txt_cidade_func.Text;
                    funcionarios.bairroFuncionario = txtBairro.Text;
                    funcionarios.cepFuncionario = txtCep.Text;
                    funcionarios.numeroResidenciaFuncionario = Convert.ToInt32(txtNumero.Text);
                    funcionarios.complementoFuncionario = txtComplemento.Text;

                    funcionarioBLL.editar(funcionarios);

                    MessageBox.Show("Alteração de Funcionário efetuado com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); limparCampos();
                    btn_salvar_medico.Enabled = true;
                    btn_deletar.Enabled = false;
                    btn_editar.Enabled = false;
                    listarFuncionarios();
                    txtCep.BackColor = Color.Black;
                    modoNormal();
                }
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar exclusão ?", "EXCLUIR FUNCIONARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Funcionarios funcionarios = new Funcionarios();
                excluir(funcionarios);
            }
        }

        //-----------novos--------------------------
        private void pesquisar(Funcionarios funcionarios)
        {
            try
            {
                funcionarios.nomeFuncionario = txtPesquisar.Text.Trim();

                FuncionarioBLL funcionarioBll = new FuncionarioBLL();

                dtFuncionario.DataSource = funcionarioBll.pesquisar(funcionarios);
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Funcionario_Load(object sender, EventArgs e)
        {
            listarFuncionarios();
            msg_btnEditar.SetToolTip(img_help, "Para editar ou deletar, dê um duplo clique em algum item na tabela\n" +
            "Para pesquisar digite no campo de pesquisa");
        }

        private void txtPesquisar_TextChanged_1(object sender, EventArgs e)
        {
            if (txtPesquisar.Text == "")
            {
                FuncionarioBLL funcionarioBll = new FuncionarioBLL();
                dtFuncionario.DataSource = funcionarioBll.listarFuncionarios();
            }
            else
            {

                Funcionarios funcionarios = new Funcionarios();
                pesquisar(funcionarios);
            }
        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {

                e.Handled = true;
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (txtCep.Text != "" || (txtCep.Text.Length >= 1 && txtCep.Text.Length < 8))
            {
                LocalizaCep(txtCep.Text);
            }

        }

        private void txttelFixo_Leave(object sender, EventArgs e)
        {
            if (txttelFixo.Text.Length >= 1 && txttelFixo.Text.Length < 10)
            {
                MessageBox.Show("Telefone inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txttelFixo.Clear();
            }
        }

        private void txtCel_Leave(object sender, EventArgs e)
        {
            if (txtCel.Text.Length >= 1 && txtCel.Text.Length < 10)
            {
                MessageBox.Show("Celular inválido ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCel.Clear();
            }
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void txtBairro_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_cidade_func_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_estado_func_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txtEndereco_MouseClick(object sender, MouseEventArgs e)
        {
            txtCep.Focus();
        }

        private void txt_estado_func_TextChanged(object sender, EventArgs e)
        {
            txtCep.Focus();
        }

        public void modoEdicao()
        {
            //txt_nome_servico.BackColor = Color.Green;
            txtcodfunci.BackColor = Color.Green;
            txtNome.BackColor = Color.Green;
            //txtSobrenome.BackColor = Color.Green;
            txtEndereco.BackColor = Color.Green;
            txtBairro.BackColor = Color.Green;
            txtCep.BackColor = Color.Green;
            txtNumero.BackColor = Color.Green;
            txtComplemento.BackColor = Color.Green;
            txtEmail.BackColor = Color.Green;
            txttelFixo.BackColor = Color.Green;
            txtCel.BackColor = Color.Green;
            txt_cidade_func.BackColor = Color.Green;
            txt_estado_func.BackColor = Color.Green;
        }

        public void modoNormal()
        {
            //txt_nome_servico.BackColor = Color.FromArgb(23, 32, 40);
            txtcodfunci.BackColor = Color.FromArgb(23, 32, 40);
            txtNome.BackColor = Color.FromArgb(23, 32, 40);
            //txtSobrenome.BackColor = Color.FromArgb(23, 32, 40);
            txtEndereco.BackColor = Color.FromArgb(23, 32, 40);
            txtBairro.BackColor = Color.FromArgb(23, 32, 40);
            txtCep.BackColor = Color.FromArgb(23, 32, 40);
            txtNumero.BackColor = Color.FromArgb(23, 32, 40);
            txtComplemento.BackColor = Color.FromArgb(23, 32, 40);
            txtEmail.BackColor = Color.FromArgb(23, 32, 40);
            txttelFixo.BackColor = Color.FromArgb(23, 32, 40);
            txtCel.BackColor = Color.FromArgb(23, 32, 40);
            txt_cidade_func.BackColor = Color.FromArgb(23, 32, 40);
            txt_estado_func.BackColor = Color.FromArgb(23, 32, 40);

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void btn_editar_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

    }
}
