using Game.Application.Games.Models;
using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Queries.GetGameByIdQuery
{
    class GetGameByIdQuery : IGetGameByIdQuery
    {
        private IGameDbService _dbService;

        public GetGameByIdQuery(IGameDbService dbService)
        {
            _dbService = dbService;
        }

        public GameDTO Execute(int id)
        {
            var getGame = _dbService.Games.GetById(id);

            if(getGame == null)
            {
                throw new Exception($"Game  with id: {id} Not found");
            }

            var gameDTO = new GameDTO()
            {
                Id = getGame.Id,
                Name = getGame.Name,
                GameUrl = getGame.GameUrl,
                ImageUrl = getGame.ImageUrl
            };

            return gameDTO;
        }
    }
}
