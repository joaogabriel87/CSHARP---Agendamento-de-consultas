using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.DTO;
using Agendamento.Models;
using Agendamento.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteRepository _repository;

        public PacienteController(PacienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("BuscarConsulta")]
        public async Task<IActionResult> BuscarConsulta(string cpf)
        {
            try
            {
                if (cpf.ToString().Length != 11)
                {
                    return BadRequest("CPF invalido");
                }

                var consultas = await _repository.BuscarConsulta(cpf);

                if (consultas == null)
                {
                    return NotFound("Nenhuma consulta encontrada com esse numero de CPF");
                }

                return Ok(consultas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar as consultas");
            }
        }
        [HttpPut("Editar/{cpf}")]
        public async Task<IActionResult> EditarPaciente(string cpf, [FromBody] Paciente paciente)
        {
            if (cpf.ToString().Length != 11 || cpf == null)
            {
                return BadRequest("Cpf esta invalido");
            }
            try
            {
                await _repository.Editar(cpf, paciente);
                return Ok("Editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Novo Paciente")]
        public async Task<IActionResult> NovoPaciente([FromBody] PacienteDTO pacienteDTO)
        {
            try
            {

                var paciente = new Paciente
                {

                    CPF = pacienteDTO.CPF,
                    NomeCompleto = pacienteDTO.NomeCompleto,
                    Email = pacienteDTO.Email,
                    Telefone = pacienteDTO.Telefone
                };

                await _repository.NovoPaciente(paciente);

                return Ok("Visitante cadastrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar paciente: {ex.Message}");
            }
        }

    }
}