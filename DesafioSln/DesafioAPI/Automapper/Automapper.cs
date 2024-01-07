using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioAPI.Dto.RealState;
using DesafioAPI.Dto.RealStateImage;
using DesafioAPI.Dto.User;
using DesafioAPI.Models;

namespace DesafioAPI.Automapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            // Mapeamento da classe User 
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserReadDTO>();

            // Mapeamento da classe RealState
            CreateMap<RealStateCreateDTO, RealState>();
            CreateMap<RealStateUpdateDTO, RealState>();
            CreateMap<RealState, RealStateReadDTO>();

            // Mapeamento da classe RealStateImage
            CreateMap<RealStateImageCreateDTO, RealStateImage>();
            CreateMap<RealStateImageUpdateDTO, RealStateImage>();
            CreateMap<RealStateImage, RealStateImageReadDTO>();
        }
    }
}