using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{

    public enum UserRole
    {
        Admin,
        RegularUser
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UserRole Roles { get; set; }
    }
}