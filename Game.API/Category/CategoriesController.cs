using Game.API.Category.Models;
using Game.Application.Categories.Commands.AddGameCategoryCommand;
using Game.Application.Categories.Commands.CreateNewCategoryCommand;
using Game.Application.Categories.Commands.DeleteCategoryCommand;
using Game.Application.Categories.Models;
using Game.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.API.Category
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CategoriesController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        [HttpPut("AddNewCategory")]
        public ActionResult<ServiceResult<CategoryDTO>> AddNewCategory([FromBody] CategoryDTO categoryDTO)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var addCategoryHandler = scope.ServiceProvider.GetService<ICreateNewCategoryCommand>();
            var result = addCategoryHandler.Execute(categoryDTO);

            return new ServiceResult<CategoryDTO> { Success = true, Data = result };
        }



        [HttpDelete("DeleteCategory")]
        public ActionResult<ServiceResult<bool>> DeleteCategory([FromBody] DeleteCategoryRequestModel deleteReequestModel)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var deleteCategoryHandler = scope.ServiceProvider.GetService<IDeleteCategoryCommand>();
            deleteCategoryHandler.Execute(deleteReequestModel.Id);

            return new ServiceResult<bool> { Success = true, Data = true };
        }



        [HttpPut("AddGameCategory")]
        public ActionResult<ServiceResult<AddGameCategoryModel>> AddGameCategory([FromBody] AddGameCategoryModel addGameCategory)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var addGameCategoryHandler = scope.ServiceProvider.GetService<IAddGameCategoryCommand>();
            addGameCategoryHandler.Execute(addGameCategory);

            return new ServiceResult<AddGameCategoryModel> { Success = true, Data = addGameCategory };
        }
        




    }
}
