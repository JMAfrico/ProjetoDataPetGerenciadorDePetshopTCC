using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.DAO;
using Consultas_medicas.BLL;
using Consultas_medicas.Models;


namespace Consultas_medicas
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        //evento do botão sair fecha a aplicação
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair ?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {


        }

        private void txtSenha_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {


        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {

        }

        //evento do cadastrar abre uma janela para cadastro de usuario
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Form_cadastrar_login novo = new Form_cadastrar_login();
            novo.ShowDialog();
        }

        private void validarAcesso()
        {
            var hora = label5.Text;

            var horarioInicial = TimeSpan.Parse("09:00");
            var horarioLimite = TimeSpan.Parse("18:00");
            var horarioAtual = TimeSpan.Parse(hora);

            
            

            LoginDAO login = new LoginDAO();
            login.verificarLogin(txtlogin.Text, txtSenha.Text);
            {
                if (teste_login.Checked == true)
                {

                    if ((horarioAtual < horarioInicial) || (horarioAtual > horarioLimite)) // SE O HORARIO É ANTES OU DEPOIS
                    {
                        MessageBox.Show("Acesso ao sistema: Segunda a sexta das 09:00hrs as 18:00 hrs", "Acesso não autorizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) // SE É DOMINGO
                    {
                        MessageBox.Show("Acesso ao sistema: Segunda a sexta das 09:00hrs as 18:00 hrs", "Acesso não autorizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) // SE É SABADO
                    {
                        MessageBox.Show("Acesso ao sistema: Segunda a sexta das 09:00hrs as 18:00 hrs", "Acesso não autorizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {
                        if (login.tem)
                        {
                            
                            MessageBox.Show("Login Efetuado com sucesso", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Menu_principal novos = new Menu_principal();
                            novos.Show();
                            this.Visible = false;
                        }

                        else 
                        {
                            MessageBox.Show("Login/Senha inválido\nTente novamente ", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                     }
                    
            


                }

                if (teste_login.Checked == false)
                {
                    if (login.tem)
                    {


                        MessageBox.Show("Login Efetuado com sucesso", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_principal novos = new Menu_principal();
                        novos.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Login/Senha inválido\nTente novamente ", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }        
        }
        //evento do botão login verifica se o login e a senha existem e se são iguais a que esta cadastrado no banco, 
        //se sim, abre o formulario
        //se não , nao abre o formulário
        private void btn_login_Click(object sender, EventArgs e)
        {
            validarAcesso();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void Form_Login_Load(object sender, EventArgs e)
        {


            
        }

        private void Form_Login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //evento do botão login verifica se o login e a senha existem e se são iguais a que esta cadastrado no banco, 
        //se sim, abre o formulario
        //se não , nao abre o formulário
        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginDAO login = new LoginDAO();
                login.verificarLogin(txtlogin.Text, txtSenha.Text);
                {
                    if (login.tem)
                    {
                        /*MessageBox.Show("Login Efetuado com sucesso", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_principal novo = new Menu_principal();
                        novo.Show();
                        this.Visible = false;*/
                        string user = txtlogin.Text;
                        DateTime data_login = DateTime.Now;

                        MessageBox.Show("Login Efetuado com sucesso", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_principal novos = new Menu_principal(user, data_login);
                        novos.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha inválido\nTente novamente", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //evento do botão login verifica se o login e a senha existem e se são iguais a que esta cadastrado no banco, 
        //se sim, abre o formulario
        //se não , nao abre o formulário
        private void txtlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginDAO login = new LoginDAO();
                login.verificarLogin(txtlogin.Text, txtSenha.Text);
                {
                    if (login.tem)
                    {
                        MessageBox.Show("Login Efetuado com sucesso", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_principal novo = new Menu_principal();
                        novo.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha inválido\nTente novamente", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Dia()
        {
                     if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("Acesso ao sistema: Segunda a sexta das 09:00hrs as 18:00 hrs", "Acesso não autorizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                     if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                     {
                         MessageBox.Show("Acesso ao sistema: Segunda a sexta das 09:00hrs as 18:00 hrs", "Acesso não autorizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dia();
        }

    }
}
