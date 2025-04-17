namespace BlazorApp.Models
{
    public class RegisterVM
    {
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PassWord { get; set; }
        public string Role { get; set; } = "Admin";
    }
}
