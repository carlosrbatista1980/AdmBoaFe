﻿// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(TesteTaesaContext))]
    partial class TesteTaesaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Condominio", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Unidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Adquirida")
                        .HasColumnType("bit");

                    b.Property<string>("Bloco")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<int>("NumeroUnidade")
                        .HasColumnType("int");

                    b.Property<string>("TamanhoUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Unidade", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Pessoa", b =>
                {
                    b.HasOne("Data.Entities.Unidade", "Unidade")
                        .WithMany("Pessoa")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Data.Entities.Unidade", b =>
                {
                    b.HasOne("Data.Entities.Condominio", "Condominio")
                        .WithMany("Unidade")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("Data.Entities.Condominio", b =>
                {
                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Data.Entities.Unidade", b =>
                {
                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}