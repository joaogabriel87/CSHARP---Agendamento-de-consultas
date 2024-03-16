using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;

namespace Agendamento.Repositories.Interfaces
{
    public interface IMedico
    {
        Task<Medico> Cadastro(Medico medico);
        Task Editar(string crm, Medico medico);
        Task<IQueryable<Consulta>> ConsultaPorEspecialidade(string crm);
    }


}