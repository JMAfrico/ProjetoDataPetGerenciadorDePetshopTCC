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
    public class ClienteBLL
    {
        ClientesDAO clientesDAO = new ClientesDAO();

        //Método controlador para salvar novo cliente
        public void salvar(Clientes clientes)
        {
            try
            {
                clientesDAO.Salvar(clientes);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }


        //Método controlador para listar clientes
        public DataTable listarClientes()
        {
            try
            {
                DataTable dtclientes = new DataTable();
                dtclientes = clientesDAO.listarClientes();

                return dtclientes;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        
        //Método controlador para listar clientes combobox
        public DataTable listarCliCombobox()
        {
            try
            {
                DataTable dtclientes = new DataTable();
                dtclientes = clientesDAO.listarCliCombobox();

                return dtclientes;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        //Método controlador para editar clientes
        public void editar(Clientes clientes)
        {
            try
            {
                clientesDAO.Editar(clientes);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        //Método controlador para excluir clientes
	    public void excluir(Clientes clientes)
        {
            try
            {
                clientesDAO.Excluir(clientes);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        //Método controlador para pesquisar clientes por nome
		public DataTable pesquisar(Clientes clientes)
        {
            try
            {
                ClientesDAO clientesDAO = new ClientesDAO();
                DataTable dt = new DataTable();
                dt = clientesDAO.Pesquisar(clientes);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar clientes por cpf
        public DataTable pesquisarCPF(Clientes clientes)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = clientesDAO.PesquisarPORCPF(clientes);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
