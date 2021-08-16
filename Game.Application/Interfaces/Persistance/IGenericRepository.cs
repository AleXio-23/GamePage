using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Interfaces.Persistance
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        TEntity GetByID(object id);
        void Add(TEntity entity);
    }
}
