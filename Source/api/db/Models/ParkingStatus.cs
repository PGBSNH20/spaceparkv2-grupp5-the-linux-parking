using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.db.Models
{
    public class ParkingStatus
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public int SpotID { get; set; }

        [ForeignKey("SpotID")]
        public virtual Spot Spot { get; set; }

        public ParkingStatus() { }
        public ParkingStatus(DateTime arrivalTime, int customerID, int spotID)
        {
            ArrivalTime = arrivalTime;
            CustomerID = customerID;
            SpotID = spotID;
        }
    }
}