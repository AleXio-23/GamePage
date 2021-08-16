using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Persistance
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class
    {
        public void Add(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public Tentity GetByID(object id)
        {
            throw new NotImplementedException();
        }
    }
}
