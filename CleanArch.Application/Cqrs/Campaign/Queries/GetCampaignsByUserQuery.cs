using Application.Common.Response;
using Application.DTOs.Campaign;
using Application.DTOs.UsersCampaigns;
using Application.Interfaces.Campaign;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Campaign.Queries
{
    public class GetCampaignsByUserQuery : IRequest<ApiResponse<List<UsersCampaignsDto>>>
    {
        public bool Status { get; set; }
        public Guid UserId { get; set; }
    }
    public class GetCampaignsByUserQueryHandler : IRequestHandler<GetCampaignsByUserQuery, ApiResponse<List<UsersCampaignsDto>>>
    {
        private readonly ICampaignService _campaignService;
        public GetCampaignsByUserQueryHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<ApiResponse<List<UsersCampaignsDto>>> Handle(GetCampaignsByUserQuery request, CancellationToken cancellationToken)
        {
            return await _campaignService.GetCampaignsByUser(request, cancellationToken);
        }
    }
}