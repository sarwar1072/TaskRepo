
using System.ComponentModel.DataAnnotations;

namespace TestProjectAuthoAPI.Models
{
	public class RegisterVM
	{
		public string? FullName { get; set; }
		[Required]
		public string? EmailAddress {get; set;}
        [Required]
		public string? PassWord {get; set;}

		public string? Role {get;set;} 
	}
}