using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dto
{
    public class UnidadeDto
    {
        public int NumeroUnidade { get; set; }
        public string TamanhoUnidade { get; set; }
        public string LocalizacaoUnidade { get; set; }
        public string? Bloco { get; set; }
        public bool Adquirida { get; set; }

    }
}
