﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public string Phone1 { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public bool Active { get; set; } = true;
        public string PassWord { get; set; }
        public string login { get; set; }

        public List<UserRolDto> UserRol { get; set; }
    }
}
