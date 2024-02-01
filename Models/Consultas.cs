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
        public string Especialidades { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Numero { get; set; }
    }
}