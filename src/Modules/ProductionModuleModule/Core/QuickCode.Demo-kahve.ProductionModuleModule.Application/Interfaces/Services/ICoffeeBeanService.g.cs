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
    public partial interface ICoffeeBeanService
    {
        Task<Response<CoffeeBeanDto>> InsertAsync(CoffeeBeanDto request);
        Task<Response<bool>> DeleteAsync(CoffeeBeanDto request);
        Task<Response<bool>> UpdateAsync(int id, CoffeeBeanDto request);
        Task<Response<List<CoffeeBeanDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CoffeeBeanDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByOriginResponseDto>>> GetByOriginAsync(string coffeeBeansOrigin, int? page, int? size);
        Task<Response<List<GetByBatchIdResponseDto>>> GetByBatchIdAsync(string coffeeBeansBatchId, int? page, int? size);
        Task<Response<long>> GetTotalWeightAsync();
        Task<Response<List<GetRoastingProcessesForCoffeeBeansResponseDto>>> GetRoastingProcessesForCoffeeBeansAsync(int coffeeBeansId);
        Task<Response<GetRoastingProcessesForCoffeeBeansResponseDto>> GetRoastingProcessesForCoffeeBeansDetailsAsync(int coffeeBeansId, int roastingProcessesId);
        Task<Response<int>> UpdateWeightAsync(int coffeeBeansId, UpdateWeightRequestDto updateRequest);
    }
}