using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public enum Especialidade
    {
        Cardiologista,
        Ortopedista,
        Ginecologista,
        Dermatologista,
        Pediatra
    }

    public class Consultas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Escolha o médico")]
        public Especialidade especialidade { get; set; }
        [Required(ErrorMessage = "A data é obrigatoria")]
        [JsonConverter(typeof(JsonDateFormat))]
        public DateTime Data { get; set; }
    }
}