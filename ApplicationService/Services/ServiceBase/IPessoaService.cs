using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Dto;
using Data.Entities;

namespace ApplicationService.Services.ServiceBase
{
    public interface IPessoaService
    {
        bool CadastrarPessoaUnidade(PessoaDto dto);
        Pessoa EditarPessoa(PessoaDto dto);
        void DeletarPessoa(string cpf);
    }
}
