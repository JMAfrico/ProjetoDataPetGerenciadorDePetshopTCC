using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class StatusPagamentoBLL
    {
        StatusPagamentoDAO status = new StatusPagamentoDAO();
        
        //Método controlador para listar compras no combobox
        public DataTable MostrarStatusCombobox()
        {
            try
            {
                DataTable dtcompra = new DataTable();
                dtcompra = status.MostrarStatusPagamento();


                return dtcompra;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
