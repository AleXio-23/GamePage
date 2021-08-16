using Game.Application.Games.Models;
using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Commands.CreateNewGameCommand
{
    class CreateNewGameCommand : ICreateNewGameCommand
    {
        private IGameDbService _dbService;

        public CreateNewGameCommand(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        public GameDTO Execute(GameDTO gameDTO)
        {

            Domain.Models.Game game = new Domain.Models.Game()
            {
                Name = gameDTO.Name,
                ImageUrl = gameDTO.ImageUrl,
                GameUrl = gameDTO.GameUrl,
            };

            _dbService.Games.Add(game);
            _dbService.Save();
            gameDTO.Id = game.Id;


            return gameDTO;
        }
    }
}
