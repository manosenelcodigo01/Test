using System.Collections.Generic;
using Demo.application.Interfaces;
using Demo.domain.Entities;
using Demo.domain.Interfaces.Services;

namespace Demo.application
{
    public class AlumnoAppService:AppServiceBase<Alumno>,IAlumnoAppService
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnoAppService(IAlumnoService alumnoService) : base(alumnoService)
        {
            _alumnoService = alumnoService;
        }

        public List<Alumno> BuscarPorNombre(string nombre)
        {
            return _alumnoService.BuscarPorNombre(nombre);
        }

        public List<Alumno> Aprobados(List<Alumno> alumnos)
        {
            return _alumnoService.Aprobados(alumnos);
        }

        public List<Curso> ListarCursos()
        {
            return _alumnoService.ListarCursos();
        }
    }
}
