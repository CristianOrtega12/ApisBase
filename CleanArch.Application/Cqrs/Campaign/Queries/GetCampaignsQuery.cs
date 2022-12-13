using Application.Common.Response;
using Application.DTOs.Campaign;
using Application.Interfaces.Campaign;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Campaign.Queries
{
    public class GetCampaignsQuery : IRequest<ApiResponse<List<CampaignDto>>>
    {
        public bool Status { get; set; }
    }
    public class GetCampaignsQueriesHandler : IRequestHandler<GetCampaignsQuery, ApiResponse<List<CampaignDto>>>
    {
        private readonly ICampaignService _campaignService;
        public GetCampaignsQueriesHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        public async Task<ApiResponse<List<CampaignDto>>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
        {
            return await _campaignService.GetCampaigns(request, cancellationToken);
        }
    }
}