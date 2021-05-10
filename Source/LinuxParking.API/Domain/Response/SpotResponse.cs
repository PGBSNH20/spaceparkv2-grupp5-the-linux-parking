using System.Collections.Generic;
using LinuxParking.API.Domain.Models;

namespace LinuxParking.API.Domain.Response
{
    public class SpotResponse : BaseResponse
    {
        public Spot Spot { get; }
        public IEnumerable<Spot> Spots { get; }
        private SpotResponse(bool success, string message, Spot spot) : base(success, message)
        {
            Spot = spot;
        }

        private SpotResponse(bool success, IEnumerable<Spot> spots) : base(success)
        {
            Spots = spots;
            Message = null;
        }

        // When creation succeded.
        public SpotResponse(Spot spot) : this(true, string.Empty, spot) { }
        public SpotResponse(IEnumerable<Spot> spots) : this(true, spots) { }

        // When creation failed.
        public SpotResponse(string msg) : this(false, msg, null) { }
    }
}