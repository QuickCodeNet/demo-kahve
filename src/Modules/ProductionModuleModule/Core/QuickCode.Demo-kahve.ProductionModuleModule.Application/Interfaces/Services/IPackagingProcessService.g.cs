using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.PackagingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . PackagingProcess {
    public partial interface IPackagingProcessService
    {
        Task<Response<PackagingProcessDto>> InsertAsync(PackagingProcessDto request);
        Task<Response<bool>> DeleteAsync(PackagingProcessDto request);
        Task<Response<bool>> UpdateAsync(int id, PackagingProcessDto request);
        Task<Response<List<PackagingProcessDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PackagingProcessDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByGrindingProcessIdResponseDto>>> GetByGrindingProcessIdAsync(int packagingProcessesGrindingProcessId, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ProcessStatus packagingProcessesProcessStatus, int? page, int? size);
        Task<Response<int>> UpdateStatusAsync(int packagingProcessesId, UpdateStatusRequestDto updateRequest);
    }
}