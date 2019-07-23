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
            CreateMap<BoxForCreateDto, Box>()
                .ForMember(dest => dest.Department, opt => {
                    opt.Ignore();
                })
                .ForMember(dest => dest.County, opt => {
                    opt.Ignore();
                });
            CreateMap<Box, BoxForListDto>()
                .ForMember(dest => dest.Department, opt =>
                {
                    opt.MapFrom(src => src.Department.DepartmentName);
                })
                .ForMember(dest => dest.County, opt =>
                {
                    opt.MapFrom(src => src.County.CountyName);
                });
            
            CreateMap<Box, BoxForDetailedDto>()
                .ForMember(dest => dest.Department, opt =>
                {
                    opt.MapFrom(src => src.Department.DepartmentName);
                })
                .ForMember(dest => dest.County, opt =>
                {
                    opt.MapFrom(src => src.County.CountyName);
                })
                .ReverseMap();
            CreateMap<File, FileForListDto>()
                .ForMember(dest => dest.ClientId, opt =>
                {
                    opt.MapFrom(src => src.Client.ClientId);
                });

            CreateMap<File, FileForBoxListDto>();

        } 

    }
}