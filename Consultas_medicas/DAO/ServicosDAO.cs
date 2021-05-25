using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;
using MySql.Data.MySqlClient;

namespace Consultas_medicas.DAO
{
    public class ServicosDAO : conexao
    {
        MySqlCommand comando = null;

        //query para salvar serviços no banco de dados
        public void Salvar(Servicos servicos)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_servicos(nome_servico,preco_servico) VALUES (@nome_servico,@preco_servico)", conection);

                comando.Parameters.AddWithValue("@nome_servico", servicos.nome_servico);
                comando.Parameters.AddWithValue("@preco_servico", servicos.preco_servico);

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

        //query para editar serviços no Banco de dados
        public void Editar(Servicos servicos)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE tb_servicos SET nome_servico = @nome_servico ,preco_servico = @preco_servico WHERE cod_servico = @cod_servico", conection);
                
                comando.Parameters.AddWithValue("@nome_servico", servicos.nome_servico);
                comando.Parameters.AddWithValue("@preco_servico", servicos.preco_servico);
                comando.Parameters.AddWithValue("@cod_servico", servicos.cod_servico);


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

        //query para excluir servicos no Banco de dados
        public void Excluir(Servicos servicos)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_servicos WHERE cod_servico = @cod_servico ", conection);

                comando.Parameters.AddWithValue("@cod_servico", servicos.cod_servico);

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

        //query para listar servicos no Banco de dados
        public DataTable listarServicos()
        {
            try
            {
                AbrirConexao();

                DataTable dtservico = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_servico AS 'COD' , nome_servico AS 'SERVICO', preco_servico AS 'PRECO' from tb_servicos", conection);
                da.SelectCommand = comando;
                da.Fill(dtservico);
                return dtservico;

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

        //método para listar os servicos no combobox do formulario de consultas
        public DataTable listarServicosCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_servico,nome_servico,preco_servico FROM tb_servicos", conection);
                da.SelectCommand = comando;
                da.Fill(dt);

                return dt;

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

        //query para pesquisar serviços no banco de dados
        public DataTable Pesquisar(Servicos servicos)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                comando = new MySqlCommand("SELECT cod_servico AS 'COD' , nome_servico AS 'SERVICO', preco_servico AS 'PRECO' FROM tb_servicos WHERE nome_servico LIKE @nome_servico '%' ORDER BY nome_servico", conection);
                comando.Parameters.AddWithValue("@nome_servico", servicos.nome_servico);
                da.SelectCommand = comando;
                da.Fill(dtclientes);
                return dtclientes;

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
    }
}
