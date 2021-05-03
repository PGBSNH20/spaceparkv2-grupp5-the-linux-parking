namespace LinuxParking.Domain.Models
{
  public class Spot
  {
    public int Id { get; set; }
    public int Size { get; set; }
    public decimal Price { get; set; }

    public int StationId { get; set; }
    public Station Station { get; set; }
  }
}