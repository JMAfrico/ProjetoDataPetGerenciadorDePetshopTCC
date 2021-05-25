using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas_medicas.Models
{
    public class Consultas 
    {
        public int codConsulta { get; set; }

        public int CodCliente { get; set; }

        public int cod_tipo_animal_consulta { get; set; }

        public int cod_raca_animal_consulta { get; set; }

        public int cod_veterinario { get; set; }

        public int cod_servico { get; set; }

        public DateTime dataConsulta { get; set; }

        public DateTime horaConsulta { get; set; }

        public string valortotal_consulta { get; set; }
        
    }
}
