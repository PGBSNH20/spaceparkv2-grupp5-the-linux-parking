using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Resources
{
    public class CreateSpotResource
    {
        [Required]
        public int Id { get; set; }
    }
}