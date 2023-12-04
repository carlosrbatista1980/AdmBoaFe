using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Dto;
using ApplicationService.Services.ServiceBase;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Services
{
    public class PessoaService : ServiceBase.ServiceBase, IPessoaService
    {
        public bool CadastrarPessoaUnidade(PessoaDto dto)
        {
            var condominio = Context.Condominio.Include(x => x.Unidade).FirstOrDefault(x => x.Cnpj == dto.CondominioCnpj);

            if (condominio != null)
            {
                var unidade = condominio.Unidade.Where(x => x.NumeroUnidade == dto.NumeroUnidade && !x.Adquirida).FirstOrDefault();

                if (unidade is not null)
                {
                    var pessoa = new Pessoa
                    {
                        UnidadeId = unidade.Id,
                        Cpf = dto.Cpf,
                        Nome = dto.Nome,
                        Telefone = dto.Telefone,
                    };

                    unidade.Adquirida = true;
                    Context.Unidade.Update(unidade);

                    Context.Pessoa.Add(pessoa);
                    return (Context.SaveChanges() > 0);
                }
            }

            return false;
        }

        public Pessoa EditarPessoa(PessoaDto dto)
        {
            var pessoa = Context.Pessoa.Where(x => x.Cpf == dto.Cpf).FirstOrDefault();

            if (pessoa != null)
            {
                pessoa.Nome = dto.Nome;
                pessoa.Telefone = dto.Telefone;

                Context.Pessoa.Update(pessoa);
                Context.SaveChanges();
            }

            return pessoa;
        }

        public void DeletarPessoa(string cpf)
        {
            var pessoa = Context.Pessoa.Where(x => x.Cpf == cpf).ToList();

            if (pessoa.Count > 0)
            {
                var unidadeIds = pessoa.Select(x => x.UnidadeId);
                var unidades = Context.Unidade.Where(x => unidadeIds.Contains(x.Id)).ToList();
                unidades.ForEach(d => d.Adquirida = false);
                
                Context.Pessoa.RemoveRange(pessoa);
                Context.SaveChanges();

                Context.Unidade.UpdateRange(unidades);
                Context.SaveChanges();
            }
        }
    }
}
