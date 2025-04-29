using AutoMapper;
using TaskPomodoro.API.DTOs;
using TaskPomodoro.API.Models;

namespace TaskPomodoro.API.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaReadDTO>();

            CreateMap<TarefaCreateDTO, Tarefa>();
        }
    }
}
