using AutoMapper;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Resources;

namespace LinuxParking.API.Mappings
{
  public class ResourceToModelMapping : Profile
  {
    public ResourceToModelMapping()
    {
      CreateMap<CreateStationResource, Station>();
    }
  }
}