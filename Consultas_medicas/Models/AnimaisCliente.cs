using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consultas_medicas.Models
{
    /*PASSO 2 : CRIAR UMA CLASSE COM OS MESMOS ATRIBUTOS DO TABELA DO BANCO
    public class AnimaisCliente
    {
        public int cod_cadastro { get; set; }

        public int cod_cliente { get; set; }

        public int cod_tipo_animal { get; set; }

        public int cod_raca_animal { get; set; }

        public string nome_animal { get; set; }

        public string peso_animal { get; set; }

        public string altura_animal { get; set; }

        public string cor_animal { get; set; }

    }*/

    //PASSO 2 : CRIAR UMA CLASSE COM OS MESMOS ATRIBUTOS DO TABELA DO BANCO
    public class AnimaisCliente
    {
        public int cod_cadastro { get; set; }

        public int cod_cliente { get; set; }

        public int cod_tipo_animal { get; set; }

        public int cod_raca_animal { get; set; }

        public string nome_animal { get; set; }

        public string peso_animal { get; set; }

        public string altura_animal { get; set; }

        public string cor_animal { get; set; }

        public string idade_animal { get; set; }

        public string sexo_animal { get; set; }

        public string historico_vacinas { get; set; }

        public string historico_medico { get; set; }



    }
}
