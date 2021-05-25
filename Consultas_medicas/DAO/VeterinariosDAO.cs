using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;// ADICIONAR O MODELS VETERINARIO
using MySql.Data.MySqlClient;//   ADICIONAR A STRING DE CONEXAO
using System.Data;

namespace Consultas_medicas.DAO
{
    public class VeterinariosDAO : conexao // HERDA A CLASSE CONEXAO
    {
        MySqlCommand comando = null;

        //query para salvar veterinario no Banco de dados
        public void Salvar(Veterinarios veterinarios)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_veterinario(nomeVeterinario,crmv,especializacao,enderecoVeterinario,cidadeVeterinario,estadoVeterinario,bairroVeterinario,cepVeterinario,numeroResidenciaVeterinario,complementoVeterinario,emailVeterinario,telefoneFixoVet,telefoneCelularVet) VALUES (@nome,@crmv,@especializacao,@endereco,@cidade,@estado,@bairro,@cep,@numero,@complemento,@email,@telfixo,@telcel)", conection);

                comando.Parameters.AddWithValue("@nome",veterinarios.nomeVeterinario);
                comando.Parameters.AddWithValue("@crmv",veterinarios.crmv);
                comando.Parameters.AddWithValue("@especializacao",veterinarios.especializacao);
                comando.Parameters.AddWithValue("@endereco",veterinarios.enderecoVeterinario);
                comando.Parameters.AddWithValue("@cidade", veterinarios.cidadeVeterinario);
                comando.Parameters.AddWithValue("@estado", veterinarios.estadoVeterinario);
                comando.Parameters.AddWithValue("@bairro",veterinarios.bairroVeterinario);
                comando.Parameters.AddWithValue("@cep",veterinarios.cepVeterinario);
                comando.Parameters.AddWithValue("@numero",veterinarios.numeroResidenciaVeterinario);
                comando.Parameters.AddWithValue("@complemento",veterinarios.complementoVeterinario);
                comando.Parameters.AddWithValue("@email",veterinarios.emailVeterinario);
                comando.Parameters.AddWithValue("@telfixo",veterinarios.telefoneFixoVet);
                comando.Parameters.AddWithValue("@telcel",veterinarios.telefoneCelularVet);

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

        //query para listar os veterinarios do banco de dados
        public DataTable listarVeterinarios()
        {
            try
            {
                AbrirConexao();

                DataTable dtveterinario = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT codVeterinario AS 'CODIGO',nomeVeterinario AS 'NOME',crmv AS 'CRMV',ESP.nome_especialidade AS 'ESPECIALIZACAO',enderecoVeterinario AS 'ENDERECO',cidadeVeterinario AS 'CIDADE', estadoVeterinario AS 'ESTADO', bairroVeterinario AS 'BAIRRO',cepVeterinario AS 'CEP',numeroResidenciaVeterinario AS 'NUMERO',complementoVeterinario AS 'COMPLEMENTO',emailVeterinario AS 'EMAIL',telefoneFixoVet AS 'FIXO',telefoneCelularVet AS 'CELULAR' FROM tb_veterinario JOIN tb_especialidade_medica ESP on ESP.cod_especialidade = especializacao", conection);
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
        public void Editar(Veterinarios veterinarios)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE tb_veterinario SET nomeVeterinario = @nome, crmv = @crmv ,especializacao = @especializacao ,enderecoVeterinario = @endereco,cidadeVeterinario = @cidade , estadoVeterinario = @estado,bairroVeterinario = @bairro,cepVeterinario = @cep,numeroResidenciaVeterinario = @numero,complementoVeterinario = @complemento,emailVeterinario = @email,telefoneFixoVet = @telfixo,telefoneCelularVet = @telcel WHERE codVeterinario = @codVeterinario", conection);

                comando.Parameters.AddWithValue("@codVeterinario", veterinarios.codVeterinario);
                comando.Parameters.AddWithValue("@nome", veterinarios.nomeVeterinario);
                comando.Parameters.AddWithValue("@crmv", veterinarios.crmv);
                comando.Parameters.AddWithValue("@especializacao", veterinarios.especializacao);
                comando.Parameters.AddWithValue("@endereco", veterinarios.enderecoVeterinario);
                comando.Parameters.AddWithValue("@cidade", veterinarios.cidadeVeterinario);
                comando.Parameters.AddWithValue("@estado", veterinarios.estadoVeterinario);
                comando.Parameters.AddWithValue("@bairro", veterinarios.bairroVeterinario);
                comando.Parameters.AddWithValue("@cep", veterinarios.cepVeterinario);
                comando.Parameters.AddWithValue("@numero", veterinarios.numeroResidenciaVeterinario);
                comando.Parameters.AddWithValue("@complemento", veterinarios.complementoVeterinario);
                comando.Parameters.AddWithValue("@email", veterinarios.emailVeterinario);
                comando.Parameters.AddWithValue("@telfixo", veterinarios.telefoneFixoVet);
                comando.Parameters.AddWithValue("@telcel", veterinarios.telefoneCelularVet);


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
		public void Excluir(Veterinarios veterinarios) 
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_veterinario WHERE codVeterinario = @codVeterinario ", conection);

                comando.Parameters.AddWithValue("@codVeterinario", veterinarios.codVeterinario);

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

        //query para pesquisar veterinario por nome no Banco de dados
        public DataTable Pesquisar(Veterinarios veterinarios)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtveterinario = new DataTable();

                comando = new MySqlCommand("SELECT codVeterinario AS 'CODIGO',nomeVeterinario AS 'NOME',crmv AS 'CRMV',especializacao AS 'ESPECIALIZACAO',enderecoVeterinario AS 'ENDERECO',cidadeVeterinario AS 'CIDADE', estadoVeterinario AS 'ESTADO',bairroVeterinario AS 'BAIRRO',cepVeterinario AS 'CEP',numeroResidenciaVeterinario AS 'NUMERO',complementoVeterinario AS 'COMPLEMENTO',emailVeterinario AS 'EMAIL',telefoneFixoVet AS 'FIXO',telefoneCelularVet AS 'CELULAR' FROM tb_veterinario WHERE nomeVeterinario LIKE @nomeVeterinario '%' ORDER BY nomeVeterinario", conection);
                comando.Parameters.AddWithValue("@nomeVeterinario", veterinarios.nomeVeterinario);
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


        //query para pesquisar veterinario por CRMV no Banco de dados
         public DataTable PesquisarCRMV(Veterinarios veterinarios)
            {
                try
                {//PESQUISA DE veterinarios
                    AbrirConexao();

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    DataTable dtveterinario = new DataTable();

                    comando = new MySqlCommand("SELECT codVeterinario AS 'CODIGO',nomeVeterinario AS 'NOME',crmv AS 'CRMV',especializacao AS 'ESPECIALIZACAO',enderecoVeterinario AS 'ENDERECO',cidadeVeterinario AS 'CIDADE', estadoVeterinario AS 'ESTADO',bairroVeterinario AS 'BAIRRO',cepVeterinario AS 'CEP',numeroResidenciaVeterinario AS 'NUMERO',complementoVeterinario AS 'COMPLEMENTO',emailVeterinario AS 'EMAIL',telefoneFixoVet AS 'FIXO',telefoneCelularVet AS 'CELULAR' FROM tb_veterinario WHERE crmv LIKE @crmv '%' ORDER BY crmv", conection);
                    comando.Parameters.AddWithValue("@crmv", veterinarios.crmv);
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
         public DataTable listarVeterinariosCombobox()
         {
             try
             {

                 AbrirConexao();

                 DataTable dt = new DataTable();
                 MySqlDataAdapter da = new MySqlDataAdapter();
                 comando = new MySqlCommand("SELECT codVeterinario,nomeVeterinario FROM tb_veterinario", conection);
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
