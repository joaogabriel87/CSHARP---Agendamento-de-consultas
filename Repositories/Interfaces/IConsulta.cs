using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;

namespace Agendamento.Repositories.Interfaces
{
    public interface IConsulta
    {
        Task<Consulta> NovaConsulta(Consulta consulta);
        Task Editar(int protocolo, Consulta consulta);
        Task<IEnumerable<Consulta>> TodasConsultas(int paginas, int tamanhoPagina);
    }
}