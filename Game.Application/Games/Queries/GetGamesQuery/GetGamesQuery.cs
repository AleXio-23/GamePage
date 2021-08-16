using Game.Application.Games.Models;
using Game.Application.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Application.Games.Queries.GetGamesQuery
{
    class GetGamesQuery : IGetGamesQuery
    {
        private IGameDbService _dbService;

        public GetGamesQuery(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        public List<GameDTO> Execute(GameOrderModel order)
        {




            IQueryable<Domain.Models.Game> games;
            if (order.OrderByField != null && order.OrderByField != "string") { 
                if(order.OrderByField.ToLower() == "id")
                {
                    if (order.OrderByAsc)
                    {
                        games = _dbService.Games.All().OrderBy(x => x.Id);
                    } else
                    {
                        games = _dbService.Games.All().OrderByDescending(x => x.Id);
                    }
                } else if (order.OrderByField.ToLower() == "name")
                {
                    if (order.OrderByAsc)
                    {
                        games = _dbService.Games.All().OrderBy(x => x.Name);
                    }
                    else
                    {
                        games = _dbService.Games.All().OrderByDescending(x => x.Name);
                    }
                } else
                {
                    throw new MissingFieldException();
                }
            }

            else
            {
                games = _dbService.Games.All();
            }
            List<GameDTO> gameDTOs = new List<GameDTO>();

            foreach (var game in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Id = game.Id,
                    Name = game.Name,
                    ImageUrl = game.ImageUrl,
                    GameUrl = game.GameUrl
                });
            }

            return gameDTOs;



        }
    }
}
