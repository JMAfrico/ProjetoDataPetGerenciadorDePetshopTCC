using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas_medicas.Models
{
    public class Diagnostico_medico
    {
        public int cod_diagnostico { get; set; }

        public int cod_consulta { get; set; }

        public int cod_cadastro { get; set; }

        public string descricao_diagnostico { get; set; }

        public string medicacao_diagnostico { get; set; }

        public string exames_diagnostico { get; set; }

        public DateTime data_diagnostico { get; set; }

        public DateTime hora_diagnostico { get; set; }
    }
}
