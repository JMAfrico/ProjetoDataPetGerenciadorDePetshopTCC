using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class ClientesDAO : conexao
    {
        MySqlCommand comando = null;

        //query para salvar cliente no Banco de dados
        public void Salvar(Clientes clientes)
        { 
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_cliente(nomeCliente,emailCliente,TelefoneCelularCli,TelefoneFixoCli,enderecoCliente,cidadeCliente,estadoCliente,numeroResidenciaCliente,bairroCliente,cepCliente,complementoCliente,cpfCliente,referencia_cliente)VALUES (@nomeCliente,@emailCliente,@TelefoneCelularCli,@TelefoneFixoCli,@enderecoCliente,@cidadeCliente,@estadoCliente,@numeroResidenciaCliente,@bairroCliente,@cepCliente,@complementoCliente,@cpfCliente,@referencia_cliente)", conection);
                    comando.Parameters.AddWithValue("@nomeCliente", clientes.nomeCliente);
                    comando.Parameters.AddWithValue("@emailCliente", clientes.emailCliente);
                    comando.Parameters.AddWithValue("@TelefoneCelularCli", clientes.telefoneCelularCli);
                    comando.Parameters.AddWithValue("@TelefoneFixoCli", clientes.telefoneFixoCli);
                    comando.Parameters.AddWithValue("@enderecoCliente", clientes.enderecoCliente);
                    comando.Parameters.AddWithValue("@cidadeCliente", clientes.cidadeCliente);
                    comando.Parameters.AddWithValue("@estadoCliente", clientes.estadoCliente);
                    comando.Parameters.AddWithValue("@numeroResidenciaCliente", clientes.numeroResidenciaCliente);
                    comando.Parameters.AddWithValue("@bairroCliente", clientes.bairroCliente);
                    comando.Parameters.AddWithValue("@cepCliente", clientes.cepCliente);
                    comando.Parameters.AddWithValue("@complementoCliente", clientes.ComplementoCliente);
                    comando.Parameters.AddWithValue("@cpfCliente", clientes.cpfCliente);
                    comando.Parameters.AddWithValue("@referencia_cliente", clientes.referencia_cliente);

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


        //query para listar clientes do Banco de dados
        public DataTable listarClientes()
        {
            try
            {
                AbrirConexao();

                DataTable dtclientes = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente AS 'CODIGO' ,nomeCliente AS 'CLIENTE',cpfCliente AS 'CPF',emailCliente AS 'EMAIL',TelefoneCelularCli AS 'CEL' ,TelefoneFixoCli AS 'CEL',enderecoCliente AS 'RUA',cidadeCliente AS 'CIDADE', estadoCliente AS 'ESTADO',cepCliente AS 'CEP' ,bairroCliente AS 'BAIRRO' ,numeroResidenciaCliente AS 'NUM',complementoCliente AS 'COMPLEMENTO', referencia_cliente AS 'REFERENCIA' FROM tb_cliente ORDER BY CodCliente", conection);
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

        //query para listar clientes do combobox
        public DataTable listarCliCombobox()
        {
            try
            {
                AbrirConexao();

                DataTable dtclientes = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente ,nomeCliente,emailCliente FROM tb_cliente;", conection);
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

        //query para editar cliente no Banco de dados
        public void Editar(Clientes clientes)
        {
            try
            { 
                AbrirConexao();

                comando = new MySqlCommand("UPDATE tb_cliente SET nomeCliente = @nomeCliente,emailCliente = @emailCliente,TelefoneCelularCli = @TelefoneCelularCli ,TelefoneFixoCli = @TelefoneFixoCli,enderecoCliente = @enderecoCliente, cidadeCliente = @cidadeCliente, estadoCliente = @estadoCliente,numeroResidenciaCliente = @numeroResidenciaCliente,bairroCliente = @bairroCliente,cepCliente = @cepCliente,complementoCliente = @complementoCliente,cpfCliente = @cpfCliente , referencia_cliente = @referencia_cliente WHERE CodCliente = @CodCliente", conection);

                comando.Parameters.AddWithValue("@CodCliente", clientes.CodCliente);
                comando.Parameters.AddWithValue("@nomeCliente", clientes.nomeCliente);
                comando.Parameters.AddWithValue("@emailCliente", clientes.emailCliente);
                comando.Parameters.AddWithValue("@TelefoneCelularCli", clientes.telefoneCelularCli);
                comando.Parameters.AddWithValue("@TelefoneFixoCli", clientes.telefoneFixoCli);
                comando.Parameters.AddWithValue("@enderecoCliente", clientes.enderecoCliente);
                comando.Parameters.AddWithValue("@cidadeCliente", clientes.cidadeCliente);
                comando.Parameters.AddWithValue("@estadoCliente", clientes.estadoCliente);
                comando.Parameters.AddWithValue("@numeroResidenciaCliente", clientes.numeroResidenciaCliente);
                comando.Parameters.AddWithValue("@bairroCliente", clientes.bairroCliente);
                comando.Parameters.AddWithValue("@cepCliente", clientes.cepCliente);
                comando.Parameters.AddWithValue("@complementoCliente", clientes.ComplementoCliente);
                comando.Parameters.AddWithValue("@cpfCliente", clientes.cpfCliente);
                comando.Parameters.AddWithValue("@referencia_cliente", clientes.referencia_cliente);

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


        //query para excluir clientes no Banco de dados
		public void Excluir(Clientes clientes) 
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_cliente WHERE CodCliente = @CodCliente ", conection);

                comando.Parameters.AddWithValue("@CodCliente", clientes.CodCliente);

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


        //query para pesquisar clientes por nome no Banco de dados
        public DataTable Pesquisar(Clientes clientes)
        {
            try
            {//Pesquisa DE CLIENTES
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                comando = new MySqlCommand("SELECT CodCliente AS 'CODIGO', nomeCliente AS 'CLIENTE', cpfCliente AS 'CPF', emailCliente AS 'EMAIL', TelefoneCelularCli AS 'CELULAR', TelefoneFixoCli AS 'TELEFONE', enderecoCliente AS 'ENDERECO',cidadeCliente AS 'CIDADE', estadoCliente AS 'ESTADO', cepCliente AS 'CEP', bairroCliente AS 'BAIRRO', numeroResidenciaCliente AS 'NUMERO', complementoCliente AS 'COMPLEMENTO',referencia_cliente AS 'REFERENCIA' FROM tb_cliente WHERE nomeCliente LIKE @nomeCliente '%' ORDER BY nomeCliente", conection);
                comando.Parameters.AddWithValue("@nomeCliente", clientes.nomeCliente);
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

        //query para pesquisar clientes por nome no CPF
        public DataTable PesquisarPORCPF(Clientes clientes)
        {
            try
            {//PESQUISA DE CLIENTES NA TABELA CONSULTAS
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtconsultas = new DataTable();

                comando = new MySqlCommand("SELECT CodCliente AS 'CODIGO', nomeCliente AS 'CLIENTE', cpfCliente AS 'CPF', emailCliente AS 'EMAIL', TelefoneCelularCli AS 'CELULAR', TelefoneFixoCli AS 'TELEFONE', enderecoCliente AS 'ENDERECO',cidadeCliente AS 'CIDADE', estadoCliente AS 'ESTADO', cepCliente AS 'CEP', bairroCliente AS 'BAIRRO', numeroResidenciaCliente AS 'NUMERO', complementoCliente AS 'COMPLEMENTO',referencia_cliente AS 'REFERENCIA' FROM tb_cliente WHERE cpfCliente LIKE @cpfCliente '%' ORDER BY cpfCliente ", conection);
                comando.Parameters.AddWithValue("@cpfCliente", clientes.cpfCliente);
                da.SelectCommand = comando;
                da.Fill(dtconsultas);
                return dtconsultas;

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
