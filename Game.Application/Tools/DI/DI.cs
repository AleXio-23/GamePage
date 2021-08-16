using Game.Application.Categories.Commands.AddGameCategoryCommand;
using Game.Application.Categories.Commands.CreateNewCategoryCommand;
using Game.Application.Categories.Commands.DeleteCategoryCommand;
using Game.Application.Games.Commands.CreateNewGameCommand;
using Game.Application.Games.Commands.DeleteGameCommand;
using Game.Application.Games.Commands.UpdateGameCommand;
using Game.Application.Games.Queries.GetGameByIdQuery;
using Game.Application.Games.Queries.GetGamesByCategoryQuery;
using Game.Application.Games.Queries.GetGamesQuery;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Tools.DI
{
    public static class DI
    {
        public static IServiceCollection RegisterGameApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IGetGamesQuery, GetGamesQuery>();
            services.AddScoped<ICreateNewGameCommand, CreateNewGameCommand>();
            services.AddScoped<IGetGameByIdQuery, GetGameByIdQuery>();
            services.AddScoped<IUpdateGameCommand, UpdateGameCommand>();
            services.AddScoped<IDeleteGameCommand, DeleteGameCommand>();
            services.AddScoped<IGetGamesByCategoryQuery, GetGamesByCategoryQuery>();

            services.AddScoped<ICreateNewCategoryCommand, CreateNewCategoryCommand>();
            services.AddScoped<IAddGameCategoryCommand, AddGameCategoryCommand>();
            services.AddScoped<IDeleteCategoryCommand, DeleteCategoryCommand>();

            return services;
        }
    }
}
