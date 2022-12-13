using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Rol
{
    public class RolDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Status { get; set; } = true;
    }
}
