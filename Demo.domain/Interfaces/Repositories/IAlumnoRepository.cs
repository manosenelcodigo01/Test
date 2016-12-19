using System.Collections.Generic;
using Demo.domain.Entities;

namespace Demo.domain.Interfaces.Repositories
{
    public interface IAlumnoRepository : IRepositoryBase<Alumno>,ICursoRepository
    {
        List<Alumno> BuscarPorNombre(string nombre);
       
    }
}
