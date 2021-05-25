using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class Especialidade_veterinariaBLL
    {
        Especialidade_veterinariaDAO especialidadeDAO = new Especialidade_veterinariaDAO();

        //Método controlador para salvar especialidade
        public void salvar(Especializacao_veterinaria especialidade)
        {
            try
            {
                especialidadeDAO.Salvar(especialidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //MÉTODO PARA LISTAR A TABELA COMPLETA ESPECIALIDADES
        public DataTable listarEspecialidades()
        {
            try
            {//Método controlador para listar veterinarios
                DataTable dtespec = new DataTable();
                dtespec = especialidadeDAO.listarEspecialidades();

                return dtespec;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para editar especialidades
        public void editar(Especializacao_veterinaria especialidade)
        {
            try
            {
                especialidadeDAO.Editar(especialidade);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        //Método controlador para excluir especialidade
        public void excluir(Especializacao_veterinaria especialidade)
        {
            try
            {
                especialidadeDAO.Excluir(especialidade);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Método controlador para pesquisar especialidade por nome ao digitar no textbox
        public DataTable pesquisar(Especializacao_veterinaria especialidade)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = especialidadeDAO.PesquisarNomeEspecialidade(especialidade);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar especialidades no combobox
        public DataTable listarEspecialidadeNoCombobox()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = especialidadeDAO.listarEspecialidadesCombobox();


                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
