using LinuxParking.Domain.Models;
namespace LinuxParking.Domain.Response
{
    public class CreateStationResponse : BaseResponse
    {
        public Station Station { get; private set; }
        private CreateStationResponse(bool success, string message, Station station) : base(success, message)
        {
            Station = station;
        }

        // When creation succeded.
        public CreateStationResponse(Station station) : this(true, string.Empty, station) {}
        // When creation failed.
        public CreateStationResponse(string msg) : this(false, msg, null) {}
  }
}