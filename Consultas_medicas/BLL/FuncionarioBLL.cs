using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;  

namespace Consultas_medicas.BLL
{
    public class FuncionarioBLL
    {
        FuncionariosDAO funcionarioDAO = new FuncionariosDAO();


        //Método controlador para salvar funcionarios
        public void salvar(Funcionarios funcionario)
        {
            try
            {
                funcionarioDAO.Salvar(funcionario);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }



        //Método controlador para listar funcionarios
        public DataTable listarFuncionarios()
        {
            try
            {
                DataTable dtfunc = new DataTable();
                dtfunc = funcionarioDAO.listarFuncionarios();

                return dtfunc;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }



        //Método controlador para editar funcionarios
        public void editar(Funcionarios funcionario)
        {
            try
            {
                funcionarioDAO.Editar(funcionario);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        //Método controlador para excluir funcionarios
		public void excluir(Funcionarios funcionario)
        {
            try
            {
                funcionarioDAO.Excluir(funcionario);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para pesquisar funcionarios
		public DataTable pesquisar(Funcionarios funcionario)
        {
            try
            {
                
                DataTable dt = new DataTable();
                dt = funcionarioDAO.Pesquisar(funcionario);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


    }
}
