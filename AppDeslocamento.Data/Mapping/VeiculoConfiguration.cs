using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Data.Mapping
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculos");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.placa)
                .IsRequired()
                .HasColumnName("placa")
                .HasMaxLength(100);

            builder.Property(p => p.descricao)
                .HasColumnName("descricao")
                .HasMaxLength(300);
        }
    
    }
}
