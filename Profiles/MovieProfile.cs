using AutoMapper;
using MovieCharacterAPI.Models;
using MovieCharacterAPI.Models.DTO.Franchise;
using MovieCharacterAPI.Models.DTO.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacterAPI.Profiles
{
    /// <summary>
    /// Profile to Map between DTO and Entitys 
    /// </summary>
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            //Movie - MovieReadDTO
            CreateMap<Movie, MovieReadDTO>().ForMember(mdto => mdto.Characters, opt => opt.MapFrom(m => m.Characters.Select(c => c.Id).ToArray())).ReverseMap();


            //Movie - MovieCreateDTO
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            //Movie - MovieEditDTO
            CreateMap<Movie, MovieEditDTO>().ReverseMap();
        }
    }
}
