using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dto
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public string? CondominioCnpj { get; set; }
        public int? NumeroUnidade { get; set; }
    }
}
