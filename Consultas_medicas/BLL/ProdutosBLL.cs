using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class ProdutosBLL
    {
        ProdutosDAO produtosDao = new ProdutosDAO();

        //Método controlador para salvar produtos
        public void salvar(Produtos produtos)
        {
            try
            {
                produtosDao.Salvar(produtos);
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        //Método controlador para alterar produtos
        public void editar(Produtos produtos)
        {
            try
            {
                produtosDao.Editar(produtos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        //Método controlador para excluir produtos
        public void excluir(Produtos produtos)
        {
            try
            {
                produtosDao.Excluir(produtos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        //Método controlador para listar produtos no datatable
        public DataTable listarProdutos()
        {
            try
            {
                DataTable dtprodutos = new DataTable();
                dtprodutos = produtosDao.listarProdutos();

                return dtprodutos;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar produtos no combobox
        public DataTable listarProdNoCombobox()
        {
            try
            {
                DataTable dtproduto = new DataTable();
                dtproduto = produtosDao.listaProdutosCombobox();


                return dtproduto;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        //Método controlador para pesquisar produtos por nome
        public DataTable pesquisar(Produtos produtos)
        {
            try
            {
                DataTable dtproduto = new DataTable();
                dtproduto = produtosDao.Pesquisar(produtos);


                return dtproduto;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
