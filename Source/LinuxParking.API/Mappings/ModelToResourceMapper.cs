using AutoMapper;
using LinuxParking.API.Domain.Models;
using LinuxParking.API.Domain.Resources;

namespace LinuxParking.API.Mappings
{
    public class ModelToResourceMapper : Profile
    {
        public ModelToResourceMapper() {
            CreateMap<Station, StationResource>();
        }
    }
}