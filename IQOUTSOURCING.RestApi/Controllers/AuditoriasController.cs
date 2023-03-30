using IQOUTSOURCING.Domain.DTOs.Auditoria;
using IQOUTSOURCING.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IQOUTSOURCING.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        private readonly IAuditoriaService<AuditoriaDTO> auditoriaService;

        public AuditoriasController(IAuditoriaService<AuditoriaDTO> auditoriaService)
        {
            this.auditoriaService = auditoriaService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll() => Ok(await auditoriaService.GetAll());
    }
}
