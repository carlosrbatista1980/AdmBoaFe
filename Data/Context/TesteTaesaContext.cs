using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class TesteTaesaContext : DbContext
    {
        public TesteTaesaContext()
        {
        }

        public TesteTaesaContext(DbContextOptions<TesteTaesaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Data.Context.TesteTaesaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                //string connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("SesVacina");

                var connectionString1 = "Data Source=localhost;Initial Catalog=DbBoaFe;Persist Security Info=True;User ID=sa;Password=sa;MultipleActiveResultSets=True";
                optionsBuilder?.UseSqlServer(connectionString1);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
    }
}
