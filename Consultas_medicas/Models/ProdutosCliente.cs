using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas_medicas.Models
{
    public class ProdutosCliente
    {
        public int cod_compra { get; set; }

        public int cod_cliente { get; set; }

        public int cod_produto { get; set; }

       // public string preco_produto { get; set; }

        public string total_compra { get; set; }

        public DateTime data_compra { get; set; }

        public DateTime hora_compra { get; set; }
    }
        
}
