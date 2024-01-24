using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Context;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class ConsultaServices
    {
        private readonly AgendamentoContext _context;

        public ConsultaServices(AgendamentoContext context)
        {
            _context = context;
        }

        public List<Consultas> Listar()
        {
            return _context.ConsultasDb.ToList();
        }

        public void Cadastrar(Consultas consultas)
        {


            if (consultas.Numero.Length != 11 || !consultas.Numero.All(char.IsNumber))
            {
                throw new Exception("O número informado não é valido");
            }

        }
    }

}
