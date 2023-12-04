using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;

namespace ApplicationService.Services.ServiceBase
{
    public class ServiceBase : TesteTaesaContextFactory, IServiceBase
    {
        protected TesteTaesaContext Context = new TesteTaesaContextFactory().CreateDbContext(null);
    }
}
