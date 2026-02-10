using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.CoffeeBean; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . CoffeeBean {
    public partial class CoffeeBeanService : ICoffeeBeanService
    {
        private readonly ILogger<CoffeeBeanService> _logger;
        private readonly ICoffeeBeanRepository _repository;
        public CoffeeBeanService(ILogger<CoffeeBeanService> logger, ICoffeeBeanRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CoffeeBeanDto>> InsertAsync(CoffeeBeanDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CoffeeBeanDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CoffeeBeanDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CoffeeBeanDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CoffeeBeanDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByOriginResponseDto>>> GetByOriginAsync(string coffeeBeansOrigin, int? page, int? size)
        {
            var returnValue = await _repository.GetByOriginAsync(coffeeBeansOrigin, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByBatchIdResponseDto>>> GetByBatchIdAsync(string coffeeBeansBatchId, int? page, int? size)
        {
            var returnValue = await _repository.GetByBatchIdAsync(coffeeBeansBatchId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetTotalWeightAsync()
        {
            var returnValue = await _repository.GetTotalWeightAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRoastingProcessesForCoffeeBeansResponseDto>>> GetRoastingProcessesForCoffeeBeansAsync(int coffeeBeansId)
        {
            var returnValue = await _repository.GetRoastingProcessesForCoffeeBeansAsync(coffeeBeansId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRoastingProcessesForCoffeeBeansResponseDto>> GetRoastingProcessesForCoffeeBeansDetailsAsync(int coffeeBeansId, int roastingProcessesId)
        {
            var returnValue = await _repository.GetRoastingProcessesForCoffeeBeansDetailsAsync(coffeeBeansId, roastingProcessesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateWeightAsync(int coffeeBeansId, UpdateWeightRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateWeightAsync(coffeeBeansId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}