using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class ServicosBLL
    {
        ServicosDAO servicosDAO = new ServicosDAO();

        //Método controlador para salvar serviços
        public void salvar(Servicos servicos)
        {
            try
            {
                servicosDAO.Salvar(servicos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para alterar serviços
        public void editar(Servicos servicos)
        {
            try
            {
                servicosDAO.Editar(servicos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para excluir serviços
        public void excluir(Servicos servicos)
        {
            try
            {
                servicosDAO.Excluir(servicos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar serviços no datatable
        public DataTable listarServicos()
        {
            try
            {
                DataTable dtveterinarios = new DataTable();
                dtveterinarios = servicosDAO.listarServicos();

                return dtveterinarios;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar servicos no combobox
        public DataTable listarServNoCombobox()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = servicosDAO.listarServicosCombobox();


                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para pesquisar servicos por nome
        public DataTable pesquisar(Servicos servicos)
        {
            try
            {
                ServicosDAO servicosDao = new ServicosDAO();
                DataTable dt = new DataTable();
                dt = servicosDao.Pesquisar(servicos);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }



    }
    

}
