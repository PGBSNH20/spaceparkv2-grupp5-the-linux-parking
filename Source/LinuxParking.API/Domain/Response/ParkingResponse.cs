using System.Collections.Generic;
using LinuxParking.API.Domain.Models;

namespace LinuxParking.API.Domain.Response
{
    public class ParkingResponse : BaseResponse
    {
        public ParkingStatus ParkingStatus { get; }
        public IEnumerable<ParkingStatus> ParkingStatuses { get; }
        private ParkingResponse(bool success, string message, ParkingStatus parkingStatus) : base(success, message)
        {
            ParkingStatus = parkingStatus;
        }

        private ParkingResponse(bool success, IEnumerable<ParkingStatus> parkingStatuses) : base(success)
        {
            ParkingStatuses = parkingStatuses;
            Message = null;
        }

        // When creation succeded.
        public ParkingResponse(ParkingStatus parkingStatus) : this(true, string.Empty, parkingStatus) { }
        public ParkingResponse(IEnumerable<ParkingStatus> parkingStatuses) : this(true, parkingStatuses) { }

        // When creation failed.
        public ParkingResponse(string msg) : this(false, msg, null) { }
    }
}