using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Consultas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int EspecialidadeId { get; set; }
        [Required]
        public string Numero { get; set; }

        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; }


    }
}