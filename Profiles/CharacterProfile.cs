using AutoMapper;
using MovieCharacterAPI.Models;
using MovieCharacterAPI.Models.DTO.Character;
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
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            //Character - CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>().ForMember(cdto=> cdto.Movies, opt=>opt.MapFrom(c=>c.Movies.Select(m=>m.Id).ToArray())).ReverseMap();
            //Character - CharacterCreateDTO
            CreateMap<Character, CharacterCreateDTO>().ReverseMap(); 
            //Character - CharacterEditDTO
            CreateMap<Character,CharacterEditDTO>().ReverseMap(); 
               // .ForMember(cdto => cdto.Movies, opt => opt.MapFrom(m => new List<Movie>())).ReverseMap();
        }
    } 
}
