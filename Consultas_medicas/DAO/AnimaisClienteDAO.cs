using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;//IMPORTAR PASTA MODEL
using MySql.Data.MySqlClient;
using System.Data;



namespace Consultas_medicas.DAO
{
    //PASSO 3 : AQUI FICA OS COMANDOS PARA MEXER NA TABELA

    public class AnimaisClienteDAO : conexao // HERDA A CLASSE CONEXÃO
    {
        MySqlCommand comando = null;

	
		//query para salvar relacionamento clientes e animais
        public void Salvar(AnimaisCliente animaisCliente) // CLASSE ANIMAL, OBJETO CRIADO POR MIN AQUI animais
        {
            try
            {
                /*AbrirConexao();//USA O MÉTODO ABRICONEXAO() HERDADO DA CLASSE CONEXAO

                comando = new MySqlCommand("INSERT INTO tb_clienteanimal(cod_cliente, cod_tipo_animal,cod_raca_animal,nome_animal,pesoAnimal,alturaAnimal,corAnimal) VALUES (@cod_cliente, @cod_tipo_animal,@cod_raca_animal,@nome_animal,@pesoAnimal,@alturaAnimal,@corAnimal)", conection);
                comando.Parameters.AddWithValue("@cod_cliente", animaisCliente.cod_cliente);
                comando.Parameters.AddWithValue("@cod_tipo_animal", animaisCliente.cod_tipo_animal);
                comando.Parameters.AddWithValue("@cod_raca_animal", animaisCliente.cod_raca_animal);
                comando.Parameters.AddWithValue("@nome_animal", animaisCliente.nome_animal);
                comando.Parameters.AddWithValue("@pesoAnimal", animaisCliente.peso_animal);
                comando.Parameters.AddWithValue("@alturaAnimal", animaisCliente.altura_animal);
                comando.Parameters.AddWithValue("@corAnimal", animaisCliente.cor_animal);
                comando.ExecuteNonQuery();*/

                AbrirConexao();//USA O MÉTODO ABRICONEXAO() HERDADO DA CLASSE CONEXAO

                //(funcionando) comando = new MySqlCommand("INSERT INTO tb_clienteanimais(cod_cliente, cod_tipo_animal,nome_raca_animal,nome_animal,pesoAnimal,alturaAnimal,corAnimal) VALUES (@cod_cliente, @cod_tipo_animal,@nome_raca_animal,@nome_animal,@pesoAnimal,@alturaAnimal,@corAnimal)", conection);
                comando = new MySqlCommand("INSERT INTO tb_clienteanimais(cod_cliente, cod_tipo_animal,cod_raca_animal,nome_animal,pesoAnimal,alturaAnimal,corAnimal,idade_animal,sexo_animal,historico_vacinas,historico_medico) VALUES (@cod_cliente, @cod_tipo_animal,@cod_raca_animal,@nome_animal,@pesoAnimal,@alturaAnimal,@corAnimal,@idade_animal,@sexo_animal,@historico_vacinas,@historico_medico)", conection);

                comando.Parameters.AddWithValue("@cod_cliente", animaisCliente.cod_cliente);
                comando.Parameters.AddWithValue("@cod_tipo_animal", animaisCliente.cod_tipo_animal);
                comando.Parameters.AddWithValue("@cod_raca_animal", animaisCliente.cod_raca_animal);
                comando.Parameters.AddWithValue("@nome_animal", animaisCliente.nome_animal);
                comando.Parameters.AddWithValue("@pesoAnimal", animaisCliente.peso_animal);
                comando.Parameters.AddWithValue("@alturaAnimal", animaisCliente.altura_animal);
                comando.Parameters.AddWithValue("@corAnimal", animaisCliente.cor_animal);//idade_animal
                comando.Parameters.AddWithValue("@idade_animal", animaisCliente.idade_animal);
                comando.Parameters.AddWithValue("@sexo_animal", animaisCliente.sexo_animal);
                comando.Parameters.AddWithValue("@historico_vacinas", animaisCliente.historico_vacinas);
                comando.Parameters.AddWithValue("@historico_medico", animaisCliente.historico_medico);
                comando.ExecuteNonQuery();


                
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }
		
		//query para listar no datatable o cliente e seus animais
        public DataTable listarAnimais()
        {
            try
            {
                AbrirConexao();

                DataTable dtanimais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO' , tb_cliente.nomeCliente AS 'CLIENTE', tb_tipo_animal.nome_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA',nome_animal AS 'NOME',pesoAnimal AS 'PESO',alturaAnimal AS 'ALTURA',corAnimal AS 'COR' FROM tb_clienteanimal,tb_cliente,tb_tipo_animal,tb_raca WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal", conection);
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO',tb_cliente.nomeCliente AS 'CLIENTE',cod_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimal,tb_cliente,tb_raca,tb_tipo_animal WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal", conection);
                //comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal inner join tb_raca raca on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal group by ClienteAnimal.cod_cadastro;", conection);
                //(funciona)comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro;", conection);

                comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO', cliente.nomeCliente AS 'CLIENTE', tipo.nome_tipo_animal AS 'TIPO', raca.nome_raca_animal AS 'RACA',  nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA',  corAnimal AS 'COR' ,idade_animal AS 'IDADE', sexo_animal AS 'SEXO',historico_vacinas AS 'VACINAS',historico_medico AS 'MEDICOS' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal group by ClienteAnimal.cod_cadastro;", conection);

                da.SelectCommand = comando;
                da.Fill(dtanimais);
                return dtanimais;

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

        //tabela com o nome do cliente o animal para escolher para consulta(formulario busca cliente)
        public DataTable EscolherClienteConsulta()
        {
            try
            {
                AbrirConexao();

                DataTable dtanimais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO' , tb_cliente.nomeCliente AS 'CLIENTE', tb_tipo_animal.nome_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA',nome_animal AS 'NOME',pesoAnimal AS 'PESO',alturaAnimal AS 'ALTURA',corAnimal AS 'COR' FROM tb_clienteanimal,tb_cliente,tb_tipo_animal,tb_raca WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal", conection);
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO',tb_cliente.nomeCliente AS 'CLIENTE',cod_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimal,tb_cliente,tb_raca,tb_tipo_animal WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal", conection);
                //comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimal ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal inner join tb_raca raca on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente", conection);
                //(FUNCIONANDO)comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente", conection);
                
                comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO', raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente;", conection);

                da.SelectCommand = comando;
                da.Fill(dtanimais);
                return dtanimais;

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


        //tabela com o nome do cliente o animal para escolher para consulta(pesquisa por nome ao digitar)
        public DataTable PesquisarNomeEscolherClienteConsulta(Clientes cliente)
        {
            try
            {
                AbrirConexao();

                DataTable dtanimais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO' , tb_cliente.nomeCliente AS 'CLIENTE', tb_tipo_animal.nome_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA',nome_animal AS 'NOME',pesoAnimal AS 'PESO',alturaAnimal AS 'ALTURA',corAnimal AS 'COR' FROM tb_clienteanimal,tb_cliente,tb_tipo_animal,tb_raca WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal", conection);
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO',tb_cliente.nomeCliente AS 'CLIENTE',cod_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimal,tb_cliente,tb_raca,tb_tipo_animal WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal", conection);
                //comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimal ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal inner join tb_raca raca on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente", conection);
                //(FUNCIONANDO)comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente", conection);

                comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO', raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal WHERE cliente.nomeCliente LIKE @cliente.nomeCliente '%'", conection);
                comando.Parameters.AddWithValue("@cliente.nomeCliente", cliente.nomeCliente);

                da.SelectCommand = comando;
                da.Fill(dtanimais);
                return dtanimais;

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


        //tabela com o nome do cliente o animal para escolher para consulta(pesquisa por nome ao digitar)
        public DataTable PesquisarCPFEscolherClienteConsulta(Clientes cliente)
        {
            try
            {
                AbrirConexao();

                DataTable dtanimais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO' , tb_cliente.nomeCliente AS 'CLIENTE', tb_tipo_animal.nome_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA',nome_animal AS 'NOME',pesoAnimal AS 'PESO',alturaAnimal AS 'ALTURA',corAnimal AS 'COR' FROM tb_clienteanimal,tb_cliente,tb_tipo_animal,tb_raca WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal", conection);
                //comando = new MySqlCommand("SELECT cod_cadastro AS 'CADASTRO',tb_cliente.nomeCliente AS 'CLIENTE',cod_tipo_animal AS 'TIPO',tb_raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimal,tb_cliente,tb_raca,tb_tipo_animal WHERE tb_cliente.CodCliente = tb_clienteanimal.cod_cliente AND tb_raca.cod_raca_animal = tb_clienteanimal.cod_raca_animal AND tb_tipo_animal.cod_tipo_animal = tb_clienteanimal.cod_tipo_animal", conection);
                //comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimal ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal inner join tb_raca raca on raca.cod_raca_animal = ClienteAnimal.cod_raca_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente", conection);
                //(FUNCIONANDO)comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO', nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro order by cliente.nomeCliente", conection);

                comando = new MySqlCommand("SELECT cliente.cpfCliente AS 'CPF',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO', raca.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal WHERE cliente.cpfCliente LIKE @cliente.cpfCliente '%'", conection);
                comando.Parameters.AddWithValue("@cliente.cpfCliente", cliente.cpfCliente);

                da.SelectCommand = comando;
                da.Fill(dtanimais);
                return dtanimais;

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





        ////query para editar relacionamento clientes e animais
        public void Editar(AnimaisCliente animaisCliente) // CLASSE ANIMAL, OBJETO CRIADO POR MIN AQUI animais
        {
            try
            {
                AbrirConexao();//USA O MÉTODO ABRICONEXAO() HERDADO DA CLASSE CONEXAO

                comando = new MySqlCommand("UPDATE tb_clienteanimais SET cod_cliente = @cod_cliente, cod_tipo_animal = @cod_tipo_animal, cod_raca_animal = @cod_raca_animal, nome_animal = @nome_animal, pesoAnimal = @pesoAnimal , alturaAnimal = @alturaAnimal, corAnimal = @corAnimal, idade_animal = @idade_animal,sexo_animal = @sexo_animal, historico_vacinas = @historico_vacinas, historico_medico = @historico_medico WHERE cod_cadastro = @cod_cadastro ", conection);
                comando.Parameters.AddWithValue("@cod_cliente", animaisCliente.cod_cliente);
                comando.Parameters.AddWithValue("@cod_tipo_animal", animaisCliente.cod_tipo_animal);
                comando.Parameters.AddWithValue("@cod_raca_animal", animaisCliente.cod_raca_animal);
                comando.Parameters.AddWithValue("@nome_animal", animaisCliente.nome_animal);
                comando.Parameters.AddWithValue("@pesoAnimal", animaisCliente.peso_animal);
                comando.Parameters.AddWithValue("@alturaAnimal", animaisCliente.altura_animal);
                comando.Parameters.AddWithValue("@corAnimal", animaisCliente.cor_animal);
                comando.Parameters.AddWithValue("@idade_animal", animaisCliente.idade_animal);
                comando.Parameters.AddWithValue("@sexo_animal", animaisCliente.sexo_animal);
                comando.Parameters.AddWithValue("@historico_vacinas", animaisCliente.historico_vacinas);
                comando.Parameters.AddWithValue("@historico_medico", animaisCliente.historico_medico);
                comando.Parameters.AddWithValue("@cod_cadastro", animaisCliente.cod_cadastro);


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

        ////query para excluir relacionamento clientes e animais
        public void Excluir(AnimaisCliente animaisCliente) 
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM tb_clienteanimais WHERE cod_cadastro = @cod_cadastro", conection);

                comando.Parameters.AddWithValue("@cod_cadastro", animaisCliente.cod_cadastro);
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

        //listar no combobox, o nome do cliente, codigo do cliente e cpf
        public DataTable listarNomeClienteCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente,nomeCliente,cpfCliente FROM tb_cliente", conection);
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

        //listar no combobox, o nome do cliente, codigo do cliente e cpf
        public DataTable listarNomeAnimaldoClienteCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_cadastro,nome_animal FROM tb_clienteanimais", conection);
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


        //LISTAR NO COMBOBOX O ANIMAL DA TABELA ANIMAIS
        public DataTable listarTipoAnimalCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT nome_tipo_animal,cod_tipo_animal FROM tb_tipo_animal", conection);
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

        //query para pesquisar cadastro por nome de pet
        public DataTable PesquisarPorPet(AnimaisCliente animaisCliente)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                //comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro WHERE nome_animal LIKE @nome_animal ORDER BY nome_animal;", conection);
                //(funcionando)comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal WHERE nome_animal LIKE @nome_animal '%' ORDER BY nome_animal;", conection);
                comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',raca.nome_raca_animal AS 'RACA',nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' ,idade_animal AS 'IDADE', sexo_animal AS 'SEXO',historico_vacinas AS 'VACINAS',historico_medico AS 'MEDICOS' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal WHERE nome_animal LIKE @nome_animal '%' ORDER BY nome_animal;", conection);

                comando.Parameters.AddWithValue("@nome_animal", animaisCliente.nome_animal);
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

        //query para pesquisar cadastro por nome de cliente
        public DataTable PesquisarPorCliente(Clientes clientes)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                //comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro WHERE nome_animal LIKE @nome_animal ORDER BY nome_animal;", conection);
                //(funcionando)comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal WHERE cliente.nomeCliente LIKE @cliente.nomeCliente '%' ORDER BY cliente.nomeCliente;", conection);
                comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',raca.nome_raca_animal AS 'RACA',nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR',idade_animal AS 'IDADE', sexo_animal AS 'SEXO',historico_vacinas AS 'VACINAS',historico_medico AS 'MEDICOS' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal join tb_raca raca on raca.cod_raca = ClienteAnimal.cod_raca_animal WHERE cliente.nomeCliente LIKE @cliente.nomeCliente '%' ORDER BY cliente.nomeCliente;", conection);

                comando.Parameters.AddWithValue("@cliente.nomeCliente", clientes.nomeCliente);
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

        //query para pesquisar cadastro por CPF
        public DataTable PesquisarPorCPF(Clientes clientes)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                //comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro WHERE nome_animal LIKE @nome_animal ORDER BY nome_animal;", conection);
                comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE', cliente.cpfCliente AS 'CPF',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal WHERE cpfCliente LIKE @cpfCliente '%' ORDER BY cpfCliente;", conection);
                comando.Parameters.AddWithValue("@cliente.cpfCliente", clientes.cpfCliente);
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
