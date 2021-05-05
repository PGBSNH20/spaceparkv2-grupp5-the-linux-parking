using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Resources
{
    public class CreateSpotResource
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }
        [Required]
        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}