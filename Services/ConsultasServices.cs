using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Context;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Services
{
    public class ConsultasServices
    {
        private readonly AgendamentoContext _context;

        public ConsultasServices(AgendamentoContext context)
        {
            _context = context;
        }

        public async Task<Consultas> NewConsulta(Consultas consultas)
        {
            try
            {
                if (consultas == null)
                {
                    throw new ArgumentNullException(nameof(consultas), "A consulta não pode ser nula");
                }
                if (consultas.Data < DateTime.Now)
                {
                    throw new ArgumentException("A data de consulta esta incorreta");
                }
                if (!Enum.IsDefined(typeof(Especialidade), consultas.especialidade))
                {
                    throw new ArgumentException("A especialidade medica é invalida", nameof(consultas.especialidade));
                }

                await _context.AddAsync(consultas);
                await _context.SaveChangesAsync();
                return consultas;
            }
            catch (DbUpdateException ex)
            {

                throw new Exception("Erro ao salvar a consulta", ex);
            }
        }
    }
}