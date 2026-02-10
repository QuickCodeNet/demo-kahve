using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.Module; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . Module {
    public class GetApiMethodDefinitionsForModulesQuery : IRequest<Response<List<GetApiMethodDefinitionsForModulesResponseDto>>>
    {
        public string ModulesName { get; set; }

        public GetApiMethodDefinitionsForModulesQuery(string modulesName)
        {
            this.ModulesName = modulesName;
        }

        public class GetApiMethodDefinitionsForModulesHandler : IRequestHandler<GetApiMethodDefinitionsForModulesQuery, Response<List<GetApiMethodDefinitionsForModulesResponseDto>>>
        {
            private readonly ILogger<GetApiMethodDefinitionsForModulesHandler> _logger;
            private readonly IModuleRepository _repository;
            public GetApiMethodDefinitionsForModulesHandler(ILogger<GetApiMethodDefinitionsForModulesHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodDefinitionsForModulesResponseDto>>> Handle(GetApiMethodDefinitionsForModulesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodDefinitionsForModulesAsync(request.ModulesName);
                return returnValue.ToResponse();
            }
        }
    }
}