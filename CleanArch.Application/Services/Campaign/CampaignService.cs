using Application.Common.Response;
using Application.Cqrs.Campaign.Queries;
using Application.DTOs.Campaign;
using Application.DTOs.UsersCampaigns;
using Application.Interfaces.Campaign;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Campaign
{
    public class CampaignService : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CampaignService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<List<CampaignDto>>> GetCampaigns(GetCampaignsQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<CampaignDto>>();
            try
            {
                response.Data = _mapper.Map<List<CampaignDto>>(await _unitOfWork.CampaignRepository.Get()
                                                                                                   .Where(x => x.Status == request.Status)
                                                                                                   .ToListAsync());
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
                throw;
            }
            return response;
        }

        public async Task<ApiResponse<List<UsersCampaignsDto>>> GetCampaignsByUser(GetCampaignsByUserQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<UsersCampaignsDto>>();
            try
            {
                response.Data = _mapper.Map<List<UsersCampaignsDto>>(await _unitOfWork.UsersCampaignsRepository.Get().Where(x => x.UserId == request.UserId).Include(x => x.Campaigns).ToListAsync());
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
                throw;
            }
            return response;
        }
    }
}
