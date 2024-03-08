using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Agendamento.Date;
using Agendamento.Models;
using Agendamento.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Repositories
{
    public class ConsultaRepository : IConsulta
    {
        private readonly DateContext _context;

        public ConsultaRepository(DateContext context)
        {
            _context = context;
        }

        public async Task Editar(int protocolo, Consulta consulta)
        {
            var ConsultaExist = await _context.ConsultaDB.FirstOrDefaultAsync(c => c.Protocolo == protocolo);

            if (ConsultaExist == null)
            {
                throw new Exception("Protocolo invalido");
            }

            ConsultaExist.DataConsulta = consulta.DataConsulta;
            ConsultaExist.Especialidade = consulta.Especialidade;

            await _context.SaveChangesAsync();
        }

        public async Task<Consulta> NovaConsulta(Consulta consulta)
        {
            Random random = new Random();
            int protocolo = random.Next(1000000, 999999999);

            while (await _context.ConsultaDB.AnyAsync(c => c.Protocolo == protocolo))
            {
                protocolo = random.Next(1000000, 999999999);
            }

            consulta.Protocolo = protocolo;
            string dataFormatada = consulta.DataConsulta.ToString("dd/MM/yyyy");
            if (consulta.DataConsulta >= DateTime.Now)
            {
                throw new Exception("Informe uma data valida");
            }

            _context.Add(consulta);
            await _context.SaveChangesAsync();
            return consulta;
        }

        public async Task<IEnumerable<Consulta>> TodasConsultas(int pagina, int tamanhoPagina)
        {
            var Consultas = await _context.ConsultaDB
            .OrderBy(c => c.DataConsulta)
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();

            return Consultas;
        }
    }
}