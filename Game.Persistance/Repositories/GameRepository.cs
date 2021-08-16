using Game.Application.Interfaces.Persistance.Processing;
using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Persistance.Repositories
{
    public class GameRepository<T, I> : Repository<T, I>, IGameRepository<T, I> where T : BaseEntity<I>
    {

        public GameRepository(GameDbContext context): base(context)
        {

        }
    }
}
