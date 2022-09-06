using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ePizzaHub.Entities
{
	public class User : IdentityUser<int>
	{
		public string Name { get; set; }

		[NotMapped]
		public string[] Roles { get; set; }
	}
}

