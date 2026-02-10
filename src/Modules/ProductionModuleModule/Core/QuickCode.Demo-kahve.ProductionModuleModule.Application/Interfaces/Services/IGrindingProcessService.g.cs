using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.GrindingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . GrindingProcess {
    public partial interface IGrindingProcessService
    {
        Task<Response<GrindingProcessDto>> InsertAsync(GrindingProcessDto request);
        Task<Response<bool>> DeleteAsync(GrindingProcessDto request);
        Task<Response<bool>> UpdateAsync(int id, GrindingProcessDto request);
        Task<Response<List<GrindingProcessDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<GrindingProcessDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByRoastingProcessIdResponseDto>>> GetByRoastingProcessIdAsync(int grindingProcessesRoastingProcessId, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ProcessStatus grindingProcessesProcessStatus, int? page, int? size);
        Task<Response<List<GetPackagingProcessesForGrindingProcessesResponseDto>>> GetPackagingProcessesForGrindingProcessesAsync(int grindingProcessesId);
        Task<Response<GetPackagingProcessesForGrindingProcessesResponseDto>> GetPackagingProcessesForGrindingProcessesDetailsAsync(int grindingProcessesId, int packagingProcessesId);
        Task<Response<int>> UpdateStatusAsync(int grindingProcessesId, UpdateStatusRequestDto updateRequest);
    }
}