using Game.Application.Interfaces.Persistance;
using Game.Application.Interfaces.Persistance.Processing;
using Game.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Persistance.DbService
{
    class GamesDbService : IGameDbService
    {
        private readonly GameDbContext _context;

        public GamesDbService(
            GameDbContext context,
            IGameRepository<Domain.Models.Game, int> games,
            ICategoryRepository<Category, int> categories,
            ICategoryRepository<GameCategory, int> gameCategories,
            IGameRepository<VwGameCategories, int> vwGameCategories
            )
        {
            _context = context;
            Games = games;
            Categories = categories;
            GameCategories = gameCategories;
            VwGameCategories = vwGameCategories;
        }

        public IGameRepository<Domain.Models.Game, int> Games { get; }

        public ICategoryRepository<Category, int> Categories { get; }

        public ICategoryRepository<GameCategory, int> GameCategories { get; }

        public IGameRepository<VwGameCategories, int> VwGameCategories { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
