using AutoMapper;
using Demo.domain.Entities;
using Demo.mvc.ViewModels;

namespace Demo.mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Alumno, AlumnoViewModel>();
            Mapper.CreateMap<Curso, CursoViewModel>();
        }
    }
}