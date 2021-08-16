using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Categories.Commands.DeleteCategoryCommand
{
    class DeleteCategoryCommand: IDeleteCategoryCommand
    {
        private IGameDbService _dbService;

        public DeleteCategoryCommand(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        public void Execute(int id)
        {
            _dbService.Categories.Delete(id);
            _dbService.Save();
        }
    }
}
