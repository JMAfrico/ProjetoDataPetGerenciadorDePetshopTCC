using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class Diagnostico_medicoDAO : conexao
    {
        MySqlCommand comando = null;

        public DataTable MostrarDiagnosticos()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("select distinct DIAG.cod_diagnostico AS 'N DIAGNOSTICO',CONSULTA.codConsulta AS 'CONSULTA',CLIANI.cod_cadastro AS 'CADASTRO',VET.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.alturaAnimal AS 'ALTURA',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO',DIAG.descricao_diagnostico AS 'DIAGNOSTICO',DIAG.medicacao_diagnostico AS 'MEDICACAO',DIAG.exames_diagnostico AS 'EXAMES',DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'from tb_diagnostico as DIAG inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario;", conection);
                //comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE dataConsulta = CURRENT_DATE() GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);

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

        public DataTable MostrarDiagnosticosHoje()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("select distinct DIAG.cod_diagnostico AS 'N DIAGNOSTICO',CONSULTA.codConsulta AS 'CONSULTA',CLIANI.cod_cadastro AS 'CADASTRO',VET.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.alturaAnimal AS 'ALTURA',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO',DIAG.descricao_diagnostico AS 'DIAGNOSTICO',DIAG.medicacao_diagnostico AS 'MEDICACAO',DIAG.exames_diagnostico AS 'EXAMES',DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'from tb_diagnostico as DIAG inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario WHERE data_diagnostico = CURRENT_DATE();", conection);
                //comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE dataConsulta = CURRENT_DATE() GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);

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

        public DataTable MostrarDiagnosticosUltimos3Dias()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("select distinct DIAG.cod_diagnostico AS 'N DIAGNOSTICO',CONSULTA.codConsulta AS 'CONSULTA',CLIANI.cod_cadastro AS 'CADASTRO',VET.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.alturaAnimal AS 'ALTURA',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO',DIAG.descricao_diagnostico AS 'DIAGNOSTICO',DIAG.medicacao_diagnostico AS 'MEDICACAO',DIAG.exames_diagnostico AS 'EXAMES',DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'from tb_diagnostico as DIAG inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario WHERE data_diagnostico BETWEEN CURRENT_DATE()-3 AND CURRENT_DATE()-1", conection);
                //comando = new MySqlCommand("SELECT CONSULTA.codConsulta AS 'CODIGO',CLIENTE.nomeCliente AS 'CLIENTE',TIPO.nome_tipo_animal AS 'TIPO',RACA.nome_raca_animal AS 'RACA',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',valortotal_consulta AS 'TOTAL',STU.nome_status AS 'PAGAMENTO',CLIENTE.emailCliente AS 'EMAIL' FROM tb_servicos_cliente CONSULTA JOIN tb_consulta_cliente CONCLIENTE on CONCLIENTE.cod_consulta = CONSULTA.codConsulta JOIN tb_status_pagamento_consulta STU on STU.cod_status = CONCLIENTE.status_pagamento JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CONSULTA.cod_tipo_animal_consulta JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta WHERE dataConsulta = CURRENT_DATE() GROUP BY CLIENTE.codCliente,dataConsulta,horaConsulta ORDER BY dataConsulta,horaConsulta", conection);

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



        //query para salvar consulta no Banco de dados
        public void Salvar(Diagnostico_medico diagnostico)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_diagnostico(cod_cadastro, cod_consulta, cod_diagnostico, data_diagnostico, descricao_diagnostico,exames_diagnostico, medicacao_diagnostico, hora_diagnostico) VALUES (@cod_cadastro, @cod_consulta, @cod_diagnostico, @data_diagnostico, @descricao_diagnostico,@exames_diagnostico, @medicacao_diagnostico, @hora_diagnostico )", conection);


                comando.Parameters.AddWithValue("@cod_cadastro", diagnostico.cod_cadastro);
                comando.Parameters.AddWithValue("@cod_consulta", diagnostico.cod_consulta);
                comando.Parameters.AddWithValue("@cod_diagnostico", diagnostico.cod_diagnostico);
                comando.Parameters.AddWithValue("@data_diagnostico", diagnostico.data_diagnostico);
                comando.Parameters.AddWithValue("@descricao_diagnostico", diagnostico.descricao_diagnostico);
                comando.Parameters.AddWithValue("@exames_diagnostico", diagnostico.exames_diagnostico);
                comando.Parameters.AddWithValue("@medicacao_diagnostico", diagnostico.medicacao_diagnostico);
                comando.Parameters.AddWithValue("@hora_diagnostico", diagnostico.hora_diagnostico);


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
                //comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario;", conection);
                comando = new MySqlCommand("select distinct DIAG.cod_diagnostico AS 'N DIAGNOSTICO',CONSULTA.codConsulta AS 'CONSULTA',CLIANI.cod_cadastro AS 'CADASTRO',VET.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.alturaAnimal AS 'ALTURA',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO',DIAG.descricao_diagnostico AS 'DIAGNOSTICO',DIAG.medicacao_diagnostico AS 'MEDICACAO',DIAG.exames_diagnostico AS 'EXAMES',DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'from tb_diagnostico as DIAG inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario WHERE VET.nomeVeterinario = @VETERINARIO.nomeVeterinario;", conection);

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


        //CONSULTAS POR VETERINARIO HOJE
        public DataTable ConsultasPorVeterinarioHoje(Veterinarios vet)
        {
            try
            {//LISTAR AS CONSULTAS

                AbrirConexao();

                DataTable dtconsultas = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //TODAS CONSULTAS DO DETERMINADO VETERINÁRIO
                //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_servicos_cliente CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                //comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario;", conection);
                comando = new MySqlCommand("select distinct DIAG.cod_diagnostico AS 'N DIAGNOSTICO',CONSULTA.codConsulta AS 'CONSULTA',CLIANI.cod_cadastro AS 'CADASTRO',VET.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.alturaAnimal AS 'ALTURA',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO',DIAG.descricao_diagnostico AS 'DIAGNOSTICO',DIAG.medicacao_diagnostico AS 'MEDICACAO',DIAG.exames_diagnostico AS 'EXAMES',DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'from tb_diagnostico as DIAG inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario WHERE data_diagnostico = CURRENT_DATE() and VET.nomeVeterinario = @VETERINARIO.nomeVeterinario;", conection);

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

        //CONSULTAS POR VETERINARIO HOJE
        public DataTable ConsultasPorVeterinarioMenos3Dias(Veterinarios vet)
        {
            try
            {//LISTAR AS CONSULTAS

                AbrirConexao();

                DataTable dtconsultas = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                //TODAS CONSULTAS DO DETERMINADO VETERINÁRIO
                //comando = new MySqlCommand("SELECT codConsulta AS 'CODIGO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',dataConsulta AS 'DATA',horaConsulta AS 'HORA' FROM tb_servicos_cliente CONSULTA JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = CONSULTA.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = CONSULTA.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = CONSULTA.cod_raca_animal_consulta where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario GROUP BY dataConsulta,horaConsulta order BY dataConsulta,horaConsulta;", conection);
                //comando = new MySqlCommand("SELECT cod_consulta AS 'CODIGO',CLIANI.cod_cadastro AS 'CADASTRO',VETERINARIO.nomeVeterinario AS 'VETERINARIO',dataConsulta AS 'DATA',horaConsulta AS 'HORA',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.alturaAnimal AS 'TAMANHO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO' FROM tb_consulta_cliente CONSULTA join tb_servicos_cliente SERV on CONSULTA.cod_consulta = SERV.codConsulta JOIN tb_cliente CLIENTE on CLIENTE.CodCliente = SERV.CodCliente JOIN tb_veterinario VETERINARIO on VETERINARIO.codVeterinario = SERV.cod_veterinario JOIN tb_raca RACA on RACA.cod_raca = SERV.cod_raca_animal_consulta JOIN tb_clienteanimais CLIANI on CLIANI.cod_raca_animal = RACA.cod_raca join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal where VETERINARIO.nomeVeterinario = @VETERINARIO.nomeVeterinario;", conection);
                comando = new MySqlCommand("select distinct DIAG.cod_diagnostico AS 'N DIAGNOSTICO',CONSULTA.codConsulta AS 'CONSULTA',CLIANI.cod_cadastro AS 'CADASTRO',VET.nomeVeterinario AS 'VETERINARIO',CLIENTE.nomeCliente AS 'CLIENTE',RACA.nome_raca_animal AS 'RACA',TIPO.nome_tipo_animal AS 'TIPO',CLIANI.nome_animal AS 'NOME',CLIANI.idade_animal AS 'IDADE',CLIANI.pesoAnimal AS 'PESO',CLIANI.alturaAnimal AS 'ALTURA',CLIANI.corAnimal AS 'COR',CLIANI.sexo_animal AS 'SEXO',CLIANI.historico_vacinas AS 'VACINAS',CLIANI.historico_medico AS 'HISTORICO',DIAG.descricao_diagnostico AS 'DIAGNOSTICO',DIAG.medicacao_diagnostico AS 'MEDICACAO',DIAG.exames_diagnostico AS 'EXAMES',DIAG.data_diagnostico AS 'DATA',DIAG.hora_diagnostico AS 'HORA'from tb_diagnostico as DIAG inner JOIN tb_clienteanimais CLIANI on  CLIANI.cod_cadastro = DIAG.cod_cadastro inner join tb_servicos_cliente CONSULTA on DIAG.cod_consulta = CONSULTA.codConsulta inner join tb_cliente CLIENTE on CLIENTE.CodCliente = CLIANI.cod_cliente inner join tb_raca RACA on RACA.cod_raca = CLIANI.cod_raca_animal inner join tb_tipo_animal TIPO on TIPO.cod_tipo_animal = CLIANI.cod_tipo_animal inner join tb_veterinario VET on VET.codVeterinario = CONSULTA.cod_veterinario WHERE data_diagnostico BETWEEN CURRENT_DATE()-3 AND CURRENT_DATE()-1 AND VET.nomeVeterinario = @VETERINARIO.nomeVeterinario;", conection);

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
    }
}
