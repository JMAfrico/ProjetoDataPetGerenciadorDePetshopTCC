using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Consultas_medicas.DAO
{
    public class ComprasDAO : conexao
    {
        MySqlCommand comando = null;

        public void Salvar(Compra compra)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO tb_compra(cod_compra,cod_pagamento) VALUES (@cod_compra,@cod_pagamento)", conection);
                comando.Parameters.AddWithValue("@cod_compra", compra.cod_compra);
                comando.Parameters.AddWithValue("@cod_pagamento", compra.cod_pagamento);

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
                comando = new MySqlCommand("SELECT cod_compra FROM tb_compra WHERE cod_compra = (SELECT MAX(cod_compra) FROM tb_compra)", conection);
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

        //Mostrar no combobox o tipo de pagamento
        public DataTable MostrarTipoPagamentoCompra()
        {
            try
            {

                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT cod_pagamento,nome_pagamento FROM tb_pagamento", conection);
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
