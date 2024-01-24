using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Context
{
    public class AgendamentoContext : DbContext
    {
        public AgendamentoContext(DbContextOptions<AgendamentoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>()
            .Property(e => e.Especialidade)
            .HasConversion(
                v => (int)v,
        v => (Specialty.NumEspe)v);





        }
        public DbSet<Consultas> ConsultasDb { get; set; }
        public DbSet<User> UserDb { get; set; }
        public DbSet<Specialty> EspecialidadeDb { get; set; }
        public DbSet<Medico> MedicoDb { get; set; }
        public DbSet<Paciente> PacienteDb { get; set; }
    }
}
