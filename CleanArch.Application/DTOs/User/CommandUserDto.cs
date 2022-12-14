using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.User
{
    public class CommandUserDto
    {
        public string Document { get; set; }
        public string Names { get; set; }
        public string Phone1 { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public bool Active { get; set; } = true;
        public string PassWord { get; set; }
        public string login { get; set; }
    }
}
