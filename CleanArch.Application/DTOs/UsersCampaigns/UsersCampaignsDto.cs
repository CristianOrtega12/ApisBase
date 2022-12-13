using Application.DTOs.Campaign;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UsersCampaigns
{
    public class UsersCampaignsDto
    {
        public Guid CampaignId { get; set; }
        public CampaignDto Campaigns { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
