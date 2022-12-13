using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.UsersCampaigns
{
    public class UsersCampaigns : Entity
    {
        public Guid CampaignId { get; set; }

        [ForeignKey("CampaignId")]
        public Campaign.Campaign Campaigns { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User.User User { get; set; }
    }
}
