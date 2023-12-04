using ApplicationService.Dto;
using ApplicationService.Services.ServiceBase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TesteTaesa.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BoafeController : ControllerBase
    {
        private IPessoaService _pessoaService;
        private ICondominioService _condominioService;

        public BoafeController(IPessoaService pessoaService, ICondominioService condominioService)
        {
            _pessoaService = pessoaService;
            _condominioService = condominioService;
        }

        [HttpPost]
        public IActionResult CadastrarPessoaUnidade(PessoaDto dto)
        {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            if (_pessoaService.CadastrarPessoaUnidade(dto))
            {
                return Ok("Cadastro feito com sucesso!");
            }

            return Ok("Unidade inexistente ou já adquirida");
        }

        [HttpGet]
        public IActionResult GetAllCondominios()
        {
            var condominios = _condominioService.GetAllCondominios();
            //var result = JsonConvert.SerializeObject(condominios, Formatting.Indented);

            return new JsonResult(new {condominios});
        }

        [HttpGet]
        public IActionResult GetCondominioById(int id)
        {
            var condominio = _condominioService.GetCondominioById(id);
            return Ok(condominio);
        }

        [HttpPut]
        public IActionResult EditarPessoa(PessoaDto dto)
        {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var pessoa = _pessoaService.EditarPessoa(dto);

            return new JsonResult(new
            {
                message = "Pessoa editada com sucesso!",
                pessoa
            });
        }

        [HttpDelete]
        public IActionResult DeletarPessoa(string cpf)
        {
            _ = cpf ?? throw new ArgumentNullException(nameof(cpf));

            _pessoaService.DeletarPessoa(cpf);
            return Ok($"Unidades da pessoa com cpf {cpf} removidas com sucesso!");
        }

    }
}
