using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Campaign
{
    public class Campaign : Entity
    {
        public string Name { get; set; }
        public string Ceco { get; set; }
        public string BuisinessLine { get; set; }
        public string BuisinessType { get; set; }
        public bool Status { get; set; } = true;

    }
}