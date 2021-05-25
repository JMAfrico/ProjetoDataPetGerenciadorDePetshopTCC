using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class ConsultasDAO : conexao
    {
        MySqlCommand comando = null;

        //query para salvar consulta no Banco de dados
        public void Salvar(Consultas consultas)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_servicos_cliente(codConsulta, CodCliente, cod_tipo_animal_consulta, cod_raca_animal_consulta, cod_veterinario,cod_servico, dataConsulta, horaConsulta, valortotal_consulta) VALUES (@codConsulta, @CodCliente, @cod_tipo_animal_consulta, @cod_raca_animal_consulta, @cod_veterinario, @cod_servico, @dataConsulta, @horaConsulta, @valortotal_consulta )", conection);

                comando.Parameters.AddWithValue("@codConsulta", consultas.codConsulta);
                comando.Parameters.AddWithValue("@CodCliente", consultas.CodCliente);
                comando.Parameters.AddWithValue("@cod_tipo_animal_consulta", consultas.cod_tipo_animal_consulta);
                comando.Parameters.AddWithValue("@cod_raca_animal_consulta", consultas.cod_raca_animal_consulta);
                comando.Parameters.AddWithValue("@cod_veterinario", consultas.cod_veterinario);
                comando.Parameters.AddWithValue("@cod_servico", consultas.cod_servico);              
                comando.Parameters.AddWithValue("@dataConsulta", consultas.dataConsulta);
                comando.Parameters.AddWithValue("@horaConsulta", consultas.horaConsulta);
                comando.Parameters.AddWithValue("@valortotal_consulta", consultas.valortotal_consulta);


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

        //query para listar consultas do Banco de dados
        public DataTable listarConsultas()
        {
            try
            {//LISTAR AS CONSULTAS

                AbrirConexao();

                DataTable dtconsultas = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //comando = new MySqlCommand("SELECT * from tb_consulta", conection);
                //comando = new MySqlCommand("SELECT ClienteAnimal.cod_cadastro AS 'CADASTRO',cliente.nomeCliente AS 'CLIENTE',tipo.nome_tipo_animal AS 'TIPO',ClienteAnimal.nome_raca_animal AS 'RACA', nome_animal AS 'NOME' ,pesoAnimal AS 'PESO', alturaAnimal AS 'ALTURA', corAnimal AS 'COR' from tb_clienteanimais ClienteAnimal join tb_cliente cliente on cliente.CodCliente = ClienteAnimal.cod_cliente inner join tb_tipo_animal tipo on tipo.cod_tipo_animal = ClienteAnimal.cod_tipo_animal group by ClienteAnimal.cod_cadastro;", conection);
                //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO_ANIMAL',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',desc_servicos AS 'SERV E PROD',valortotal_consulta AS'VALOR TOTAL',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.codigo_index_raca = CONSULTA.cod_raca_animal_consulta JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta", conection);
                //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',cod_raca_animal_consulta AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',desc_servicos AS 'SERVICOS',valortotal_consulta AS'VALOR TOTAL',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta", conection);
                //(funcionando)comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',cod_raca_animal_consulta AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',desc_servicos AS 'SERVICOS',valortotal_consulta AS'VALOR TOTAL',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta", conection);
                //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',cod_raca_animal_consulta AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',valortotal_consulta AS'VALOR TOTAL',dataConsulta AS 'DATA',horaConsulta AS 'HORA', CLIENTE.emailCliente AS 'EMAIL' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta ORDER BY dataConsulta,horaConsulta", conection);
                //SEM STATUS //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL', CLIENTE.emailCliente AS 'EMAIL' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta GROUP BY CLIENTE.codCliente,dataConsulta ORDER BY dataConsulta,horaConsulta", conection);
                //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL', CLIENTE.emailCliente AS 'EMAIL' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta GROUP BY CLIENTE.codCliente,dataConsulta ORDER BY dataConsulta,horaConsulta", conection);
                comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);


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


        public DataTable listarItemServicoCliente()
        {
            try
            {//LISTAR AS CONSULTAS

                AbrirConexao();

                DataTable dtconsultas = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                //comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_consulta CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente where CLIENTE.nomeCliente = @CLIENTE.nomeCliente;", conection);

                comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_servicos_cliente CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente;", conection);
                //comando.Parameters.AddWithValue("@nomeCliente", consultas.CodCliente);

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

        public DataTable listarItemProdutoCliente()
        {
            try
            {//LISTAR AS CONSULTAS

                AbrirConexao();

                DataTable dtconsultas = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                //comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_consulta CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente where CLIENTE.nomeCliente = @CLIENTE.nomeCliente;", conection);

                comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', PRODUTO.nome_produto AS 'PRODUTO', PRODUTO.preco_produto AS 'PRECO' from tb_servicos_cliente CONSULTA JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = CONSULTA.cod_produto JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente;", conection);
                //comando.Parameters.AddWithValue("@nomeCliente", consultas.CodCliente);

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

        //query para listar os dados do cliente do Banco de dados
        public DataTable listarClienteConsulta()
        {
            try
            {

                AbrirConexao();

                DataTable dtclienteConsulta = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT CodCliente,nomeCliente FROM tb_cliente", conection);
                da.SelectCommand = comando;
                da.Fill(dtclienteConsulta);

                return dtclienteConsulta;

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

        //query para editar consulta no Banco de dados
        public void Editar(Consultas consultas)
        {
            try
            {
                AbrirConexao();

                //comando = new MySqlCommand("UPDATE tb_consulta SET CodCliente = @CodCliente,cod_tipo_animal_consulta = @cod_tipo_animal_consulta,cod_raca_animal_consulta = @cod_raca_animal_consulta,cod_veterinario = @cod_veterinario,desc_servicos = @desc_servicos,dataConsulta = @dataConsulta,horaConsulta = @horaConsulta,valortotal_consulta = @valortotal_consulta WHERE codConsulta = @codConsulta", conection);
                comando = new MySqlCommand("UPDATE tb_servicos_cliente SET CodCliente = @CodCliente,cod_tipo_animal_consulta = @cod_tipo_animal_consulta,cod_raca_animal_consulta = @cod_raca_animal_consulta,cod_veterinario = @cod_veterinario,dataConsulta = @dataConsulta,horaConsulta = @horaConsulta WHERE codConsulta = @codConsulta", conection);

                comando.Parameters.AddWithValue("@codConsulta", consultas.codConsulta);
                comando.Parameters.AddWithValue("@CodCliente", consultas.CodCliente);
                comando.Parameters.AddWithValue("@cod_tipo_animal_consulta", consultas.cod_tipo_animal_consulta);
                comando.Parameters.AddWithValue("@cod_raca_animal_consulta", consultas.cod_raca_animal_consulta);
                comando.Parameters.AddWithValue("@cod_veterinario", consultas.cod_veterinario);
                //comando.Parameters.AddWithValue("@desc_servicos", consultas.desc_servicos);
                comando.Parameters.AddWithValue("@dataConsulta", consultas.dataConsulta);
                comando.Parameters.AddWithValue("@horaConsulta", consultas.horaConsulta);
                //comando.Parameters.AddWithValue("@valortotal_consulta", consultas.valortotal_consulta);

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


        //query para editar consulta no Banco de dados
        public void EditarStatusPagamento(Consultas consultas)
        {
            try
            {
                AbrirConexao();

                //comando = new MySqlCommand("UPDATE tb_consulta SET CodCliente = @CodCliente,cod_tipo_animal_consulta = @cod_tipo_animal_consulta,cod_raca_animal_consulta = @cod_raca_animal_consulta,cod_veterinario = @cod_veterinario,desc_servicos = @desc_servicos,dataConsulta = @dataConsulta,horaConsulta = @horaConsulta,valortotal_consulta = @valortotal_consulta WHERE codConsulta = @codConsulta", conection);
                comando = new MySqlCommand("UPDATE tb_servicos_cliente SET status_pagamento = @status_pagamento WHERE codConsulta = @codConsulta", conection);
                //comando.Parameters.AddWithValue("@status_pagamento", consultas.status_pagamento);
                comando.Parameters.AddWithValue("@codConsulta", consultas.codConsulta);

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

        //query para excluir consulta no Banco de dados USANDO 2 PARAMETROS DIFERENTES
        public void Excluir(Consultas consultas) 
        //public void Excluir(ConsultasCliente consultas) 
        {
            try
            {
                AbrirConexao();

                //DELETE FROM tb_consulta WHERE CodCliente = 18 and dataConsulta = "2021-02-04" ;
                //comando = new MySqlCommand("DELETE FROM tb_consulta WHERE codConsulta = @codConsulta ", conection);

                
                /*comando = new MySqlCommand("DELETE FROM tb_servicos_cliente WHERE CodCliente = @CodCliente and dataConsulta = @dataConsulta", conection);
                comando.Parameters.AddWithValue("@dataConsulta", consultas.dataConsulta);
                comando.Parameters.AddWithValue("@CodCliente", consultas.CodCliente);*/
                
                

                comando = new MySqlCommand("DELETE FROM tb_servicos_cliente WHERE codConsulta = @codConsulta", conection);

                comando.Parameters.AddWithValue("@codConsulta", consultas.codConsulta);




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

        //query para pesquisar cliente com consultas abertas por nome
		public DataTable Pesquisar(Clientes clientes)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtconsultas = new DataTable();

                comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO', CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE CLIENTE.nomeCliente LIKE @CLIENTE.nomeCliente '%' GROUP BY CLIENTE.codCliente,dataConsulta ORDER BY dataConsulta,horaConsulta", conection);
                comando.Parameters.AddWithValue("@CLIENTE.nomeCliente", clientes.nomeCliente);
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

        //query para pesquisar cliente com consultas abertas por codigo da consulta
        public DataTable PesquisarPORcodConsulta(Consultas consultas)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtconsultas = new DataTable();

                comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL', STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE CONSULTA.codConsulta = @CONSULTA.codConsulta group by CONSULTA.codConsulta", conection);
                comando.Parameters.AddWithValue("@CONSULTA.codConsulta", consultas.codConsulta);
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

        //query para pesquisar animais dos clientes com consultas abertas
        public DataTable ListarAnimal()
        {
            try
            {

                AbrirConexao();

                DataTable dtlistaranimais = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT tb_cliente.CodAnimal, descricaoAnimal FROM tb_animal inner join tb_cliente on tb_animal.codAnimal = tb_cliente.CodAnimal  ", conection);
                da.SelectCommand = comando;
                da.Fill(dtlistaranimais);

                return dtlistaranimais;

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

        //lista no combobox o cliente da consulta e o animal que pertence a ele
        public DataTable listarCliente_e_AnimalCombobox()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT tb_clienteanimal.cod_cliente,tb_cliente.nomeCliente,tb_cliente.CodCliente FROM tb_clienteanimal,tb_cliente WHERE tb_clienteanimal.cod_cliente = tb_cliente.CodCliente group by nomeCliente", conection);
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


        //MÉTODO PARA PESQUISAR servicos POR NOME DO CLIENTE
          public DataTable PesquisarItemServicoCliente(Clientes cliente,Consultas consultas)
        {
            try
            {
                AbrirConexao();

                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dtclientes = new DataTable();

                //comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_consulta CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente WHERE CLIENTE.nomeCliente LIKE @CLIENTE.nomeCliente '%' ", conection);
                //comando.Parameters.AddWithValue("@CLIENTE.nomeCliente", cliente.nomeCliente);

                comando = new MySqlCommand("select DATE_FORMAT(CONSULTA.dataConsulta,'%d/%m/%Y') AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_servicos_cliente CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente WHERE CLIENTE.nomeCliente = @CLIENTE.nomeCliente AND CONSULTA.dataConsulta = @CONSULTA.dataConsulta AND CONSULTA.horaConsulta = @CONSULTA.horaConsulta", conection);
                comando.Parameters.AddWithValue("@CLIENTE.nomeCliente", cliente.nomeCliente);
                comando.Parameters.AddWithValue("@CONSULTA.dataConsulta",consultas.dataConsulta);
                comando.Parameters.AddWithValue("@CONSULTA.horaConsulta", consultas.horaConsulta);

                
                
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


          //MÉTODO PARA PESQUISAR produtos POR NOME DO CLIENTE
          public DataTable PesquisarItemProdutoCliente(Clientes cliente)
          {
              try
              {
                  AbrirConexao();

                  MySqlDataAdapter da = new MySqlDataAdapter();
                  DataTable dtclientes = new DataTable();

                  //comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_consulta CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente WHERE CLIENTE.nomeCliente LIKE @CLIENTE.nomeCliente '%' ", conection);
                  //comando.Parameters.AddWithValue("@CLIENTE.nomeCliente", cliente.nomeCliente);

                  comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', PRODUTO.nome_produto AS 'PRODUTO', PRODUTO.preco_produto AS 'PRECO' from tb_servicos_cliente CONSULTA JOIN tb_produtos PRODUTO on PRODUTO.cod_produto = CONSULTA.cod_produto JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente WHERE CLIENTE.nomeCliente = @CLIENTE.nomeCliente order by CONSULTA.dataConsulta", conection);
                  comando.Parameters.AddWithValue("@CLIENTE.nomeCliente", cliente.nomeCliente);

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





          //MÉTODO PARA PESQUISAR POR data da consulta
         
          public DataTable PesquisarItemServicoClienteData(Consultas consultas)
          {
              try
              {
                  AbrirConexao();

                  MySqlDataAdapter da = new MySqlDataAdapter();
                  DataTable dtclientes = new DataTable();

                  //comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_consulta CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente WHERE CLIENTE.nomeCliente LIKE @CLIENTE.nomeCliente '%' ", conection);
                  //comando.Parameters.AddWithValue("@CLIENTE.nomeCliente", cliente.nomeCliente);

                  comando = new MySqlCommand("select CONSULTA.dataConsulta AS 'DATA', CLIENTE.nomeCliente AS 'NOME', SERVICO.nome_servico AS 'SERVICO', SERVICO.preco_servico AS 'PRECO' from tb_servicos_cliente CONSULTA JOIN tb_servicos SERVICO on SERVICO.cod_servico = CONSULTA.cod_servico JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente WHERE CONSULTA.dataConsulta = @CONSULTA.dataConsulta ", conection);
                  comando.Parameters.AddWithValue("@CONSULTA.dataConsulta", consultas.dataConsulta);

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

        //CONSULTAS POR VETERINARIO TODAS DATAS
          public DataTable ConsultasPorVeterinario(Veterinarios vet)
          {
              try
              {//LISTAR AS CONSULTAS

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  //TODAS CONSULTAS DO DETERMINADO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_servicos_cliente CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta;", conection);           
                  
                  //CONSULTAS DE HOJE DO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta = CURRENT_DATE() GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS PRÓXIMOS 3 DIAS
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()+3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS 3 DIAS ANTERIORES
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()-3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  
                  comando.Parameters.AddWithValue("@VETERINARIO.nomeVeterinario", vet.nomeVeterinario);

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

          //CONSULTAS POR VETERINARIO DATA HOJE
          public DataTable ConsultasPorVeterinarioHoje(Veterinarios vet)
          {
              try
              {//LISTAR AS CONSULTAS

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  //TODAS CONSULTAS DO DETERMINADO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DE HOJE DO VETERINÁRIO
                  comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta = CURRENT_DATE() GROUP BY dataConsulta,horaConsulta;", conection);           

                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_servicos_cliente CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta = CURRENT_DATE() GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS PRÓXIMOS 3 DIAS
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()+3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS 3 DIAS ANTERIORES
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()-3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);

                  comando.Parameters.AddWithValue("@VETERINARIO.nomeVeterinario", vet.nomeVeterinario);

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


          //CONSULTAS POR VETERINARIO DATA MAIS 3 DIAS
          public DataTable ConsultasPorVeterinarioMais3Dias(Veterinarios vet)
          {
              try
              {//LISTAR AS CONSULTAS

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  //TODAS CONSULTAS DO DETERMINADO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DE HOJE DO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta = CURRENT_DATE() GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS PRÓXIMOS 3 DIAS
                  comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE()+1 AND CURRENT_DATE()+3 GROUP BY dataConsulta,horaConsulta;", conection);           
                  
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_servicos_cliente CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()+3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS 3 DIAS ANTERIORES
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()-3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);

                  comando.Parameters.AddWithValue("@VETERINARIO.nomeVeterinario", vet.nomeVeterinario);

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


          //CONSULTAS POR VETERINARIO DATA Menos 3 DIAS
          public DataTable ConsultasPorVeterinarioMenos3Dias(Veterinarios vet)
          {
              try
              {//LISTAR AS CONSULTAS

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  //TODAS CONSULTAS DO DETERMINADO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DE HOJE DO VETERINÁRIO
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta = CURRENT_DATE() GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  //CONSULTAS DOS PRÓXIMOS 3 DIAS
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_consulta CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()+3 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  
                  //CONSULTAS DOS 3 DIAS ANTERIORES
                  //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_servicos_cliente CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE()-3 AND CURRENT_DATE()-1 GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                  comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario AND dataConsulta BETWEEN CURRENT_DATE()-3 AND CURRENT_DATE()-1 GROUP BY dataConsulta,horaConsulta;", conection);           


                  comando.Parameters.AddWithValue("@VETERINARIO.nomeVeterinario", vet.nomeVeterinario);

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


         //query para listar consultas do Banco de dados data de hoje
          public DataTable listarConsultasHoje()
          {
              try
              {

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE dataConsulta = CURRENT_DATE() GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);

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


          //query para listar consultas do Banco de dados data de hoje
          public DataTable listarConsultasMais3Dias()
          {
              try
              {

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE dataConsulta BETWEEN CURRENT_DATE() AND CURRENT_DATE()+3 GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);

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
          }//

          //query para listar consultas do Banco de dados data de hoje
          public DataTable listarConsultasMenos3Dias()
          {
              try
              {

                  AbrirConexao();

                  DataTable dtconsultas = new DataTable();
                  MySqlDataAdapter da = new MySqlDataAdapter();
                  comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE dataConsulta BETWEEN CURRENT_DATE()-3 AND CURRENT_DATE() GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);

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
          }//listarConsultasMenos3Dias
    }
}
