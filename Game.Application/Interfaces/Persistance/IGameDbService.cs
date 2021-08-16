using Game.Application.Interfaces.Persistance.Processing;
using Game.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Interfaces.Persistance
{
    public interface IGameDbService : IDbService
    {
        IGameRepository<Domain.Models.Game, int> Games {get;}
        IGameRepository<VwGameCategories, int> VwGameCategories { get;}
        ICategoryRepository<Category, int> Categories { get; }
        ICategoryRepository<GameCategory, int> GameCategories { get; }
        
}
}
