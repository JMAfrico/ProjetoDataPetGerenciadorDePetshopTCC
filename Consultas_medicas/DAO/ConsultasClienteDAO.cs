using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class ConsultasClienteDAO : conexao
    {
        MySqlCommand comando = null;

        public void Salvar(ConsultasCliente consultascliente)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_consulta_cliente(cod_consulta,status_pagamento,tipo_pagamento) VALUES (@cod_consulta,@status_pagamento,@tipo_pagamento)", conection);
                comando.Parameters.AddWithValue("@cod_consulta", consultascliente.cod_consulta);
                comando.Parameters.AddWithValue("@status_pagamento", consultascliente.status_pagamento);
                comando.Parameters.AddWithValue("@tipo_pagamento", consultascliente.tipo_pagamento);


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


        public DataTable MostrarCompra()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_consulta FROM tb_consulta_cliente WHERE cod_consulta = (SELECT MAX(cod_consulta) FROM tb_consulta_cliente)", conection);
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

        public void EditarStatusPagamento(ConsultasCliente consultascliente)
        {
            try
            {
                AbrirConexao();

                //comando = new MySqlCommand("UPDATE tb_consulta SET CodCliente = @CodCliente,cod_tipo_animal_consulta = @cod_tipo_animal_consulta,cod_raca_animal_consulta = @cod_raca_animal_consulta,cod_veterinario = @cod_veterinario,desc_servicos = @desc_servicos,dataConsulta = @dataConsulta,horaConsulta = @horaConsulta,valortotal_consulta = @valortotal_consulta WHERE codConsulta = @codConsulta", conection);
                comando = new MySqlCommand("UPDATE tb_consulta_cliente SET status_pagamento = @status_pagamento, tipo_pagamento = @tipo_pagamento WHERE cod_consulta = @codConsulta", conection);
                //comando.Parameters.AddWithValue("@status_pagamento", consultas.status_pagamento);
                comando.Parameters.AddWithValue("@codConsulta", consultascliente.cod_consulta);
                comando.Parameters.AddWithValue("@status_pagamento", consultascliente.status_pagamento);
                comando.Parameters.AddWithValue("@tipo_pagamento", consultascliente.tipo_pagamento);

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
    }
}
