using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.Common.Controllers; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.GrindingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Services.GrindingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Api . Controllers {
    public partial class GrindingProcessesController : QuickCodeBaseApiController
    {
        private readonly IGrindingProcessService service;
        private readonly ILogger<GrindingProcessesController> logger;
        private readonly IServiceProvider serviceProvider;
        public GrindingProcessesController(IGrindingProcessService service, IServiceProvider serviceProvider, ILogger<GrindingProcessesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GrindingProcessDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "GrindingProcess", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "GrindingProcess") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GrindingProcessDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "GrindingProcess", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GrindingProcessDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(GrindingProcessDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "GrindingProcess") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, GrindingProcessDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "GrindingProcess", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "GrindingProcess", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-roasting-process-id/{grindingProcessesRoastingProcessId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByRoastingProcessIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByRoastingProcessIdAsync(int grindingProcessesRoastingProcessId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByRoastingProcessIdAsync(grindingProcessesRoastingProcessId, page, size);
            if (HandleResponseError(response, logger, "GrindingProcess", $"GrindingProcessesRoastingProcessId: '{grindingProcessesRoastingProcessId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-status/{grindingProcessesProcessStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByStatusResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByStatusAsync(ProcessStatus grindingProcessesProcessStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByStatusAsync(grindingProcessesProcessStatus, page, size);
            if (HandleResponseError(response, logger, "GrindingProcess", $"GrindingProcessesProcessStatus: '{grindingProcessesProcessStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{grindingProcessId}/packaging-process")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPackagingProcessesForGrindingProcessesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPackagingProcessesForGrindingProcessesAsync(int grindingProcessesId)
        {
            var response = await service.GetPackagingProcessesForGrindingProcessesAsync(grindingProcessesId);
            if (HandleResponseError(response, logger, "GrindingProcess", $"GrindingProcessesId: '{grindingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{grindingProcessId}/packaging-process/{packagingProcessId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPackagingProcessesForGrindingProcessesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPackagingProcessesForGrindingProcessesDetailsAsync(int grindingProcessesId, int packagingProcessesId)
        {
            var response = await service.GetPackagingProcessesForGrindingProcessesDetailsAsync(grindingProcessesId, packagingProcessesId);
            if (HandleResponseError(response, logger, "GrindingProcess", $"GrindingProcessesId: '{grindingProcessesId}', PackagingProcessesId: '{packagingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{grindingProcessesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int grindingProcessesId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(grindingProcessesId, updateRequest);
            if (HandleResponseError(response, logger, "GrindingProcess", $"GrindingProcessesId: '{grindingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}