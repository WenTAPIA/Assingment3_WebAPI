using AutoMapper;
using MovieCharacterAPI.Models;
using MovieCharacterAPI.Models.DTO.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacterAPI.Profiles
{
    /// <summary>
    /// Profile to Map between DTO and Entitys 
    /// </summary>
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            //Franchise-FranchiseReadDTO
            CreateMap<Franchise, FranchiseReadDTO>().ForMember(fdto => fdto.Movies, opt => opt.MapFrom(f => f.Movies.Select(m => m.Id).ToArray())).ReverseMap();
            //FranchiseCreateDTO- Franchise
            CreateMap<Franchise, FranchiseCreateDTO>().ReverseMap();
            //FranchiseEditDTO- Franchise
            CreateMap<Franchise, FranchiseEditDTO>().ReverseMap();
        }
    } 
}
