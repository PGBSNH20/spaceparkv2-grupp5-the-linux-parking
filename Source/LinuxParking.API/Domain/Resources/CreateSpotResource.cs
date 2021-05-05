using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Resources
{
    public class CreateSpotResource
    {
        [Required]
        public int Size { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}