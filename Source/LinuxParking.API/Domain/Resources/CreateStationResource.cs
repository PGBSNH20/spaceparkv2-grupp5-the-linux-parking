using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Resources
{
    public class CreateStationResource
    {
        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Name { get; set; }
    }
}