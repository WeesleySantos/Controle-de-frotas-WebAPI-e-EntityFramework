using ControleDeFrotaWebApi.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Models.infrastructure.Contexts
{
    public class ControleFrotaContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<MotoristaVeiculo> MotoristaVeiculos { get; set; }
        public ControleFrotaContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntities(modelBuilder);
            InitalizeDate(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected void ConfigureEntities(ModelBuilder modelBuilder)
        {
            ConfigureEntityMotoristaVeiculo(modelBuilder);
            ConfigureEntityMotorista(modelBuilder);
        }
        protected void ConfigureEntityMotoristaVeiculo(ModelBuilder modelBuilder)
        {
            // Configurações para entidade de realcionamento(MotoristaVeiculos)
            modelBuilder.Entity<MotoristaVeiculo>()
                .ToTable("tbl_motr_veicl")
                .HasKey(mv => new { mv.MotoristaId, mv.VeiculoId });

            modelBuilder.Entity<MotoristaVeiculo>()
                .Property(mv => mv.VeiculoId)
                .HasColumnName("veicl_id")
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<MotoristaVeiculo>()
               .Property(mv => mv.MotoristaId)
               .HasColumnName("motor_id")
               .HasColumnType("varchar(50)");
        }
        protected void ConfigureEntityMotorista(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorista>()
                .ToTable("tbl_motor");

            modelBuilder.Entity<Motorista>()
                .HasKey(m => m.MotoristaId);

            modelBuilder.Entity<Motorista>()
                .Property(m => m.MotoristaId)
                .HasColumnName("motor_id")
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Motorista>()
                .Property(m => m.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Motorista>()
                .Property(m => m.CNH)
                .HasColumnName("cnh")
                .HasColumnType("varchar(30)")
                .IsRequired();

            modelBuilder.Entity<Motorista>()
               .Property(m => m.ValidadeCNH)
               .HasColumnName("validadeCNH")
               .HasColumnType("datetime")
               .IsRequired();

            modelBuilder.Entity<Motorista>()
               .Property(m => m.Ativo)
               .HasColumnName("ativo")
               .HasColumnType("bit");
        }
        protected void InitalizeDate(ModelBuilder modelBuilder)
        {
            var motoristaId = BaseEntity.GenerateId();
            modelBuilder.Entity<Motorista>()
                .HasData(new Motorista { MotoristaId = motoristaId, Nome = "Wesley Santos", CNH = "12345678", ValidadeCNH = DateTime.Parse("25/03/2025"), Ativo = true });

            var veiculoId = BaseEntity.GenerateId();
            modelBuilder.Entity<Veiculo>()
                .HasData(new Veiculo { VeiculoId = veiculoId, Modelo = "Onix", Ano = 2020, Placa = "QQD-2D51" });

            modelBuilder.Entity<MotoristaVeiculo>()
                .HasData(new MotoristaVeiculo { MotoristaId = motoristaId, VeiculoId = veiculoId });

            motoristaId = BaseEntity.GenerateId();
            modelBuilder.Entity<Motorista>()
                .HasData(new Motorista { MotoristaId = motoristaId, Nome = "Victoria São Felippe", CNH = "87654321", ValidadeCNH = DateTime.Parse("15/01/2026"), Ativo = true });

            veiculoId = BaseEntity.GenerateId();
            modelBuilder.Entity<Veiculo>()
                .HasData(new Veiculo { VeiculoId = veiculoId, Modelo = "Prima", Ano = 2022, Placa = "VIC-5K31" });

            modelBuilder.Entity<MotoristaVeiculo>()
                .HasData(new MotoristaVeiculo { MotoristaId = motoristaId, VeiculoId = veiculoId });

        }
    }
}
