using Game.Application.Games.Models;
using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Commands.UpdateGameCommand
{
    class UpdateGameCommand : IUpdateGameCommand
    {
        private IGameDbService _dbService;

        public UpdateGameCommand(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        public GameDTO Execute(GameDTO gameDTO)
        {
            var getGame = _dbService.Games.GetById(gameDTO.Id);

            getGame.Id = gameDTO.Id;
            getGame.Name = gameDTO.Name;
            getGame.GameUrl = gameDTO.GameUrl;
            getGame.ImageUrl = gameDTO.ImageUrl;


            // Update Command
            _dbService.Games.Update(getGame);
            _dbService.Save();


            return gameDTO;
        }
    }
}
