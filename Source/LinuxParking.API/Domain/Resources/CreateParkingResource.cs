using System;
using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Resources
{
    public class CreateParkingResource
    {
        [Required]
        public int SpotId { get; set; }
    }
}