using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Interfaces.Persistance.Processing
{
    public interface IGameRepository<T, I>: IRepository<T, I> where T: BaseEntity<I>
    {


    }
}
