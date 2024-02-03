using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Context;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class UserServices
    {
        private readonly AgendamentoContext _context;

        public UserServices(AgendamentoContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(User user)
        {

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}