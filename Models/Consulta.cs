using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Consulta
    {
        [Key]
        public int Protocolo { get; set; }
        public DateTime DataConsulta { get; set; }
        public Paciente Paciente { get; set; }
        public Paciente CPF { get; set; }
        public Medico Medico { get; set; }
        public Medico Especialidade { get; set; }


    }
}