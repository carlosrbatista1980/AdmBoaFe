using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Dto;
using Data.Entities;

namespace ApplicationService.Services.ServiceBase
{
    public interface ICondominioService
    {
        List<Condominio> GetAllCondominios();
        Condominio GetCondominioById(int id);
    }
}
