using LinuxParking.Domain.Models;
namespace LinuxParking.Domain.Response
{
    public class StationResponse : BaseResponse
    {
        public Station Station { get; private set; }
        private StationResponse(bool success, string message, Station station) : base(success, message)
        {
            Station = station;
        }

        // When creation succeded.
        public StationResponse(Station station) : this(true, string.Empty, station) {}
        // When creation failed.
        public StationResponse(string msg) : this(false, msg, null) {}
  }
}