using Game.Application.Categories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Categories.Commands.CreateNewCategoryCommand
{
    public interface ICreateNewCategoryCommand
    {
        CategoryDTO Execute(CategoryDTO categoryDTO);
    }
}
