using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.Common.Controllers; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeCategoryAssignment; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Services.RecipeCategoryAssignment;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Api . Controllers {
    public partial class RecipeCategoryAssignmentsController : QuickCodeBaseApiController
    {
        private readonly IRecipeCategoryAssignmentService service;
        private readonly ILogger<RecipeCategoryAssignmentsController> logger;
        private readonly IServiceProvider serviceProvider;
        public RecipeCategoryAssignmentsController(IRecipeCategoryAssignmentService service, IServiceProvider serviceProvider, ILogger<RecipeCategoryAssignmentsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RecipeCategoryAssignmentDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeCategoryAssignmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RecipeCategoryAssignmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(RecipeCategoryAssignmentDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, RecipeCategoryAssignmentDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-recipe-id/{recipeCategoryAssignmentsRecipeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByRecipeIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByRecipeIdAsync(int recipeCategoryAssignmentsRecipeId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByRecipeIdAsync(recipeCategoryAssignmentsRecipeId, page, size);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment", $"RecipeCategoryAssignmentsRecipeId: '{recipeCategoryAssignmentsRecipeId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-category-id/{recipeCategoryAssignmentsCategoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCategoryIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCategoryIdAsync(int recipeCategoryAssignmentsCategoryId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCategoryIdAsync(recipeCategoryAssignmentsCategoryId, page, size);
            if (HandleResponseError(response, logger, "RecipeCategoryAssignment", $"RecipeCategoryAssignmentsCategoryId: '{recipeCategoryAssignmentsCategoryId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}