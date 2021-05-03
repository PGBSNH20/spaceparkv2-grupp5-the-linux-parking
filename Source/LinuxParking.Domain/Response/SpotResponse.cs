using System.Collections.Generic;
using LinuxParking.Domain.Models;

namespace LinuxParking.Domain.Response
{
    public class SpotResponse : BaseResponse
    {
        private IEnumerable<Spot> Spots { get; }
        public Spot Spot { get; set; }

        private SpotResponse(bool success, string message, Spot spot) : base(success)
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