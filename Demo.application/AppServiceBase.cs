using System.Collections.Generic;
using Demo.application.Interfaces;
using Demo.domain.Interfaces.Services;

namespace Demo.application
{
   public class AppServiceBase<TEntity> :IAppServiceBase<TEntity> where TEntity:class
   {
       private readonly IServiceBase<TEntity> _serviceBase;

       public AppServiceBase(IServiceBase<TEntity> serviceBase)
       {
           _serviceBase = serviceBase;
       }

       public bool Add(TEntity t)
       {
           return _serviceBase.Add(t);
       }

       public List<TEntity> GetAll()
       {
           return _serviceBase.GetAll();
       }

       public TEntity GetById(int id)
       {
           return _serviceBase.GetById(id);
       }

       public bool Update(TEntity t)
       {
           return _serviceBase.Update(t);
       }

       public bool Remove(int id)
       {
           return _serviceBase.Remove(id);
       }

   
   }
}
