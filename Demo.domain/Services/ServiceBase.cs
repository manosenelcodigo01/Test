using System;
using System.Collections.Generic;
using Demo.domain.Interfaces.Repositories;
using Demo.domain.Interfaces.Services;

namespace Demo.domain.Services
{
   public  class ServiceBase<TEntity>:IDisposable,IServiceBase<TEntity> where TEntity:class
   {
       private readonly IRepositoryBase<TEntity> _repository;

       public ServiceBase(IRepositoryBase<TEntity> repository)
       {
           _repository = repository;
       }

       public bool Add(TEntity t)
       {
          return _repository.Add(t);
       }

       public List<TEntity> GetAll()
       {
           return _repository.GetAll();
       }

       public TEntity GetById(int id)
       {
           return _repository.GetById(id);
       }

       public bool Update(TEntity t)
       {
           return _repository.Update(t);
       }

       public bool Remove(int id)
       {
           return _repository.Remove(id);
       }

       public void Dispose()
       {
           throw new NotImplementedException();
       }
   }
}
