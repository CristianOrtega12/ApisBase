using Application.Common.Response;
using Application.Cqrs.Campaign.Queries;
using Application.DTOs.Campaign;
using Application.DTOs.UsersCampaigns;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Campaign
{
    public interface ICampaignService
    {
        Task<ApiResponse<List<CampaignDto>>> GetCampaigns(GetCampaignsQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<UsersCampaignsDto>>> GetCampaignsByUser(GetCampaignsByUserQuery request, CancellationToken cancellationToken);
    }
}
