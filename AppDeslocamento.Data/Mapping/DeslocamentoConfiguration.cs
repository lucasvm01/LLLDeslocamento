﻿using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDeslocamento.Data.Mapping
{
    internal class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.ToTable("deslocamentos");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Cliente)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.clienteId)
                .HasConstraintName("FK_Cliente_Deslocamentos_clienteId");

            builder.HasOne(p => p.Condutor)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.condutorId)
                .HasConstraintName("FK_Condutor_Deslocamentos_condutorId");

            builder.HasOne(p => p.Veiculo)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.veiculoId)
                .HasConstraintName("FK_Veiculo_Deslocamentos_veiculoId");

            builder.Property(p => p.dataHoraInicio)
                .IsRequired()
                .HasColumnName("data_hora_inicio")
                .HasColumnType("datetime");

            builder.Property(p => p.kmInicio)
                .IsRequired()
                .HasColumnName("km_inicio");

            builder.Property(p => p.observacao)
                .HasColumnName("observacao")
                .HasMaxLength(300);

            builder.Property(p => p.dataHoraFim)
                .IsRequired()
                .HasColumnName("data_hora_fim")
                .HasColumnType("datetime");

            builder.Property(p => p.kmFim)
                .IsRequired()
                .HasColumnName("km_fim");
        }
    }
}
