using AutoMapper;
using CoreDAL.Entities;
using CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Profiles
{
    public class ClothesProfile : Profile
    {
        public ClothesProfile()
        {
            //CreateMap<Cloth, ClothDto>(); full complete field match
            CreateMap<Cloth, ClothDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material))
                .ForMember(dest => dest.FriendlyName, opt => opt.MapFrom(src => src.FriendlyName));

            CreateMap<ClothDto, Cloth>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material))
                .ForMember(dest => dest.FriendlyName, opt => opt.MapFrom(src => src.FriendlyName));
        }
    }
}
