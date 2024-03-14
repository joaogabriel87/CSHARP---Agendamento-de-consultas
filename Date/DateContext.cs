using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Date
{
    public class DateContext : DbContext
    {

        public DateContext(DbContextOptions<DateContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-E5MH590;Database=Agendamento;Integrated Security=SSPI;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>()
            .Property(e => e.DataConsulta)
            .HasColumnType("datetime");


        }

        public DbSet<Paciente> PacienteDB { get; set; }
        public DbSet<Medico> MedicoDB { get; set; }
        public DbSet<Consulta> ConsultaDB { get; set; }
    }
}
