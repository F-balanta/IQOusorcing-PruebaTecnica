using IQOUTSOURCING.Domain.DTOs.Usuario;
using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IQOUTSOURCING.RestApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUsuarioService<UsuarioDTO, UsuarioCommandDTO, Usuario, UsuarioDataDTO, UsuarioLoginDTO> usuarioService;

        public SecurityController(IUsuarioService<UsuarioDTO, UsuarioCommandDTO, Usuario, UsuarioDataDTO, UsuarioLoginDTO> usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO entitDTO) => Ok(await usuarioService.GetToken(entitDTO));
    }
}
