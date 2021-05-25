using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas_medicas.Models
{
    //Essa classe deve conter os mesmos atributos da tabela do banco de dados , junto com get e set
    public class Funcionarios
    {
        public int codFuncionario { get; set; }

        public string nomeFuncionario { get; set; }

        public string emailFuncionario { get; set; }

        public Int64 telefoneFixoFunc { get; set; }

        public Int64 telefoneCelularFunc { get; set; }

        public string cidadeFuncionario { get; set; }

        public string estadoFuncionario { get; set; }

        public string enderecoFuncionario { get; set; }

        public string bairroFuncionario { get; set; }

        public string cepFuncionario { get; set; }

        public int numeroResidenciaFuncionario { get; set; }

        public string complementoFuncionario { get; set; }

    }
}
