using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Context;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;


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
            bool emailexist = await _context.UserDb.AnyAsync(u => u.Email == user.Email);
            if (emailexist)
            {
                throw new Exception("O email já está cadastrado");
            }

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<User> Login(string email, string senha)
        {
            bool userExist = await _context.UserDb.AnyAsync(u => u.Email == email);

            if (!userExist)
            {
                throw new Exception("Usuario não cadastrado");
            }

            try
            {
                var user = await _context.UserDb.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
                if (user != null)
                {
                    return user;
                }

                else
                {
                    throw new Exception("Email ou usuario invalido");
                }
            }

            catch (DbUpdateException)
            {
                throw new DbUpdateException("Erro na autenticação");
            }
        }
    }
}