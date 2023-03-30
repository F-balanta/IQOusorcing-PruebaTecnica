using IQOUTSOURCING.Domain.DTOs.Base;
using IQOUTSOURCING.Domain.Interfaces.Services.Base;

namespace IQOUTSOURCING.Domain.Interfaces.Services
{
    public interface IAuditoriaService<DTO> : IBaseReadOnlyService<DTO> where DTO : BaseDTO
    {

    }
}
