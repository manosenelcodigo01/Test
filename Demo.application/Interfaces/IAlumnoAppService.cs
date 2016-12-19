using System.Collections.Generic;
using Demo.domain.Entities;

namespace Demo.application.Interfaces
{
    public interface IAlumnoAppService : IAppServiceBase<Alumno>
    {
        List<Alumno> BuscarPorNombre(string nombre);
        List<Alumno> Aprobados(List<Alumno> alumnos);

        List<Curso> ListarCursos();
    }
}
