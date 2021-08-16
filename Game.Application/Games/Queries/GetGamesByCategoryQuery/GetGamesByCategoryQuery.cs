using Game.Application.Games.Models;
using Game.Application.Interfaces.Persistance;
using Game.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Application.Games.Queries.GetGamesByCategoryQuery
{
    class GetGamesByCategoryQuery : IGetGamesByCategoryQuery
    {
        private IGameDbService _dbService;

        public GetGamesByCategoryQuery(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        public List<VwGameCategoriesDTO> Execute(int categoryId)
        {
            var games = _dbService.VwGameCategories.All().Where(x => x.CategoryId == categoryId).ToList();

            var gameDtos = new List<VwGameCategoriesDTO>();

            foreach (var game in games)
            {
                gameDtos.Add(new VwGameCategoriesDTO()
                {
                    Id = game.Id,
                    CategoryId = game.CategoryId,
                    GameId = game.GameId,
                    GameName = game.GameName,
                    CategoryName = game.CategoryName,
                    ImageUrl = game.ImageUrl,
                    GameUrl = game.GameUrl
                });
            }

            return gameDtos;

        }
    }
}
