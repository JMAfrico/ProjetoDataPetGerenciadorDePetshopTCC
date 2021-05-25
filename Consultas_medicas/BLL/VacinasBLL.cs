using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class VacinasBLL
    {
        VacinasDAO vacinasDAO = new VacinasDAO();
        //Método controlador para listar compras no combobox
        public DataTable MostrarVacinasCombobox()
        {
            try
            {
                DataTable dtcompra = new DataTable();
                dtcompra = vacinasDAO.MostrarVacinas();


                return dtcompra;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
