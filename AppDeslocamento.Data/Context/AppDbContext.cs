﻿
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
        {

        }

        // public DbSet<Condutor> Condutores { get; set; }
        // public DbSet<Cliente> Clientes { get; set; }
        // public DbSet<Veiculo> Veiculos { get; set; }
        // public DbSet<Deslocamento> Condutores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
            modelBuilder.Entity<Condutor>(new CondutorConfiguration().Configure);
            modelBuilder.Entity<Cliente>(new ClienteConfiguration().Configure);
            modelBuilder.Entity<Veiculo>(new VeiculoConfiguration().Configure);
            modelBuilder.Entity<Deslocamento>(new DeslocamentoConfiguration().Configure);
            */

            // https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686
            // https://github.com/JaqueMalman/EuAceito/blob/main/EuAceito.Data/Context/ApplicationDbContext.cs
        }
    }
