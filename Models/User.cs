using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace Agendamento.Models
{

    public enum UserRole
    {
        Admin,
        Paciente,
        Medico
    }

    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        public string Senha { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole Role { get; set; }

        // Relacionamentos

    }
}