using Game.Application.Categories.Models;
using Game.Application.Interfaces.Persistance;
using Game.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Categories.Commands.CreateNewCategoryCommand
{
    class CreateNewCategoryCommand : ICreateNewCategoryCommand
    {

        private IGameDbService _dbService;

        public CreateNewCategoryCommand(IGameDbService dbService)
        {
            _dbService = dbService;
        }

        public CategoryDTO Execute(CategoryDTO categoryDTO)
        {
            var category = new Category()
            {
                Name = categoryDTO.Name,
                
            };

            _dbService.Categories.Add(category);
            _dbService.Save();
            categoryDTO.Id = category.Id;


            return categoryDTO;
        }
    }
}
