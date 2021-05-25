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
    public class raca_animalBLL
    {
        raca_animalDAO Raca_animalDAO = new raca_animalDAO();

        //Método controlador para salvar nova raça de animal
        public void salvar(raca_animal raca_animal)
        {
            try
            {
                Raca_animalDAO.Salvar(raca_animal);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para listar raça de animais
        public DataTable listarRacaAnimais()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = Raca_animalDAO.listar_raca_animais();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar raça de animais no combobox
        public DataTable listarRacaAnimais_combobox()
        {
            try
            {
                DataTable dtanimais = new DataTable();
                dtanimais = Raca_animalDAO.listarRacaAnimais_combobox();

                return dtanimais;
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
                dtanimais = Raca_animalDAO.listar_todos_animais();

                return dtanimais;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para excluir raca de animais
        public void excluir(raca_animal raca_animal)
        {
            try
            {

                Raca_animalDAO.Excluir(raca_animal);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para editar raca de animais
        public void editar(raca_animal raca_animal)
        {
            try
            {
                Raca_animalDAO.Editar(raca_animal);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para listar tipo de animais no combobox
        public DataTable listarTipoAnimalCombobox()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Raca_animalDAO.listarTipoAnimalCombobox();


                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar RACA por nome
        public DataTable pesquisar(raca_animal raca_animal)
        {
            try
            {
                raca_animalDAO racaanimalDAO = new raca_animalDAO();
                DataTable dt = new DataTable();
                dt = racaanimalDAO.Pesquisar(raca_animal);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar RACA por nome
        public DataTable pesquisar_txt_raca(raca_animal raca_animal)
        {
            try
            {
                raca_animalDAO racaanimalDAO = new raca_animalDAO();
                DataTable dt = new DataTable();
                dt = racaanimalDAO.Pesquisar_txt_raca(raca_animal);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
