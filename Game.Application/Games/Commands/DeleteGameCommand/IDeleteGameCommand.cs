using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Commands.DeleteGameCommand
{
    public interface IDeleteGameCommand
    {
        void Execute(int id);
    }
}
