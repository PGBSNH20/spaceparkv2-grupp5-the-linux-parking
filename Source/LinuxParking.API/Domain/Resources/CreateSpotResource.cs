using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Resources
{
    public class CreateSpotResource
    {
        [Required]
        [MinLength(1)]
        public int Size { get; set; }
        [Required]
        [MinLength(1)]
        public decimal Price { get; set; }
    }
}