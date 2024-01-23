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
        public DateTime Data { get; set; }
        public int EspecialidadeId { get; set; }
        public sbyte Numero { get; set; }
    }
}