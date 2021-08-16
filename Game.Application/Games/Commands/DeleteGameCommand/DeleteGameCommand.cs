using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Commands.DeleteGameCommand
{
    class DeleteGameCommand : IDeleteGameCommand
    {
        private IGameDbService _dbService;

        public DeleteGameCommand(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        public void Execute(int id)
        {
            _dbService.Games.Delete(id);
            _dbService.Save();
        }
    }
}
