using IQOUTSOURCING.Domain.DTOs.Base;

namespace IQOUTSOURCING.Domain.Interfaces.Services.Base
{
    public interface IBaseReadOnlyService<DTO> where DTO : BaseDTO
    {
        Task<Response<ICollection<DTO>>> GetAll();
    }
}
