using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class LoginBLL
    {
        LoginDAO loginDao = new LoginDAO();


        //Método controlador para salvar novo usuario
        public void salvar(Login login)
        {
            try
            {
                loginDao.Salvar(login);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para verificar acesso de usuario
        public class Controle
        {
            public bool tem;
            public string msg = "";

            public bool acessar(string nomeUsuario, string senhaUsuario)//CONTROLE
            {
                LoginDAO logindao = new LoginDAO();
                tem = logindao.verificarLogin(nomeUsuario, senhaUsuario);
                if (!logindao.msg.Equals(""))
                {
                   this.msg = logindao.msg;
                }

                return tem;
            }

        }
    }
}
