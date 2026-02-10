using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.Common.Controllers; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.Recipe; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Services.Recipe;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Api . Controllers {
    public partial class RecipesController : QuickCodeBaseApiController
    {
        private readonly IRecipeService service;
        private readonly ILogger<RecipesController> logger;
        private readonly IServiceProvider serviceProvider;
        public RecipesController(IRecipeService service, IServiceProvider serviceProvider, ILogger<RecipesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RecipeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Recipe", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Recipe") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Recipe", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RecipeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(RecipeDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Recipe") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, RecipeDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Recipe", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Recipe", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{recipesIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool recipesIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(recipesIsActive, page, size);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesIsActive: '{recipesIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-name/{recipesRecipeName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNameAsync(string recipesRecipeName, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNameAsync(recipesRecipeName, page, size);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesRecipeName: '{recipesRecipeName}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-ingredient")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecipeIngredientsForRecipesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeIngredientsForRecipesAsync(int recipesId)
        {
            var response = await service.GetRecipeIngredientsForRecipesAsync(recipesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-ingredient/{recipeIngredientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRecipeIngredientsForRecipesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeIngredientsForRecipesDetailsAsync(int recipesId, int recipeIngredientsId)
        {
            var response = await service.GetRecipeIngredientsForRecipesDetailsAsync(recipesId, recipeIngredientsId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}', RecipeIngredientsId: '{recipeIngredientsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-equipment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecipeEquipmentsForRecipesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeEquipmentsForRecipesAsync(int recipesId)
        {
            var response = await service.GetRecipeEquipmentsForRecipesAsync(recipesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-equipment/{recipeEquipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRecipeEquipmentsForRecipesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeEquipmentsForRecipesDetailsAsync(int recipesId, int recipeEquipmentsId)
        {
            var response = await service.GetRecipeEquipmentsForRecipesDetailsAsync(recipesId, recipeEquipmentsId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}', RecipeEquipmentsId: '{recipeEquipmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecipeNotesForRecipesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeNotesForRecipesAsync(int recipesId)
        {
            var response = await service.GetRecipeNotesForRecipesAsync(recipesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-note/{recipeNoteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRecipeNotesForRecipesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeNotesForRecipesDetailsAsync(int recipesId, int recipeNotesId)
        {
            var response = await service.GetRecipeNotesForRecipesDetailsAsync(recipesId, recipeNotesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}', RecipeNotesId: '{recipeNotesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-image")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecipeImagesForRecipesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeImagesForRecipesAsync(int recipesId)
        {
            var response = await service.GetRecipeImagesForRecipesAsync(recipesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-image/{recipeImageId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRecipeImagesForRecipesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeImagesForRecipesDetailsAsync(int recipesId, int recipeImagesId)
        {
            var response = await service.GetRecipeImagesForRecipesDetailsAsync(recipesId, recipeImagesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}', RecipeImagesId: '{recipeImagesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-category-assignment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecipeCategoryAssignmentsForRecipesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeCategoryAssignmentsForRecipesAsync(int recipesId)
        {
            var response = await service.GetRecipeCategoryAssignmentsForRecipesAsync(recipesId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{recipeId}/recipe-category-assignment/{recipeCategoryAssignmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRecipeCategoryAssignmentsForRecipesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecipeCategoryAssignmentsForRecipesDetailsAsync(int recipesId, int recipeCategoryAssignmentsId)
        {
            var response = await service.GetRecipeCategoryAssignmentsForRecipesDetailsAsync(recipesId, recipeCategoryAssignmentsId);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}', RecipeCategoryAssignmentsId: '{recipeCategoryAssignmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{recipesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int recipesId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(recipesId, updateRequest);
            if (HandleResponseError(response, logger, "Recipe", $"RecipesId: '{recipesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}