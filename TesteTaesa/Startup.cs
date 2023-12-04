using System.Text.Json;
using System.Text.Json.Serialization;
using ApplicationService.Services;
using ApplicationService.Services.ServiceBase;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace TesteTaesa
{
    public static class Startup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.WriteIndented = true;
                x.JsonSerializerOptions.MaxDepth = 64;
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<TesteTaesaContext>(x => x.UseSqlServer("SqlServer", x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddTransient<TesteTaesaContext>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<ICondominioService, CondominioService>();
            services.AddTransient<IServiceBase, ServiceBase>();

            services.AddMvc();

            services.AddCors(options =>
                options.AddPolicy("All", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }));
        }
    }
}
