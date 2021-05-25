using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas_medicas.Models;
using Consultas_medicas.DAO;
using System.Data;

namespace Consultas_medicas.BLL
{
    public class Diagnostico_medicoBLL
    {
        Diagnostico_medicoDAO diagnosticoDAO = new Diagnostico_medicoDAO();

        //Método controlador para listar diagnostico no datatable
        public DataTable listarDiagnosticos()
        {
            try
            {
                DataTable dtDiagnosticos = new DataTable();
                dtDiagnosticos = diagnosticoDAO.MostrarDiagnosticos();

                return dtDiagnosticos;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar serviços no datatable
        public DataTable listarDiagnosticosHoje()
        {
            try
            {
                DataTable dtDiagnosticos = new DataTable();
                dtDiagnosticos = diagnosticoDAO.MostrarDiagnosticosHoje();

                return dtDiagnosticos;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para listar serviços no datatable
        public DataTable listarDiagnosticosUltimos3Dias()
        {
            try
            {
                DataTable dtDiagnosticos = new DataTable();
                dtDiagnosticos = diagnosticoDAO.MostrarDiagnosticosUltimos3Dias();

                return dtDiagnosticos;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        //Método controlador para salvar nova consulta
        public void salvar(Diagnostico_medico diagnostico)
        {
            try
            {
                diagnosticoDAO.Salvar(diagnostico);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //Método controlador para MOSTRAR AS CONSULTAS POR NOME DO VETERINARIO
        public DataTable ListarVeterinarioPorConsulta(Veterinarios veterinarios)
        {
            try
            {
                
                DataTable dt = new DataTable();
                dt = diagnosticoDAO.ConsultasPorVeterinario(veterinarios);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para MOSTRAR AS CONSULTAS POR NOME DO VETERINARIO
        public DataTable ListarVeterinarioPorConsultaHoje(Veterinarios veterinarios)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = diagnosticoDAO.ConsultasPorVeterinarioHoje(veterinarios);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Método controlador para MOSTRAR AS CONSULTAS POR NOME DO VETERINARIO
        public DataTable ListarVeterinarioPorConsultaMenos3Dias(Veterinarios veterinarios)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = diagnosticoDAO.ConsultasPorVeterinarioMenos3Dias(veterinarios);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
