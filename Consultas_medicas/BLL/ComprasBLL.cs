using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class ComprasBLL
    {

        ComprasDAO comprasDAO = new ComprasDAO();

        //Método controlador para salvar compra
        public void salvar(Compra compras)
        {
            try
            {
                comprasDAO.Salvar(compras);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar compras no combobox
        public DataTable MostrarIDcompraCombobox()
        {
            try
            {
                DataTable dtcompra = new DataTable();
                dtcompra = comprasDAO.MostrarCompra();


                return dtcompra;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar compras no combobox
        public DataTable MostrarTipoPagamentoCombobox()
        {
            try
            {
                DataTable dtcompra = new DataTable();
                dtcompra = comprasDAO.MostrarTipoPagamentoCompra();


                return dtcompra;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
