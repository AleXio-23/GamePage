using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Categories.Commands.DeleteCategoryCommand
{
    public interface IDeleteCategoryCommand
    {
        void Execute(int id);
    }
}
