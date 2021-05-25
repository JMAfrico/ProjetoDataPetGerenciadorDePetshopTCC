using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Consultas_medicas.DAO
{
    //PASSO 1 : CRIAR A CONEXÃO
    public class conexao
    {
        //string strconecta = "server=localhost;user=root;database=petshop;port=3306;password=root;";//FATEC PC VISUAL 2018
        //string strconecta = "server=localhost;user=root;database=petshop;port=3306;pwd = ;";//PC
       // string strconecta = "server=localhost;user=root;database=petshop;port=3306;pwd = ;";//NOTEBOOK
        string strconecta = "server=localhost;user=root;database=petshop_2020;port=3306;pwd = ;";//NOTEBOOK
        protected MySqlConnection conection = null;
        
        //MÉTODO PARA ABRIR CONEXAO COM O BANCO
        public void AbrirConexao()
        {
            try
            {
                conection = new MySqlConnection(strconecta);
                conection.Open();
            }
            catch(Exception erro)
            {
                throw erro;
            }

        }

        //MÉTODO PARA FECHAR CONEXAO COM O BANCO
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
    }
}
