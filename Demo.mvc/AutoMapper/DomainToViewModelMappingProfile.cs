using AutoMapper;
using Demo.domain.Entities;
using Demo.mvc.ViewModels;

namespace Demo.mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AlumnoViewModel, Alumno>();
            Mapper.CreateMap<CursoViewModel, Curso>();
        }

    }
}