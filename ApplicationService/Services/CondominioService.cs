using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Services.ServiceBase;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Services
{
    public class CondominioService : ServiceBase.ServiceBase, ICondominioService
    {
        public List<Condominio> GetAllCondominios()
        {
            var result = Context.Condominio.Include(x => x.Unidade).ToList();
            return result;
        }

        public Condominio GetCondominioById(int id)
        {
            var result = Context.Condominio.Include(x => x.Unidade).Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
    }
}
