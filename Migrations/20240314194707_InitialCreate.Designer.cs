﻿// <auto-generated />
using System;
using Agendamento.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agendamento.Migrations
{
    [DbContext(typeof(DateContext))]
    [Migration("20240314194707_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agendamento.Models.Consulta", b =>
                {
                    b.Property<int>("Protocolo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Protocolo"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime");

                    b.Property<string>("MedicoCRM")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("PacienteCPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Protocolo");

                    b.HasIndex("MedicoCRM");

                    b.HasIndex("PacienteCPF");

                    b.ToTable("ConsultaDB");
                });

            modelBuilder.Entity("Agendamento.Models.Medico", b =>
                {
                    b.Property<string>("CRM")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Especialidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CRM");

                    b.ToTable("MedicoDB");
                });

            modelBuilder.Entity("Agendamento.Models.Paciente", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CPF");

                    b.ToTable("PacienteDB");
                });

            modelBuilder.Entity("Agendamento.Models.Consulta", b =>
                {
                    b.HasOne("Agendamento.Models.Medico", "Medico")
                        .WithMany("Consultas")
                        .HasForeignKey("MedicoCRM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agendamento.Models.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteCPF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Agendamento.Models.Medico", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Agendamento.Models.Paciente", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}