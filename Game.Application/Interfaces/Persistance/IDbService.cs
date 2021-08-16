using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Interfaces.Persistance
{
    public interface IDbService
    {
        Task SaveAsync();
        void Save();
    }
}
