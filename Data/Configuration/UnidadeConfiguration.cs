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
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable(nameof(Unidade));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Bloco).IsRequired().HasColumnType("varchar(20)");
            builder.Property(x => x.LocalizacaoUnidade).IsRequired().HasColumnType("varchar(60)");
            builder.Property(x => x.NumeroUnidade).IsRequired().HasColumnType("int");
            builder.Property(x => x.TamanhoUnidade).IsRequired().HasColumnType("varchar(60)");
            builder.Property(x => x.Adquirida).IsRequired().HasColumnType("bit");

            builder.HasMany(x => x.Pessoa).WithOne(x => x.Unidade).HasForeignKey(x => x.UnidadeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
