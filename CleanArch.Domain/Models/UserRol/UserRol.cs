using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.User
{
    public class UserRol : Entity
	{
		public Guid UserId { get; set; }
		[ForeignKey("UserId")]
		public User User { get; set; }
		public Guid RolId { get; set; }
		[ForeignKey("RolId")]
		public Rol.Rol Rol  { get; set; }

		
	}
}