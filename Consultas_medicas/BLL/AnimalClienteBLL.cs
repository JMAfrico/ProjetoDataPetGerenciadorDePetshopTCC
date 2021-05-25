using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;// IMPORTAR A TABELA MODELS ONDE TEM AS CARACTERISTICAS DAS TABELAS
using Consultas_medicas.DAO; // IMPORTAR PASTA DAO ONDE ESTA A CONEXAO E O AnimaisDAO QUE CONTEM O COMMAND
using System.Data;

namespace Consultas_medicas.BLL
{
    public class AnimalClienteBLL
    {
        AnimaisClienteDAO animaisClienteDao = new AnimaisClienteDAO(); // CRIEI UM OBJETO DO TIPO ANIMAISDAO

	
		//salvar
        public void salvar(AnimaisCliente animalCliente) // CRIEI UM MÉTODO SALVAR, QUE TEM COMO PARAMETRO A CLASSE ANIMAIS, OU SEJA , HERDA AS CARACTERISTICAS
        {									// DA CLASSE MODELS.ANIMAIS
            try
            {
                animaisClienteDao.Salvar(animalCliente);  // OBJETO QUE CRIEI, CHAMA O MÉTODO SALVAR QUE ESTÁ NA CLASSE DAO, E SALVA DENTRO DO PARAMETRO animal
            }
            catch(Exception erro)
            {
                throw erro;
            }

        }
		
		//PROBLEMA AQUI
		
		//listar animais
        public DataTable listarAnimais()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.listarAnimais();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable listarAnimaisdoCliente()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.listarAnimais();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public DataTable listarNomedoCliente()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.listarNomeClienteCombobox();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable listarNomeAnimalCliente()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.listarNomeClienteCombobox();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable EscolherClienteConsulta()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.EscolherClienteConsulta();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        public DataTable PesquisarNomeEscolherClienteConsulta(Clientes cliente)
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.PesquisarNomeEscolherClienteConsulta(cliente);

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        public DataTable PesquisarCPFEscolherClienteConsulta(Clientes cliente)
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = animaisClienteDao.PesquisarCPFEscolherClienteConsulta(cliente);

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }





        //Método controlador para editar relacionamento de clientes e animais
        public void editar(AnimaisCliente animaisCliente)
        {
            try
            {
                animaisClienteDao.Editar(animaisCliente);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
		
		
		//Método controlador para excluir relacionamento de clientes e animais
        public void excluir(AnimaisCliente animaisCliente)
        {
            try
            {
                animaisClienteDao.Excluir(animaisCliente);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para pesquisar Cliente por nome do Pet 
        public DataTable pesquisarNomePet(AnimaisCliente animaisCliente)
        {
            try
            {
                AnimaisClienteDAO animaisClienteDao = new AnimaisClienteDAO();
                DataTable dt = new DataTable();
                dt = animaisClienteDao.PesquisarPorPet(animaisCliente);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar Cliente por nome do Cliente 
        public DataTable pesquisarNomeCliente(Clientes clientes)
        {
            try
            {
                AnimaisClienteDAO animaisClienteDao = new AnimaisClienteDAO();
                DataTable dt = new DataTable();
                dt = animaisClienteDao.PesquisarPorCliente(clientes);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar Cliente por nome CPF
        public DataTable pesquisarCPFCliente(Clientes clientes)
        {
            try
            {
                AnimaisClienteDAO animaisClienteDao = new AnimaisClienteDAO();
                DataTable dt = new DataTable();
                dt = animaisClienteDao.PesquisarPorCPF(clientes);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        

        //Método controlador para tipo de animais da tabela tipo_animal na tabela AnimaisXClientes
        public DataTable listarTipoAnimalCombobox()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = animaisClienteDao.listarTipoAnimalCombobox();


                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
