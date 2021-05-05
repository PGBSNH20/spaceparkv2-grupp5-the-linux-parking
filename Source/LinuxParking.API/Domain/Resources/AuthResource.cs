using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using LinuxParking.API.Extensions;
namespace LinuxParking.API.Domain.Resources
{
    public class AuthResource
    {
        [Required]
        [UserName]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public void ParseName()
        {
            Username = Regex.Replace(Username, @"\b \b", "");
        }
    }
}