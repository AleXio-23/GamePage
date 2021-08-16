using Game.API.Game.Models;
using Game.Application.Games.Commands.CreateNewGameCommand;
using Game.Application.Games.Commands.DeleteGameCommand;
using Game.Application.Games.Commands.UpdateGameCommand;
using Game.Application.Games.Models;
using Game.Application.Games.Queries.GetGameByIdQuery;
using Game.Application.Games.Queries.GetGamesByCategoryQuery;
using Game.Application.Games.Queries.GetGamesQuery;
using Game.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.API.Game
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : BaseController
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GamesController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpPost("GetGames")]
        public ActionResult<ServiceResult<List<GameDTO>>> GetGames([FromBody] GameOrderModel order)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var getGamesHandler = scope.ServiceProvider.GetService<IGetGamesQuery>();
            var result = getGamesHandler.Execute(order);

            return new ServiceResult<List<GameDTO>> { Success = true, Data = result };
        }


        [HttpPut("AddNewGame")]
        public ActionResult<ServiceResult<GameDTO>> AddNewGame([FromBody] GameDTO gameDTO)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var getGamesHandler = scope.ServiceProvider.GetService<ICreateNewGameCommand>();
            var result = getGamesHandler.Execute(gameDTO);

            return new ServiceResult<GameDTO> { Success = true, Data = result };
        }


        [HttpPost("GetGameById")]
        public ActionResult<ServiceResult<GameDTO>> GetGameById([FromBody] GameRequestModel requestModel)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var getGameHandler = scope.ServiceProvider.GetService<IGetGameByIdQuery>();
            var result = getGameHandler.Execute(requestModel.Id);

            return new ServiceResult<GameDTO> { Success = true, Data = result };
        }



        [HttpPost("UpdateGame")]
        public ActionResult<ServiceResult<GameDTO>> UpdateGame([FromBody] GameDTO gameDTO)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var updateGameHandler = scope.ServiceProvider.GetService<IUpdateGameCommand>();
            var result = updateGameHandler.Execute(gameDTO);

            return new ServiceResult<GameDTO> { Success = true, Data = result };
        }



        [HttpDelete("DeleteGame")]
        public ActionResult<ServiceResult<bool>> DeleteGame([FromBody] DeleteReequestModel deleteReequestModel)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var deleteGameHandler = scope.ServiceProvider.GetService<IDeleteGameCommand>();
            deleteGameHandler.Execute(deleteReequestModel.Id);

            return new ServiceResult<bool> { Success = true, Data = true };
        }

        [HttpPost("GetGamesByCategory")]
        public ActionResult<ServiceResult<List<VwGameCategoriesDTO>>> GetGamesByCategory([FromBody] GamesByCategoryRequsetModel request)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var getGameWithCategoriesHandler = scope.ServiceProvider.GetService<IGetGamesByCategoryQuery>();
            var result = getGameWithCategoriesHandler.Execute(request.CategoryId);

            return new ServiceResult<List<VwGameCategoriesDTO>> { Success = true, Data = result };
        }


    }
}
