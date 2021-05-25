using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;//IMPORTAR PASTA MODEL
using MySql.Data.MySqlClient;//IMPORTA MYSQL CLIENTE
using System.Data;//IMPORTAR DATA
using System.Windows.Forms;

namespace Consultas_medicas.DAO
{
    public class tipo_animalDAO : conexao //TORNAR A CLASSE PUBLICA E HERDAR A CONEXAO
    {
        MySqlCommand comando = null;
        
        

        //query para salvar tipo de animal
        public void Salvar(tipo_animal tipo_animal) // tipo animal da pasta models
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_tipo_animal (nome_tipo_animal) VALUES (@nome_tipo_animal)", conection);
                comando.Parameters.AddWithValue("@nome_tipo_animal", tipo_animal.nome_tipo_animal);

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



        ////query para listar tipo de animais no datatable
        public DataTable listar_tipo_animais()
        {
            try
            {
                AbrirConexao();

                DataTable dtListar_animais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_tipo_animal AS 'CODIGO' ,nome_tipo_animal AS 'TIPO' FROM tb_tipo_animal ", conection);
                da.SelectCommand = comando;
                da.Fill(dtListar_animais);
                return dtListar_animais;

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

        ////query para listar tipo de animais no combobox (tabela consulta)
        public DataTable listarTipoAnimais_consulta()
        {
            try
            {
                AbrirConexao();

                DataTable dtListar_animais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_tipo_animal,nome_tipo_animal FROM tb_tipo_animal ", conection);
                da.SelectCommand = comando;
                da.Fill(dtListar_animais);
                return dtListar_animais;

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

        //query para exluir tipo de animal no Banco de dados
        public void Excluir(tipo_animal tipo_animal)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_tipo_animal WHERE cod_tipo_animal = @cod_tipo_animal", conection);

                comando.Parameters.AddWithValue("@cod_tipo_animal", tipo_animal.cod_tipo_animal);

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

        //query para editar tipo de animal no Banco de dados
        public void Editar(tipo_animal tipo_animal)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE tb_tipo_animal SET nome_tipo_animal = @nome_tipo_animal WHERE cod_tipo_animal = @cod_tipo_animal", conection);

                comando.Parameters.AddWithValue("@nome_tipo_animal", tipo_animal.nome_tipo_animal);
                comando.Parameters.AddWithValue("@cod_tipo_animal", tipo_animal.cod_tipo_animal);



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

        //query para pesquisar animais por nome do tipo no Banco de dados
        public DataTable Pesquisar(tipo_animal tipoAnimal)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();
                comando = new MySqlCommand("SELECT nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA' FROM tb_raca,tb_tipo_animal WHERE tb_raca.cod_tipo_animal = tb_tipo_animal.cod_tipo_animal AND nome_tipo_animal LIKE @nome_tipo_animal '%' ORDER BY nome_tipo_animal", conection);
                // FROM tb_cliente WHERE nomeCliente LIKE @nomeCliente '%' ORDER BY nomeCliente", conection);
                comando.Parameters.AddWithValue("@nome_tipo_animal", tipoAnimal.nome_tipo_animal);
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

        //query para pesquisar somente a raca na tabela raça
        public DataTable PesquisarTipos(tipo_animal tipoAnimal)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();
                comando = new MySqlCommand("SELECT cod_tipo_animal AS 'CODIGO' ,nome_tipo_animal AS 'TIPO' FROM tb_tipo_animal WHERE nome_tipo_animal LIKE @nome_tipo_animal '%' ORDER BY nome_tipo_animal", conection);
                // FROM tb_cliente WHERE nomeCliente LIKE @nomeCliente '%' ORDER BY nomeCliente", conection);
                comando.Parameters.AddWithValue("@nome_tipo_animal", tipoAnimal.nome_tipo_animal);
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

        ////query para listar todos animais no datatable
        public DataTable listar_todos_animais()
        {
            try
            {
                AbrirConexao();

                DataTable dtListar_animais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA' FROM tb_raca,tb_tipo_animal WHERE tb_raca.cod_tipo_animal = tb_tipo_animal.cod_tipo_animal ", conection);
                da.SelectCommand = comando;
                da.Fill(dtListar_animais);
                return dtListar_animais;

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
