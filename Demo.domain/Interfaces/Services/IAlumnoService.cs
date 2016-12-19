using System.Collections.Generic;
using Demo.domain.Entities;

namespace Demo.domain.Interfaces.Services
{
    public interface IAlumnoService:IServiceBase<Alumno>
    {
        List<Alumno> BuscarPorNombre(string nombre);
        List<Alumno> Aprobados(List<Alumno> alumnos);

        List<Curso> ListarCursos();
    }
}
