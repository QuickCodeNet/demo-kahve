using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.Common.Controllers; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeCategory; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Services.RecipeCategory;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Api . Controllers {
    public partial class RecipeCategoriesController : QuickCodeBaseApiController
    {
        private readonly IRecipeCategoryService service;
        private readonly ILogger<RecipeCategoriesController> logger;
        private readonly IServiceProvider serviceProvider;
        public RecipeCategoriesController(IRecipeCategoryService service, IServiceProvider serviceProvider, ILogger<RecipeCategoriesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RecipeCategoryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "RecipeCategory", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "RecipeCategory") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeCategoryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "RecipeCategory", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RecipeCategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(RecipeCategoryDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "RecipeCategory") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, RecipeCategoryDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "RecipeCategory", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "RecipeCategory", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{recipeCategoriesIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool recipeCategoriesIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(recipeCategoriesIsActive, page, size);
            if (HandleResponseError(response, logger, "RecipeCategory", $"RecipeCategoriesIsActive: '{recipeCategoriesIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeCategoryId}/recipe-category-assignment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecipeCategoryAssignmentsForRecipeCategoriesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeCategoryAssignmentsForRecipeCategoriesAsync(int recipeCategoriesId)
        {
            var response = await service.GetRecipeCategoryAssignmentsForRecipeCategoriesAsync(recipeCategoriesId);
            if (HandleResponseError(response, logger, "RecipeCategory", $"RecipeCategoriesId: '{recipeCategoriesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeCategoryId}/recipe-category-assignment/{recipeCategoryAssignmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRecipeCategoryAssignmentsForRecipeCategoriesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeCategoryAssignmentsForRecipeCategoriesDetailsAsync(int recipeCategoriesId, int recipeCategoryAssignmentsId)
        {
            var response = await service.GetRecipeCategoryAssignmentsForRecipeCategoriesDetailsAsync(recipeCategoriesId, recipeCategoryAssignmentsId);
            if (HandleResponseError(response, logger, "RecipeCategory", $"RecipeCategoriesId: '{recipeCategoriesId}', RecipeCategoryAssignmentsId: '{recipeCategoryAssignmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{recipeCategoriesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int recipeCategoriesId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(recipeCategoriesId, updateRequest);
            if (HandleResponseError(response, logger, "RecipeCategory", $"RecipeCategoriesId: '{recipeCategoriesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}