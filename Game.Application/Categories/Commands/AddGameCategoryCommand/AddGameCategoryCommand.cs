using Game.Application.Categories.Models;
using Game.Application.Interfaces.Persistance;
using Game.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Application.Categories.Commands.AddGameCategoryCommand
{
    class AddGameCategoryCommand : IAddGameCategoryCommand
    {
        private IGameDbService _dbService;

        public AddGameCategoryCommand(IGameDbService dbService)
        {
            _dbService = dbService;
        }

        public void Execute(AddGameCategoryModel addGameCategoryModel)
        {
            var getAllGameCategoris = _dbService.GameCategories.All().Where(x => x.GameId == addGameCategoryModel.GameId);

            foreach (var item in getAllGameCategoris)
            {
                if (item.CategoryId == addGameCategoryModel.CategotyId) throw new Exception($"Category with id {addGameCategoryModel.CategotyId} Registered For game with id {addGameCategoryModel.GameId}");
            }

            var gameCategory = new GameCategory()
            {
                GameId = addGameCategoryModel.GameId,
                CategoryId = addGameCategoryModel.CategotyId
            };

            _dbService.GameCategories.Add(gameCategory);
            _dbService.Save();
        }
    }
}
