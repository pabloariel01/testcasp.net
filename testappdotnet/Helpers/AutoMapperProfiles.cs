using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testappdotnet.Dtos;
using testappdotnet.Models;

namespace testappdotnet.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opts =>
                   opts.MapFrom(src =>
                   src.Photos.FirstOrDefault(p => p.IsMain)))
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src =>
                src.DateOfBirth.CalculateAge()
                )
                );

            CreateMap<User, UserForDetailesDto>()
                .ForMember(dest => dest.PhotoUrl, opts =>
                   opts.MapFrom(src =>
                   src.Photos.FirstOrDefault(p => p.IsMain)
                   )).ForMember(dest => dest.Age, opt =>
                    opt.MapFrom(src =>
                    src.DateOfBirth.CalculateAge()
                    )
                );

            CreateMap<Photo, PhotosForDetailsDto>();
        }
    }
}
