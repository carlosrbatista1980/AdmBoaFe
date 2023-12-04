using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Base;

namespace Data.Entities
{
    public class Pessoa : EntityBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public Unidade Unidade { get; set; }
        public int UnidadeId { get; set; }
    }
}
