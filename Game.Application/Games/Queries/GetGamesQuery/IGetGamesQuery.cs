using Game.Application.Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Queries.GetGamesQuery
{
    public interface IGetGamesQuery
    {
        List<GameDTO> Execute(GameOrderModel order);
    }
}
