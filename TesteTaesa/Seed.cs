using System.Runtime.CompilerServices;
using ApplicationService.Services;
using Data.Context;
using Data.Entities;

namespace TesteTaesa
{
    public class Seed : SeedService
    {
        public void ApplyDefaultSeed()
        {
            if (Context.Condominio.Any())
            {
                return;
            }

            var condominios = new List<Condominio>();

            var cond = new[]
            {
                new { nome = "Condominio das aguas", endereco = "Avenida das aguas, 998 - Barra da tijuca - RJ", cnpj = "68308198000109" },
                new { nome = "Condominio Solaris", endereco = "Avenida das americas, 4778 - Barra da tijuca - RJ", cnpj = "76568065000108" },
                new { nome = "Condominio Viva bem", endereco = "Rua das camelias, 235 - Vila valqueire - RJ", cnpj = "33928400000110" }
            };

            var unid = new[]
            {
                new { numero = 301, localizacao = "3 Andar", bloco = "A", tamanho = "100m2" },
                new { numero = 303, localizacao = "3 Andar", bloco = "A", tamanho = "100m2" },
                new { numero = 305, localizacao = "3 Andar", bloco = "A", tamanho = "100m2" },
                new { numero = 402, localizacao = "4 Andar", bloco = "A", tamanho = "50m2" },
                new { numero = 404, localizacao = "4 Andar", bloco = "A", tamanho = "50m2" },
                new { numero = 406, localizacao = "4 Andar", bloco = "A", tamanho = "50m2" },
                new { numero = 501, localizacao = "5 Andar", bloco = "A", tamanho = "180m2" },
                new { numero = 503, localizacao = "5 Andar", bloco = "A", tamanho = "180m2" },
                new { numero = 505, localizacao = "5 Andar", bloco = "A", tamanho = "180m2" },
            };
            
            for (int i = 0; i < 3; i++)
            {
                var condominio = new Condominio()
                {
                    Nome = cond[i].nome,
                    Endereco = cond[i].endereco,
                    Cnpj = cond[i].cnpj,
                };

                for (int j = 0; j < 9; j++)
                {
                    var unidade = new Unidade()
                    {
                        NumeroUnidade = unid[j].numero,
                        LocalizacaoUnidade = unid[j].localizacao,
                        Bloco = unid[j].bloco,
                        TamanhoUnidade = unid[j].tamanho,
                        Adquirida = false,
                    };

                    condominio.Unidade.Add(unidade);
                }

                condominios.Add(condominio);
            }

            Context.Condominio.AddRange(condominios);
            Context.SaveChanges();
        }
    }
}
