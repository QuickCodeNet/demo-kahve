using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.RoastingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . RoastingProcess {
    public partial interface IRoastingProcessService
    {
        Task<Response<RoastingProcessDto>> InsertAsync(RoastingProcessDto request);
        Task<Response<bool>> DeleteAsync(RoastingProcessDto request);
        Task<Response<bool>> UpdateAsync(int id, RoastingProcessDto request);
        Task<Response<List<RoastingProcessDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RoastingProcessDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByBeanBatchIdResponseDto>>> GetByBeanBatchIdAsync(int roastingProcessesBeanBatchId, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ProcessStatus roastingProcessesProcessStatus, int? page, int? size);
        Task<Response<List<GetGrindingProcessesForRoastingProcessesResponseDto>>> GetGrindingProcessesForRoastingProcessesAsync(int roastingProcessesId);
        Task<Response<GetGrindingProcessesForRoastingProcessesResponseDto>> GetGrindingProcessesForRoastingProcessesDetailsAsync(int roastingProcessesId, int grindingProcessesId);
        Task<Response<int>> UpdateStatusAsync(int roastingProcessesId, UpdateStatusRequestDto updateRequest);
    }
}