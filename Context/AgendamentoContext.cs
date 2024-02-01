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
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Consultas> ConsultasDb { get; set; }
        public DbSet<User> UserDb { get; set; }

    }
}
