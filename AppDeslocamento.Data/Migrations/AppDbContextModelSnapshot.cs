﻿// <auto-generated />
using System;
using AppDeslocamento.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDeslocamento.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Condutor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("condutores", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Deslocamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("clienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("condutorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("dataHoraFim")
                        .HasColumnType("datetime")
                        .HasColumnName("dataHoraFim");

                    b.Property<DateTime>("dataHoraInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("dataHoraInicio");

                    b.Property<long>("kmFim")
                        .HasColumnType("bigint")
                        .HasColumnName("kmFim");

                    b.Property<long>("kmInicio")
                        .HasColumnType("bigint")
                        .HasColumnName("kmInicio");

                    b.Property<string>("observacao")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("observacao");

                    b.Property<long>("veiculoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("clienteId");

                    b.HasIndex("condutorId");

                    b.HasIndex("veiculoId");

                    b.ToTable("deslocamentos", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Veiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("descricao");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("placa");

                    b.HasKey("Id");

                    b.ToTable("veiculos", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Deslocamento", b =>
                {
                    b.HasOne("AppDeslocamento.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Deslocamentos_clienteId");

                    b.HasOne("AppDeslocamento.Domain.Entities.Condutor", "Condutor")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("condutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Condutor_Deslocamentos_condutorId");

                    b.HasOne("AppDeslocamento.Domain.Entities.Veiculo", "Veiculo")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("veiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Veiculo_Deslocamentos_veiculoId");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Condutor", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Veiculo", b =>
                {
                    b.Navigation("Deslocamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
