using AutoMapper;
using LinuxParking.Domain.Models;
using LinuxParking.API.Resources;

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