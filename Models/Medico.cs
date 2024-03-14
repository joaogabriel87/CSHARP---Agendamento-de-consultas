using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Medico
    {
        [Key]
        public int CRM { get; set; }
        public string NomeCompleto { get; set; }
        public string Especialidade { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}