using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;// ADICIONAR O MODELS VETERINARIO
using MySql.Data.MySqlClient;//   ADICIONAR A STRING DE CONEXAO
using System.Data;

namespace Consultas_medicas.DAO
{
    public class Especialidade_veterinariaDAO : conexao
    {
        MySqlCommand comando = null;

        public void Salvar(Especializacao_veterinaria especialidade)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_especialidade_medica(nome_especialidade) VALUES (@nome_especialidade)", conection);
                comando.Parameters.AddWithValue("@nome_especialidade", especialidade.nome_especialidade);
                comando.Parameters.AddWithValue("@cod_especialidade", especialidade.cod_especialidade);
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

        public DataTable listarEspecialidades()
        {
            try
            {
                AbrirConexao();
                DataTable dtveterinario = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT cod_especialidade AS 'CODIGO',nome_especialidade AS 'ESPECIALIDADE' FROM tb_especialidade_medica", conection);
                da.SelectCommand = comando;
                da.Fill(dtveterinario);
                return dtveterinario;

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

        //query para editar veterinario no Banco de dados
        public void Editar(Especializacao_veterinaria especialidade)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("UPDATE tb_especialidade_medica SET cod_especialidade = @cod_especialidade ,nome_especialidade = @nome_especialidade WHERE cod_especialidade = @cod_especialidade", conection);

                comando.Parameters.AddWithValue("@cod_especialidade", especialidade.cod_especialidade);
                comando.Parameters.AddWithValue("@nome_especialidade", especialidade.nome_especialidade);
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


        //query para exluir veterinario no Banco de dados
        public void Excluir(Especializacao_veterinaria especialidade)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_especialidade_medica WHERE cod_especialidade = @cod_especialidade ", conection);
                comando.Parameters.AddWithValue("@cod_especialidade", especialidade.cod_especialidade);
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


        public DataTable PesquisarNomeEspecialidade(Especializacao_veterinaria especialidade)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtveterinario = new DataTable();

                comando = new MySqlCommand("SELECT cod_especialidade AS 'CODIGO',nome_especialidade AS 'ESPECIALIDADE FROM tb_especialidade_medica WHERE nome_especialidade LIKE @nome_especialidade '%'", conection);
                comando.Parameters.AddWithValue("@nomeVeterinario", especialidade.nome_especialidade);
                da.SelectCommand = comando;
                da.Fill(dtveterinario);
                return dtveterinario;

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

        //método para listar os veterinarios no combobox do formulario de consultas
        public DataTable listarEspecialidadesCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_especialidade,nome_especialidade FROM tb_especialidade_medica", conection);
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
    }
}
