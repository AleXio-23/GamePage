using Game.Application.Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Queries.GetGameByIdQuery
{
    public interface IGetGameByIdQuery
    {
        GameDTO Execute(int id);
    }
}
