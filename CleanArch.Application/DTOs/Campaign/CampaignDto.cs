using Application.DTOs.User;
using System;

namespace Application.DTOs.Campaign
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ceco { get; set; }
        public string BuisinessLine { get; set; }
        public string BuisinessType { get; set; }
        public bool Status { get; set; } = true;
    }
}
