using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.Common.Controllers; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.CoffeeBean; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Services.CoffeeBean; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Api . Controllers {
    public partial class CoffeeBeansController : QuickCodeBaseApiController
    {
        private readonly ICoffeeBeanService service;
        private readonly ILogger<CoffeeBeansController> logger;
        private readonly IServiceProvider serviceProvider;
        public CoffeeBeansController(ICoffeeBeanService service, IServiceProvider serviceProvider, ILogger<CoffeeBeansController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CoffeeBeanDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "CoffeeBean", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "CoffeeBean") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoffeeBeanDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "CoffeeBean", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CoffeeBeanDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(CoffeeBeanDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "CoffeeBean") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, CoffeeBeanDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "CoffeeBean", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "CoffeeBean", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-origin/{coffeeBeansOrigin}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByOriginResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByOriginAsync(string coffeeBeansOrigin, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByOriginAsync(coffeeBeansOrigin, page, size);
            if (HandleResponseError(response, logger, "CoffeeBean", $"CoffeeBeansOrigin: '{coffeeBeansOrigin}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-batch-id/{coffeeBeansBatchId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByBatchIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByBatchIdAsync(string coffeeBeansBatchId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByBatchIdAsync(coffeeBeansBatchId, page, size);
            if (HandleResponseError(response, logger, "CoffeeBean", $"CoffeeBeansBatchId: '{coffeeBeansBatchId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-total-weight")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTotalWeightAsync()
        {
            var response = await service.GetTotalWeightAsync();
            if (HandleResponseError(response, logger, "CoffeeBean", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{coffeeBeanId}/roasting-process")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRoastingProcessesForCoffeeBeansResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRoastingProcessesForCoffeeBeansAsync(int coffeeBeansId)
        {
            var response = await service.GetRoastingProcessesForCoffeeBeansAsync(coffeeBeansId);
            if (HandleResponseError(response, logger, "CoffeeBean", $"CoffeeBeansId: '{coffeeBeansId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{coffeeBeanId}/roasting-process/{roastingProcessId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRoastingProcessesForCoffeeBeansResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRoastingProcessesForCoffeeBeansDetailsAsync(int coffeeBeansId, int roastingProcessesId)
        {
            var response = await service.GetRoastingProcessesForCoffeeBeansDetailsAsync(coffeeBeansId, roastingProcessesId);
            if (HandleResponseError(response, logger, "CoffeeBean", $"CoffeeBeansId: '{coffeeBeansId}', RoastingProcessesId: '{roastingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-weight/{coffeeBeansId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateWeightAsync(int coffeeBeansId, [FromBody] UpdateWeightRequestDto updateRequest)
        {
            var response = await service.UpdateWeightAsync(coffeeBeansId, updateRequest);
            if (HandleResponseError(response, logger, "CoffeeBean", $"CoffeeBeansId: '{coffeeBeansId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}