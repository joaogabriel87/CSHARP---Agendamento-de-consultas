using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string[] Roles { get; set; }
    }
}