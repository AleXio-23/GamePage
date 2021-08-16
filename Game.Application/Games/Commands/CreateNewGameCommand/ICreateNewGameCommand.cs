using Game.Application.Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Commands.CreateNewGameCommand
{
    public interface ICreateNewGameCommand
    {
        GameDTO Execute(GameDTO gameDTO);
    }
}
