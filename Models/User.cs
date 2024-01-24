using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{

    public enum UserRole
    {
        Admin,
        Paciente,
        Medico
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UserRole Role { get; set; }

        // Relacionamentos
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}