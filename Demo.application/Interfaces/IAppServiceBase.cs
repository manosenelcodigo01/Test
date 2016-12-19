using System.Collections.Generic;

namespace Demo.application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class 
    {
        bool Add(TEntity t);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        bool Update(TEntity t);
        bool Remove(int id);
    }
}
