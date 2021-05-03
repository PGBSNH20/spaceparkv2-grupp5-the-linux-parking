using LinuxParking.Domain.Models;
using System.Collections.Generic;
namespace LinuxParking.Domain.Response
{
    public class StationResponse : BaseResponse
    {
        public Station Station { get; }
        public IEnumerable<Station> Stations { get; }
        private StationResponse(bool success, string message, Station station) : base(success, message)
        {
            Station = station;
        }

        private StationResponse(bool success, IEnumerable<Station> stations) : base(success)
        {
            Stations = stations;
            Message = null;
        }
        // When creation succeded.
        public StationResponse(Station station) : this(true, string.Empty, station) {}
        public StationResponse(IEnumerable<Station> stations) : this(true, stations) {}
        // When creation failed.
        public StationResponse(string msg) : this(false, msg, null) {}
  }
}