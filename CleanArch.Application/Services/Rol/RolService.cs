using Application.Interfaces.Rol;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services.Rol
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly ILogger _logger;


        public RolService(
            IMapper autoMapper,
            IUnitOfWork unitOfWork,
            ILogger<RolService> logger
        )
        {
            _autoMapper = autoMapper;
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

    }
}
