using Application.DTOs.Rol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class UserRolDto
    {
        public Guid Id { get; set; }

        public Guid RolId { get; set; }

        public Guid UserId { get; set; }

        public RolDto Rol { get; set; }

        public User.UserDto User { get; set; }
    }
}
