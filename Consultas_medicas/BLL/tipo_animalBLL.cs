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
    public class tipo_animalBLL//tornar a classe publica
    {
        
        tipo_animalDAO Tipo_animalDAO = new tipo_animalDAO();

        //Método controlador para salvar novo tipo de animal
        public void salvar(tipo_animal tipo_animal) 
        {
            try
            {
                Tipo_animalDAO.Salvar(tipo_animal);  
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para listar animal
        public DataTable listarTipoAnimais()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = Tipo_animalDAO.listar_tipo_animais();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar tipos de animais no combobox(tb_consulta)
        public DataTable listarTipoAnimais_consulta()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = Tipo_animalDAO.listarTipoAnimais_consulta();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para excluir animais
        public void excluir(tipo_animal tipo_animal)
        {
            try
            {

                Tipo_animalDAO.Excluir(tipo_animal);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para editar animais
        public void editar(tipo_animal Tipo_animal)
        {
            try
            {
                Tipo_animalDAO.Editar(Tipo_animal);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para pesquisar TIPO de animal por nome
        public DataTable pesquisar(tipo_animal Tipo_animal)
        {
            try
            {
                tipo_animalDAO tipoAnimalDAO = new tipo_animalDAO();
                DataTable dt = new DataTable();
                dt = tipoAnimalDAO.Pesquisar(Tipo_animal);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar Somente TIPO de 
        public DataTable pesquisarTipos(tipo_animal Tipo_animal)
        {
            try
            {
                tipo_animalDAO tipoAnimalDAO = new tipo_animalDAO();
                DataTable dt = new DataTable();
                dt = tipoAnimalDAO.PesquisarTipos(Tipo_animal);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar todos animais(tipo x raça)
        public DataTable listarTodosAnimais()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = Tipo_animalDAO.listar_todos_animais();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
