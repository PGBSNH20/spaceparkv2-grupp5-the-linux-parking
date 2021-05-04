using System.ComponentModel.DataAnnotations;
namespace LinuxParking.API.Domain.Resources
{
    public class UserRegisterResource
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}