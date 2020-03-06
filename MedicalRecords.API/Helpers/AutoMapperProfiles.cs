using AutoMapper;
using MedicalRecords.API.Controllers;
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
            
            CreateMap<UserForCreateDto, User>();

            CreateMap<UserForUpdateDto, User>()
                .ForMember(dest => dest.PasswordSalt, opt => {
                    opt.Ignore();
                })
                .ForMember(dest => dest.PasswordHash, opt => {
                    opt.Ignore();
                });

            
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
                    opt.MapFrom(src => src.Department.DepartmentId);
                })
                .ForMember(dest => dest.DepartmentName, opt =>
                {
                    opt.MapFrom(src => src.Department.DepartmentName);
                })
                .ForMember(dest => dest.County, opt =>
                {
                    opt.MapFrom(src => src.County.CountyId);
                })
                .ReverseMap();

            CreateMap<File, FileForListDto>()
                .ForMember(dest => dest.ClientId, opt =>
                {
                    opt.MapFrom(src => src.Client.ClientId);
                })
                .ForMember(dest => dest.ClientName, opt =>
                {
                    opt.MapFrom(src => src.Client.LastName + ", " + src.Client.FirstName);
                })
                .ForMember(dest => dest.BarcodeNum, opt =>
                {
                    opt.MapFrom(src => src.Box.BarcodeNum);
                })
                .ForMember(dest => dest.BoxId, opt =>
                {
                    opt.MapFrom(src => src.Box.BoxId);
                })
                .ForMember(dest => dest.AnticipatedDestructionDate, opt =>{
                    opt.ResolveUsing(src => src.CalculateAnticipatedDestructionDate());
                });

            CreateMap<File, FileForBoxListDto>()
                .ForMember(dest => dest.ClientId, opt =>
                    {
                        opt.MapFrom(src => src.Client.ClientId);
                    })
                    .ForMember(dest => dest.ClientName, opt =>
                    {
                        opt.MapFrom(src => src.Client.LastName + ", " + src.Client.FirstName);
                    });
                    

            CreateMap<FileForCreateDto, File>()
                .ForMember(dest => dest.Client, opt => {
                        opt.Ignore();
                })
                .ForMember(dest => dest.Box, opt => {
                    opt.Ignore();
                });
            
            CreateMap<BoxForUpdateDto, Box>() 
               .ForMember(dest => dest.Department, opt => {
                    opt.Ignore();
                })
                .ForMember(dest => dest.County, opt => {
                    opt.Ignore();
                });
            
            CreateMap<FileForUpdateDto, File>();

            CreateMap<File, FileForDetailDto>()
                .ForMember(dest => dest.BoxId, opt => {
                    opt.MapFrom(src => src.Box.BoxId);
                })
                .ForMember(dest => dest.BarcodeNum, opt => {
                    opt.MapFrom(src => src.Box.BarcodeNum);
                })
                .ForMember(dest => dest.ClientId, opt => {
                    opt.MapFrom(src => src.Client.ClientId);
                })
                .ForMember(dest => dest.ClientName, opt => {
                    opt.MapFrom(src => src.Client.LastName + ", "  + src.Client.FirstName);
                });
            CreateMap<Client, ClientForListDto>()
                .ForMember(dest => dest.ClientName, opt => {
                    opt.MapFrom(src => src.LastName + ", " + src.FirstName);
                });
        } 

    }
}