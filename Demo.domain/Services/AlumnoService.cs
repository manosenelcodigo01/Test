using System.Collections.Generic;
using System.Linq;
using Demo.domain.Entities;
using Demo.domain.Interfaces.Repositories;
using Demo.domain.Interfaces.Services;

namespace Demo.domain.Services
{
    public class AlumnoService:ServiceBase<Alumno>,IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoService(IAlumnoRepository alumnoRepository)
            :base(alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        public List<Alumno> BuscarPorNombre(string nombre)
        {
            return _alumnoRepository.BuscarPorNombre(nombre);
        }

        public List<Alumno> Aprobados(List<Alumno> alumnos)
        {
            return alumnos.Where(a => a.Promedio > 10).ToList();
        }

        public List<Curso> ListarCursos()
        {
            return _alumnoRepository.ListarCursos();
        }
    }
}
