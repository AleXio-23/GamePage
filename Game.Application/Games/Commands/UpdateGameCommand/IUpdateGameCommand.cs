using Game.Application.Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Commands.UpdateGameCommand
{
    public interface IUpdateGameCommand
    {
        GameDTO Execute(GameDTO gameDTO);
    }
}
