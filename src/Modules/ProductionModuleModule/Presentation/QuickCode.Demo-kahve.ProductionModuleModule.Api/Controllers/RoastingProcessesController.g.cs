using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.Common.Controllers; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.RoastingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Services.RoastingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Api . Controllers {
    public partial class RoastingProcessesController : QuickCodeBaseApiController
    {
        private readonly IRoastingProcessService service;
        private readonly ILogger<RoastingProcessesController> logger;
        private readonly IServiceProvider serviceProvider;
        public RoastingProcessesController(IRoastingProcessService service, IServiceProvider serviceProvider, ILogger<RoastingProcessesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RoastingProcessDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "RoastingProcess", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "RoastingProcess") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoastingProcessDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "RoastingProcess", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RoastingProcessDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(RoastingProcessDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "RoastingProcess") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, RoastingProcessDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "RoastingProcess", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "RoastingProcess", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-bean-batch-id/{roastingProcessesBeanBatchId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByBeanBatchIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByBeanBatchIdAsync(int roastingProcessesBeanBatchId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByBeanBatchIdAsync(roastingProcessesBeanBatchId, page, size);
            if (HandleResponseError(response, logger, "RoastingProcess", $"RoastingProcessesBeanBatchId: '{roastingProcessesBeanBatchId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-status/{roastingProcessesProcessStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByStatusResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByStatusAsync(ProcessStatus roastingProcessesProcessStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByStatusAsync(roastingProcessesProcessStatus, page, size);
            if (HandleResponseError(response, logger, "RoastingProcess", $"RoastingProcessesProcessStatus: '{roastingProcessesProcessStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{roastingProcessId}/grinding-process")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetGrindingProcessesForRoastingProcessesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetGrindingProcessesForRoastingProcessesAsync(int roastingProcessesId)
        {
            var response = await service.GetGrindingProcessesForRoastingProcessesAsync(roastingProcessesId);
            if (HandleResponseError(response, logger, "RoastingProcess", $"RoastingProcessesId: '{roastingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{roastingProcessId}/grinding-process/{grindingProcessId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetGrindingProcessesForRoastingProcessesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetGrindingProcessesForRoastingProcessesDetailsAsync(int roastingProcessesId, int grindingProcessesId)
        {
            var response = await service.GetGrindingProcessesForRoastingProcessesDetailsAsync(roastingProcessesId, grindingProcessesId);
            if (HandleResponseError(response, logger, "RoastingProcess", $"RoastingProcessesId: '{roastingProcessesId}', GrindingProcessesId: '{grindingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-status/{roastingProcessesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateStatusAsync(int roastingProcessesId, [FromBody] UpdateStatusRequestDto updateRequest)
        {
            var response = await service.UpdateStatusAsync(roastingProcessesId, updateRequest);
            if (HandleResponseError(response, logger, "RoastingProcess", $"RoastingProcessesId: '{roastingProcessesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}