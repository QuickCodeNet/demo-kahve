using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.ProductionError; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . ProductionError {
    public partial interface IProductionErrorService
    {
        Task<Response<ProductionErrorDto>> InsertAsync(ProductionErrorDto request);
        Task<Response<bool>> DeleteAsync(ProductionErrorDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductionErrorDto request);
        Task<Response<List<ProductionErrorDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductionErrorDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProcessIdResponseDto>>> GetByProcessIdAsync(int productionErrorsProcessId, int? page, int? size);
    }
}