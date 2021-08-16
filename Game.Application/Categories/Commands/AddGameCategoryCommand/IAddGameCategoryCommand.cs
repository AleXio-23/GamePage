using Game.Application.Categories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Categories.Commands.AddGameCategoryCommand
{
    public interface IAddGameCategoryCommand
    {
        void Execute(AddGameCategoryModel addGameCategoryModel);
    }
}
