using AutoMapper;
using MedicalRecords.API.Dto;
using MedicalRecords.API.Models;

namespace MedicalRecords.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Box, BoxForListDto>();
            CreateMap<File, FileForBoxListDto>();

        }   
    }
}