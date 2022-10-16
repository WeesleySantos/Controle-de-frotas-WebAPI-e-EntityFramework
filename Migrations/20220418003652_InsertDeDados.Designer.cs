﻿// <auto-generated />
using System;
using ControleDeFrotaWebApi.Models.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleDeFrotaWebApi.Migrations
{
    [DbContext(typeof(ControleFrotaContext))]
    [Migration("20220418003652_InsertDeDados")]
    partial class InsertDeDados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleDeFrotaWebApi.Models.Domain.Entities.Motorista", b =>
                {
                    b.Property<string>("MotoristaId")
                        .HasColumnName("motor_id")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnName("cnh")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("ValidadeCNH")
                        .HasColumnName("validadeCNH")
                        .HasColumnType("datetime");

                    b.HasKey("MotoristaId");

                    b.ToTable("tbl_motor");

                    b.HasData(
                        new
                        {
                            MotoristaId = "f50449ce-eecb-4a9b-9a60-55f28e75f231",
                            Ativo = true,
                            CNH = "12345678",
                            Nome = "Wesley Santos",
                            ValidadeCNH = new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MotoristaId = "0f683f4f-4474-43b2-a97f-4788c068cc71",
                            Ativo = true,
                            CNH = "87654321",
                            Nome = "Victoria São Felippe",
                            ValidadeCNH = new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ControleDeFrotaWebApi.Models.Domain.Entities.MotoristaVeiculo", b =>
                {
                    b.Property<string>("MotoristaId")
                        .HasColumnName("motor_id")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("VeiculoId")
                        .HasColumnName("veicl_id")
                        .HasColumnType("varchar(50)");

                    b.HasKey("MotoristaId", "VeiculoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("tbl_motr_veicl");

                    b.HasData(
                        new
                        {
                            MotoristaId = "f50449ce-eecb-4a9b-9a60-55f28e75f231",
                            VeiculoId = "13e9aab5-7e2a-471a-bbd7-44082774216a"
                        },
                        new
                        {
                            MotoristaId = "0f683f4f-4474-43b2-a97f-4788c068cc71",
                            VeiculoId = "d01f14be-e33f-49fb-a11d-5edba7a8de84"
                        });
                });

            modelBuilder.Entity("ControleDeFrotaWebApi.Models.Domain.Entities.Veiculo", b =>
                {
                    b.Property<string>("VeiculoId")
                        .HasColumnName("veicl_id")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Ano")
                        .HasColumnName("ano")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnName("modelo")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .HasColumnName("placa")
                        .HasColumnType("varchar(20)");

                    b.HasKey("VeiculoId");

                    b.ToTable("tbl_veicl");

                    b.HasData(
                        new
                        {
                            VeiculoId = "13e9aab5-7e2a-471a-bbd7-44082774216a",
                            Ano = 2020,
                            Modelo = "Onix",
                            Placa = "QQD-2D51"
                        },
                        new
                        {
                            VeiculoId = "d01f14be-e33f-49fb-a11d-5edba7a8de84",
                            Ano = 2022,
                            Modelo = "Prima",
                            Placa = "VIC-5K31"
                        });
                });

            modelBuilder.Entity("ControleDeFrotaWebApi.Models.Domain.Entities.MotoristaVeiculo", b =>
                {
                    b.HasOne("ControleDeFrotaWebApi.Models.Domain.Entities.Motorista", "Motorista")
                        .WithMany("Veiculos")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeFrotaWebApi.Models.Domain.Entities.Veiculo", "Veiculo")
                        .WithMany("Motoristas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
