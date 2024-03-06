using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;

namespace Agendamento.Repositories.Interfaces
{
    public interface IPaciente
    {
        Task<Paciente> NovoPaciente(Paciente paciente);
        Task Editar(int cpf, Paciente paciente);
        Task<IQueryable<Consulta>> BuscarConsulta(int cpf);
    }
}