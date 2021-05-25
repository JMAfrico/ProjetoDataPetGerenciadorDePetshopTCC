using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas_medicas.Models
{
    public class ConsultasCliente
    {
        public int cod_consulta { get; set; }

        public int status_pagamento { get; set; }

        public int tipo_pagamento { get; set; }
    }
}
