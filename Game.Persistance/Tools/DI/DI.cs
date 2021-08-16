using Game.Application.Interfaces.Persistance;
using Game.Application.Interfaces.Persistance.Processing;
using Game.Domain.Models;
using Game.Persistance.DbService;
using Game.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Persistance.Tools.DI
{
    public static class DI
    {
        public static IServiceCollection RegisterGamePeristanceServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IGameRepository<Domain.Models.Game, int>, GameRepository<Domain.Models.Game, int>>();
            serviceCollection.AddScoped<IGameRepository<VwGameCategories, int>, GameRepository<VwGameCategories, int>>();

            serviceCollection.AddScoped<ICategoryRepository<Category, int>, CategoryRepository<Category, int>>();
            serviceCollection.AddScoped<ICategoryRepository<GameCategory, int>, CategoryRepository<GameCategory, int>>();
            serviceCollection.AddScoped<IGameDbService, GamesDbService>();

            return serviceCollection;
        }
    }
}
