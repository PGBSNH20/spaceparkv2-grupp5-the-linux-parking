using System.ComponentModel.DataAnnotations;
namespace LinuxParking.API.Domain.Resources
{
    public class AuthResource
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}