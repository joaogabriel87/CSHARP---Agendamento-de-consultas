using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Paciente
    {
        [Key]
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}