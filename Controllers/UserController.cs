using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.DTOs;
using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Agendamento.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserServices _services;

        public UserController(UserServices services)
        {
            _services = services;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(User user)
        {
            try
            {
                await _services.Create(user);

                return Ok("Usuario criado com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar usuario {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuariodto)
        {
            try
            {
                var user = await _services.Login(usuariodto.Email, usuariodto.Senha);

                return Ok(new { userId = user.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}