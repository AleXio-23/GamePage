using Game.Application.Games.Models;
using Game.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Queries.GetGamesByCategoryQuery
{
    public interface IGetGamesByCategoryQuery
    {
        List<VwGameCategoriesDTO> Execute(int categoryId);
    }
}
