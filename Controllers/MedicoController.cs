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
    public class MedicoController : ControllerBase
    {
        private readonly MedicoRepository _repository;

        public MedicoController(MedicoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Novo Medico")]
        public async Task<IActionResult> NovoMedico([FromBody] MedicoDTO medicoDTO)
        {
            try
            {
                var medico = new Medico
                {
                    CRM = medicoDTO.CRM,
                    NomeCompleto = medicoDTO.NomeCompleto,
                    Especialidade = medicoDTO.Especialidade
                };

                await _repository.Cadastro(medico);
                return Ok("Medico cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar paciente: {ex.Message}");
            }
        }

        [HttpPut("Editar/{crm}")]
        public async Task<IActionResult> EditarMedico(string crm, [FromBody] MedicoDTO medicoDTO)
        {
            if (crm.ToString().Length != 6 || crm == null)
            {
                return BadRequest("Cpf esta invalido");
            }

            try
            {
                var medico = new Medico
                {
                    NomeCompleto = medicoDTO.NomeCompleto,
                    Especialidade = medicoDTO.Especialidade
                };

                await _repository.Editar(crm, medico);
                return Ok("Editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}