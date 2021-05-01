using AutoMapper;
using LinuxParking.Domain.Models;
using LinuxParking.API.Resources;

namespace LinuxParking.API.Mappings
{
    public class ModelToResourceMapper : Profile
    {
        public ModelToResourceMapper() {
            CreateMap<Station, StationResource>();
        }
    }
}