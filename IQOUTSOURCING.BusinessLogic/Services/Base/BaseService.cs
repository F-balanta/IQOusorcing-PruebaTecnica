using AutoMapper;
using IQOUTSOURCING.Domain.Interfaces;

namespace IQOUTSOURCING.BusinessLogic.Services.Base
{
    public class BaseService
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IMapper mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
