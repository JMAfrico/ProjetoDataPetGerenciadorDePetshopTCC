using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;
using Ferramentas;

namespace Consultas_medicas.BLL
{
    public class ProdutosClienteBLL
    {
        ProdutosClienteDAO ProdutosCliDAO = new ProdutosClienteDAO();

        //Método controlador para salvar novo cliente
        public void salvar(ProdutosCliente produtosCliente)
        {
            try
            {
                ProdutosCliDAO.Salvar(produtosCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }


        //Método controlador para PESQUISAR produtos sem detalhes das compras dos clientes POR NOME
        public DataTable PesquisarComprasCliente(Clientes clientes)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ProdutosCliDAO.PesquisarComprasCliente(clientes);
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para PESQUISAR produtos sem detalhes das compras dos clientes POR COD COMPRA
        public DataTable PesquisarComprasClienteCod(ProdutosCliente produtoCli)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ProdutosCliDAO.PesquisarComprasClienteCod(produtoCli);
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para listar produtos sem detalhes das compras dos clientes
        public DataTable listarProdutosdoCliente()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ProdutosCliDAO.listarProdutosCliente();
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para pesquisar CLIENTESxPRODUTOS COMPRADOS
        public DataTable pesquisarItensProdutosCliente(Clientes clientes, ProdutosCliente produtoCliente)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = ProdutosCliDAO.PesquisarItemProdutosCliente(clientes, produtoCliente);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
