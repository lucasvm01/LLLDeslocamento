using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDeslocamento.Data.Mapping
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasMaxLength(100);

            builder.Property(p => p.cpf)
                .IsRequired()
                .HasColumnName("cpf")
                .HasMaxLength(11);
        }
    }
}
