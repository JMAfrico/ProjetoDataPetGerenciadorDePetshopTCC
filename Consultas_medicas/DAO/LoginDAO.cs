using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;//IMPORTAR PASTA MODEL
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class LoginDAO : conexao
    {

        MySqlCommand comando = null;

        //query para salvar um novo usuário no Banco de dados
        public void Salvar(Login login)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_login (nomeUsuario, senhaUsuario, confirmarSenha) VALUES (@nomeUsuario,@senhaUsuario,@confirmarSenha)", conection);
                comando.Parameters.AddWithValue("@nomeUsuario", login.nomeUsuario);
                comando.Parameters.AddWithValue("@senhaUsuario", login.senhaUsuario);
                comando.Parameters.AddWithValue("@confirmarSenha", login.confirmarSenha);

                comando.ExecuteNonQuery();


            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public bool tem = false;
        public string msg = "";
        MySqlDataReader dr;

        //query para verificar se existe esse usuário no Banco de dados
        public bool verificarLogin(string nomeUsuario, string senhaUsuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT nomeUsuario, senhaUsuario FROM tb_login WHERE nomeUsuario = @nomeUsuario AND senhaUsuario = @senhaUsuario", conection);
                comando.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
                comando.Parameters.AddWithValue("@senhaUsuario", senhaUsuario);
                comando.ExecuteNonQuery();
                dr = comando.ExecuteReader();

                if (dr.HasRows)//se foi encontrado
                {
                    tem = true;
                }
                
            }
            catch (MySqlException)//se nao foi encontrado
            {
                this.msg = "Erro com o banco de dados";
            }
            finally
            {
                
                FecharConexao();

            }
            return tem;


        }

    }

}


