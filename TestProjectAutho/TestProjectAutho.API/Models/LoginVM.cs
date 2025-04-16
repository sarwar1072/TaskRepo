using System.ComponentModel.DataAnnotations;

namespace TestProjectAuthoAPI.Models
{
	public class LoginVM
	{
			[Required]
			public string? EmailAddress { get; set; } 
			[Required]
			public string? PassWord { get; set; } 
	}
}
