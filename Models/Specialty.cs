using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Specialty
    {
        public enum NumEspe
        {
            Cardiologia = 1,
            Dermatologia = 2,
            Ginecologista = 3,
            Ortopedia = 4,
            Pediatria = 5,
            Oftamologia = 6,
            Psiquiatria = 7,

        }

        public int Id { get; set; }
        public NumEspe Especialidade { get; set; }
    }
}