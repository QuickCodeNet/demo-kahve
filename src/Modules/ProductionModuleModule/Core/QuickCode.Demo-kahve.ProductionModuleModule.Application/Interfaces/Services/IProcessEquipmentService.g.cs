using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.ProcessEquipment; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . ProcessEquipment {
    public partial interface IProcessEquipmentService
    {
        Task<Response<ProcessEquipmentDto>> InsertAsync(ProcessEquipmentDto request);
        Task<Response<bool>> DeleteAsync(ProcessEquipmentDto request);
        Task<Response<bool>> UpdateAsync(int id, ProcessEquipmentDto request);
        Task<Response<List<ProcessEquipmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProcessEquipmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool processEquipmentsIsActive, int? page, int? size);
        Task<Response<int>> DeactivateAsync(int processEquipmentsId, DeactivateRequestDto updateRequest);
    }
}