using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wish.Application.Requests.Auth
{
	public sealed class RegisterRequest
	{
		[Required]
		public string FullName { get; set; } = string.Empty;
		[Required]
		public string Username { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
	}
}
