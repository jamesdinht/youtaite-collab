using System;
using System.Collections.Generic;
using Collab.Models;

namespace Collab.DAL
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        void Create(TEntity entity);
        bool Update(string id, TEntity entity);
        bool Delete(string id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);
    }
}