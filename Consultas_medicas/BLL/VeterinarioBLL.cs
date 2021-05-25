using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class VeterinarioBLL
    {
        VeterinariosDAO veterinariosDAO = new VeterinariosDAO();
		
		
		
		
        //Método controlador para salvar veterinarios
        public void salvar(Veterinarios veterinario)
        {
            try
            {
                veterinariosDAO.Salvar(veterinario);
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }
		
		
		
		
		
		
        public DataTable listarVeterinarios()
        {
            try
            {//Método controlador para listar veterinarios
                DataTable dtveterinarios = new DataTable();
                dtveterinarios = veterinariosDAO.listarVeterinarios();

                return dtveterinarios;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }



        //Método controlador para editar veterinarios
        public void editar(Veterinarios veterinarios)
        {
            try
            {
                veterinariosDAO.Editar(veterinarios);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        //Método controlador para excluir veterinarios
		public void excluir(Veterinarios veterinarios)
        {
            try
            {
                veterinariosDAO.Excluir(veterinarios);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        //Método controlador para pesquisar veterinarios por nome ao digitar no textbox
		public DataTable pesquisar(Veterinarios veterinarios)
        {
            try
            {
                VeterinariosDAO veterinariosDAO = new VeterinariosDAO();
                DataTable dt = new DataTable();
                dt = veterinariosDAO.Pesquisar(veterinarios);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar veterinarios por CRMV ao digitar no textbox
        public DataTable pesquisarCRMV(Veterinarios veterinarios)
        {
            try
            {
                VeterinariosDAO veterinariosDAO = new VeterinariosDAO();
                DataTable dt = new DataTable();
                dt = veterinariosDAO.PesquisarCRMV(veterinarios);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar veterinarios no combobox
        public DataTable listarVeteriNoCombobox()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = veterinariosDAO.listarVeterinariosCombobox();


                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


    }
}
