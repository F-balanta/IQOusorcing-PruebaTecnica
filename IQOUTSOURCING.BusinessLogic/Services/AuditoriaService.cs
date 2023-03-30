using AutoMapper;
using IQOUTSOURCING.BusinessLogic.Services.Base;
using IQOUTSOURCING.Domain;
using IQOUTSOURCING.Domain.DTOs.Auditoria;
using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces;
using IQOUTSOURCING.Domain.Interfaces.Services;

namespace IQOUTSOURCING.BusinessLogic.Services
{
    internal class AuditoriaService : BaseService, IAuditoriaService<AuditoriaDTO>
    {
        public AuditoriaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<ICollection<AuditoriaDTO>>> GetAll()
        {
            Response<ICollection<AuditoriaDTO>> response = new();

            ICollection<Auditoria?>? auditoriaList = await unitOfWork.AuditoriaRepository.GetAll();
            List<AuditoriaDTO> auditorias = mapper.Map<List<AuditoriaDTO>>(auditoriaList);
            response.Data = auditorias;
            response.Message = response.Data != null ? "Auditorías obtenidas con éxito" : "Ningún usuario ha iniciado sesión";

            return response;
        }
    }
}
