using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Base;

namespace Data.Entities
{
    public class Unidade : EntityBase
    {
        public int NumeroUnidade { get; set; }
        public string TamanhoUnidade { get; set; }
        public string LocalizacaoUnidade { get; set; }
        public string Bloco { get; set; }
        public bool Adquirida { get; set; }

        public IList<Pessoa> Pessoa { get; set; } = new List<Pessoa>();
        public Condominio Condominio { get; set; }
        public int CondominioId { get; set; }
    }
}
