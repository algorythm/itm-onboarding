using AutoMapper;
using todoProject.Data.Models;
using todoProject.Services.TodoServices;

namespace todoProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, TodoListDto>()
                .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Done));
            CreateMap<TodoListDto, Todo>()
                .ForMember(dest => dest.Done, opt => opt.MapFrom(src => src.Completed));
        }
    }
}