using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class ConsultasClienteBLL
    {
        ConsultasClienteDAO consDAO = new ConsultasClienteDAO();


        //Método controlador para salvar IDCONSULTA
        public void salvar(ConsultasCliente cons)
        {
            try
            {
                consDAO.Salvar(cons);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para mostrar IDCONSULTA
        public DataTable MostrarIDCombobox()
        {
            try
            {
                DataTable dtcompra = new DataTable();
                dtcompra = consDAO.MostrarCompra();


                return dtcompra;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para editar consulta
        public void editarPagamento(ConsultasCliente cons)
        {
            try
            {
                consDAO.EditarStatusPagamento(cons);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
