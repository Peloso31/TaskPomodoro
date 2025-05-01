using AutoMapper;
using TaskPomodoro.API.DTOs;
using TaskPomodoro.API.Models;

namespace TaskPomodoro.API.Profiles
{
    public class SessaoPomodroProfile : Profile
    {
        public SessaoPomodroProfile()
        {
            CreateMap<SessaoPomodoro, SessaoReadDTO>();
            CreateMap<SessaoCreateDTO, SessaoPomodoro>();
        }
    }
}
