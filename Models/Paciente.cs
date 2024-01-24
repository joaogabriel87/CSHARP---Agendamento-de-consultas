using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}