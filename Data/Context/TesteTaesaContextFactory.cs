using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class TesteTaesaContextFactory : IDesignTimeDbContextFactory<TesteTaesaContext>
    {
        public TesteTaesaContext CreateDbContext(string[] args)
        {
            //IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //var connString = configuration.GetSection(Directory.GetCurrentDirectory()).GetConnectionString("SqlServer");
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", true, false)
                .Build();

            var connStr = configuration.GetConnectionString("SqlServer");

            var dbContextOptions = new DbContextOptionsBuilder<TesteTaesaContext>();

            if (!string.IsNullOrEmpty(connStr))
            {
                dbContextOptions.UseSqlServer(connStr);

                return new TesteTaesaContext(dbContextOptions.Options);
            }

            return new TesteTaesaContext(new DbContextOptions<TesteTaesaContext>());
        }
    }
}
