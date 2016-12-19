using System.Collections.Generic;
using Demo.domain.Entities;

namespace Demo.domain.Interfaces.Repositories
{
    public interface ICursoRepository
    {
        List<Curso> ListarCursos();
    }
}
