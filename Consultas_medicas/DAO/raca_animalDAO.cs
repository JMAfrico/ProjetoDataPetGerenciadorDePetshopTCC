using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace Consultas_medicas.DAO
{
    public class raca_animalDAO : conexao
    {
        MySqlCommand comando = null;

        //query para salvar raca de animal
        public void Salvar(raca_animal raca_animal) // tipo animal da pasta models
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_raca (cod_tipo_animal,nome_raca_animal) VALUES (@cod_tipo_animal,@nome_raca_animal) ", conection);
                comando.Parameters.AddWithValue("@cod_tipo_animal", raca_animal.cod_raca_animal);
                comando.Parameters.AddWithValue("@nome_raca_animal", raca_animal.nome_raca_animal);
                

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

        ////query para listar RACA de animais no datatable
        public DataTable listar_raca_animais()
        {
            try
            {
                AbrirConexao();

                DataTable dtListar_animais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //comando = new MySqlCommand("SELECT nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA' FROM tb_raca,tb_tipo_animal WHERE tb_raca.cod_raca_animal = tb_tipo_animal.cod_tipo_animal ", conection);
                comando = new MySqlCommand("SELECT cod_raca AS 'CODIGO', cod_tipo_animal AS 'TIPO' ,nome_raca_animal AS 'RACA' FROM tb_raca ", conection);
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

        ////query para listar RACA de animais no combobox(tb_consulta)
        public DataTable listarRacaAnimais_combobox()
        {
            try
            {
                AbrirConexao();

                DataTable dtListar_animais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_raca,nome_raca_animal FROM tb_raca ", conection);
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

        //query para excluir raca de animal no Banco de dados
        public void Excluir(raca_animal raca_animal)
        {
            try
            {
                AbrirConexao();

                //comando = new MySqlCommand("DELETE FROM tb_raca WHERE nome_raca_animal = @nome_raca_animal", conection);
                comando = new MySqlCommand("DELETE FROM tb_raca WHERE cod_raca = @cod_raca", conection);

                comando.Parameters.AddWithValue("@cod_raca", raca_animal.codigo_index_raca);


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

        //query para editar raca de animal no Banco de dados
        public void Editar(raca_animal Raca_animal)
        {
            try
            {
                AbrirConexao();

             //   comando = new MySqlCommand("UPDATE tb_raca SET nome_raca_animal = @nome_raca_animal, cod_raca_animal = @cod_raca_animal WHERE cod_raca_animal = @cod_raca_animal AND nome_raca_animal = @nome_raca_animal", conection);                                     
               //(funcionando) comando = new MySqlCommand("UPDATE tb_raca SET nome_raca_animal = @nome_raca_animal, cod_raca_animal = @cod_raca_animal WHERE codigo_index_raca = @codigo_index_raca", conection);
                comando = new MySqlCommand("UPDATE tb_raca SET nome_raca_animal = @nome_raca_animal, cod_tipo_animal = @cod_tipo_animal WHERE cod_raca = @cod_raca", conection);

                comando.Parameters.AddWithValue("@cod_raca", Raca_animal.codigo_index_raca);
                comando.Parameters.AddWithValue("@nome_raca_animal", Raca_animal.nome_raca_animal);
                comando.Parameters.AddWithValue("@cod_tipo_animal", Raca_animal.cod_raca_animal);
                


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

        //método para listar os tipos de animais no formulario raca de animais
        public DataTable listarTipoAnimalCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT nome_tipo_animal,cod_tipo_animal FROM tb_tipo_animal", conection);
               // comando = new MySqlCommand("SELECT nome_raca_animal,cod_raca_animal FROM tb_raca inner join tb_tipo_animal ON tb_raca.cod_raca_animal = tb_tipo_animal.cod_tipo_animal", conection);
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

        //query para pesquisar animais por nome da raça Banco de dados
        public DataTable Pesquisar(raca_animal Raca_animal)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();
                comando = new MySqlCommand("SELECT nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA' FROM tb_raca,tb_tipo_animal WHERE tb_raca.cod_tipo_animal = tb_tipo_animal.cod_tipo_animal AND nome_raca_animal LIKE @nome_raca_animal '%' ORDER BY nome_raca_animal", conection);
                comando.Parameters.AddWithValue("@nome_raca_animal", Raca_animal.nome_raca_animal);
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


        //query para pesquisar raca por nome no textbox da tabela raça
        public DataTable Pesquisar_txt_raca(raca_animal Raca_animal)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();
                
                comando = new MySqlCommand("SELECT cod_raca AS 'CODIGO', cod_tipo_animal AS 'TIPO' ,nome_raca_animal AS 'RACA' FROM tb_raca WHERE nome_raca_animal LIKE @nome_raca_animal '%' ORDER BY nome_raca_animal", conection);
                comando.Parameters.AddWithValue("@nome_raca_animal", Raca_animal.nome_raca_animal);
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
