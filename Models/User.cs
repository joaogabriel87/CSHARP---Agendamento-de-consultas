using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agendamento.Models
{
        public class User
        {
                public int Id { get; set; }
                public string Email { get; set; }
                [MinLength(8)]
                [Required(ErrorMessage = "A senha é obrigatorio.")]
                public string Senha { get; set; }
                public string[] Roles { get; set; }
        }
}