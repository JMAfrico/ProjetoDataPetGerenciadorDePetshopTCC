using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.BLL;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;

namespace Consultas_medicas
{
    public partial class Form_cadastrar_login : Form
    {
        public Form_cadastrar_login()
        {
            InitializeComponent();
        }

        //evento do botão sair ,volta pro formulario login
        private void btn_sair_Click(object sender, EventArgs e)
        {
            Form_Login novo = new Form_Login();
            novo.Show();
            this.Visible = false;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {

        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {

        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {

        }

        private void txtConfirmaSenha_Enter(object sender, EventArgs e)
        {

        }

        private void txtConfirmaSenha_Leave(object sender, EventArgs e)
        {

        }

        //Método salvar, salva o novo usuario e senha cadastrada
        private void salvar(Login login)
        {


            try
            {
                if (txtUsuario.Text.Trim() == string.Empty || txtSenha.Text.Trim() == string.Empty || txtConfirmaSenha.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!(txtSenha.Text.Equals(txtConfirmaSenha.Text)))
                {
                    MessageBox.Show("Senhas não combinam, por favor digite novamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { 

                    LoginBLL loginBll = new LoginBLL();

                    login.nomeUsuario = txtUsuario.Text;
                    login.senhaUsuario = txtSenha.Text;
                    login.confirmarSenha = txtConfirmaSenha.Text;

                    loginBll.salvar(login);

                    MessageBox.Show("USUÁRIO cadastrado com sucesso", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    txtSenha.Clear();
                    txtConfirmaSenha.Clear();

                    Form_Login novo = new Form_Login();
                    novo.Visible = true;
                    this.Visible = false;
            
            }
                                
            }

            catch (MySqlException erro)
            {
                MessageBox.Show("Usuário já existe \n" + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento do botão salvar é executado após o método salvar, e salva no banco de dados.
        private void btn_cadastro_Click(object sender, EventArgs e)
        {							
            Login login = new Login();
            salvar(login);
 
        }

        private void txtConfirmaSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    
}
