using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinuxParking.API.Domain.Models
{
    public class ParkingStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public string CustomerID { get; set; }

        public int SpotID { get; set; }

        [ForeignKey("SpotID")]
        public virtual Spot Spot { get; set; }

        public int StationId { get; set; }

        public ParkingStatus() { }
        public ParkingStatus(DateTime arrivalTime, string customerID, int spotID)
        {
            ArrivalTime = arrivalTime;
            CustomerID = customerID;
            SpotID = spotID;
        }
    }
}