using System.Collections.Generic;
namespace LinuxParking.Domain.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Spot> Spots { get; set; } = new List<Spot>();
    }
}