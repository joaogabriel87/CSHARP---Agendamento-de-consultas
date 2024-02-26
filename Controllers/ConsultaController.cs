using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Agendamento.Controllers
{
    [Route("[controller]")]
    public class ConsultaController : Controller
    {
        private readonly ConsultasServices _services;

        public ConsultaController(ConsultasServices services)
        {
            _services = services;
        }
        [Authorize(Policy = "paciente")]
        [HttpPost("NovaConsulta")]
        public async Task<IActionResult> NovaConsulta(Consultas consulta)
        {
            try
            {
                await _services.NewConsulta(consulta);
                return Ok("Cosnulta cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}