using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace Agendamento.Models
{


    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O email é obrigatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        [Required(ErrorMessage = "A senha é obrigatorio.")]
        public string Senha { get; set; }
        [Required]
        public string[] Roles { get; set; }



    }
}