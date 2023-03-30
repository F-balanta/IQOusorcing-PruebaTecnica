using IQOUTSOURCING.Domain.DTOs.Usuario;
using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IQOUTSOURCING.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService<UsuarioDTO, UsuarioCommandDTO, Usuario, UsuarioDataDTO, UsuarioLoginDTO> usuarioService;

        public UsuariosController(IUsuarioService<UsuarioDTO, UsuarioCommandDTO, Usuario, UsuarioDataDTO, UsuarioLoginDTO> usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll() => Ok(await usuarioService.GetAll());

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> ObtenerPorId(Guid id) => Ok(await usuarioService.GetById(id));

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Agregar([FromBody] UsuarioCommandDTO entitDTO) => Ok(await usuarioService.Add(entitDTO));

        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] UsuarioCommandDTO entityDTO) => Ok(await usuarioService.Update(id, entityDTO));

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Elimiinar(Guid id) => Ok(await usuarioService.Delete(id));
    }
}
