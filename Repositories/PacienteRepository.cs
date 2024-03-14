using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Date;
using Agendamento.Models;
using Agendamento.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Repositories
{
    public class PacienteRepository : IPaciente
    {
        private readonly DateContext _context;

        public PacienteRepository(DateContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Consulta>> BuscarConsulta(string cpf)
        {
            var paciente = await _context.PacienteDB.AnyAsync(p => p.CPF == cpf);

            if (!paciente)
            {
                throw new Exception("Paciente não existe");
            }

            var consulta = _context.ConsultaDB
                .Where(
                    c =>
                    c.Paciente.CPF == cpf
                );

            return consulta;

        }

        public async Task Editar(string cpf, Paciente paciente)
        {
            var PacienteExist = await _context.PacienteDB.FirstOrDefaultAsync(p => p.CPF == cpf);

            if (PacienteExist == null)
            {
                throw new Exception("Paciente não existe");
            }

            PacienteExist.NomeCompleto = paciente.NomeCompleto;
            PacienteExist.Email = paciente.Email;
            PacienteExist.Telefone = paciente.Telefone;

            await _context.SaveChangesAsync();
        }

        public async Task<Paciente> NovoPaciente(Paciente paciente)
        {
            bool PacienteExist = await _context.PacienteDB.AnyAsync(p => p.CPF == paciente.CPF);

            if (PacienteExist == true)
            {
                throw new Exception("Paciente já existe");
            }

            await _context.AddAsync(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }


    }
}