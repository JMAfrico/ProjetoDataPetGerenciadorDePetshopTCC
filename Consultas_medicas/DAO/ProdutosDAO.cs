using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.BLL;
using Consultas_medicas.DAO;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class ProdutosDAO : conexao
    {
        MySqlCommand comando = null;

        //query para salvar produtos no banco de dados
        public void Salvar(Produtos produtos)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_produtos(nome_produto,preco_produto) VALUES (@nome_produto,@preco_produto)", conection);

                comando.Parameters.AddWithValue("@nome_produto", produtos.nome_produto);
                comando.Parameters.AddWithValue("@preco_produto", produtos.preco_produto);

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



        //query para editar produtos no Banco de dados
        public void Editar(Produtos produtos)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE tb_produtos SET nome_produto = @nome_produto ,preco_produto = @preco_produto WHERE cod_produto = @cod_produto", conection);

                comando.Parameters.AddWithValue("@nome_produto", produtos.nome_produto);
                comando.Parameters.AddWithValue("@preco_produto", produtos.preco_produto);
                comando.Parameters.AddWithValue("@cod_produto", produtos.cod_produto);


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


        //query para excluir produtos no Banco de dados
        public void Excluir(Produtos produtos)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_produtos WHERE cod_produto = @cod_produto", conection);

                comando.Parameters.AddWithValue("@cod_produto", produtos.cod_produto);

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


        //query para listar produtos no Banco de dados(datatable)
        public DataTable listarProdutos()
        {
            try
            {
                AbrirConexao();

                DataTable dtservico = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_produto AS 'COD' , nome_produto AS 'PRODUTO', preco_produto AS 'PRECO' from tb_produtos", conection);
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


        //método para listar os produtos no combobox do formulario de consultas
        public DataTable listaProdutosCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_produto,nome_produto,preco_produto FROM tb_produtos", conection);
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


        //query para pesquisar produtos no banco de dados(datatable)
        public DataTable Pesquisar(Produtos produtos)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                comando = new MySqlCommand("SELECT cod_produto AS 'COD' , nome_produto AS 'PRODUTO', preco_produto AS 'PRECO' from tb_produtos WHERE nome_produto LIKE @nome_produto '%' ORDER BY nome_produto", conection);
                comando.Parameters.AddWithValue("@nome_produto", produtos.nome_produto);
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
