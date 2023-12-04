using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class CondominioConfiguration : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.ToTable(nameof(Condominio));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(255)");
            builder.Property(x => x.Endereco).IsRequired().HasColumnType("varchar(255)");
            builder.Property(x => x.Cnpj).IsRequired().HasColumnType("varchar(20)");

            builder.HasMany(x => x.Unidade).WithOne(x => x.Condominio).HasForeignKey(x => x.CondominioId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
