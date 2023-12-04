using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Base;

namespace Data.Entities
{
    public class Condominio : EntityBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }

        public IList<Unidade> Unidade { get; set; } = new List<Unidade>();
    }
}
