using System;

namespace LinuxParking.API.Domain.Resources
{
    public class ParkingResource
    {
        public int SpotId { get; set; }
        public string CustomerID { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}