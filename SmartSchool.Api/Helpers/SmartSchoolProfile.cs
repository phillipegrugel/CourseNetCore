using AutoMapper;
using SmartSchool.Api.Dtos;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegisterDto>().ReverseMap();
            CreateMap<Professor, ProfessorDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );
            CreateMap<ProfessorDto, Professor>();
            CreateMap<Professor, ProfessorRegisterDto>().ReverseMap();
        }
    }
}