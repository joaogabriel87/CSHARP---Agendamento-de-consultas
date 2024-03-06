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
    public class MedicoRepository : IMedico
    {
        private readonly DateContext _context;

        public MedicoRepository(DateContext context)
        {
            _context = context;
        }
        public async Task<Medico> Cadastro(Medico medico)
        {
            var MedicoExist = await _context.MedicoDB.AnyAsync(x => x.CRM == medico.CRM);

            if (MedicoExist == true)
            {
                throw new Exception("CRM já cadastrado");
            }

            _context.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<IQueryable<Consulta>> ConsultaPorEspecialidade(int crm)
        {
            var medico = await _context.MedicoDB.FirstOrDefaultAsync(x => x.CRM == crm);

            if (medico == null)
            {
                throw new Exception("CRM não encontrado");
            }

            string espcialidadeMedico = medico.Especialidade;

            return _context.ConsultaDB
            .Where(
                c =>
                c.Medico.Especialidade == espcialidadeMedico
            );
        }

        public async Task Editar(int crm, Medico medico)
        {
            var MedicoExist = await _context.MedicoDB.FirstOrDefaultAsync(x => x.CRM == crm);

            if (MedicoExist == null)
            {
                throw new Exception("CRM não encontrado");
            }

            MedicoExist.NomeCompleto = medico.NomeCompleto;

            await _context.SaveChangesAsync();
        }


    }
}