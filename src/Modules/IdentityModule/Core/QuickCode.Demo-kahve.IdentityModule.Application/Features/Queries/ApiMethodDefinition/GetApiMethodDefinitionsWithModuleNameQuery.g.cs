using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.ApiMethodDefinition; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . ApiMethodDefinition {
    public class GetApiMethodDefinitionsWithModuleNameQuery : IRequest<Response<List<GetApiMethodDefinitionsWithModuleNameResponseDto>>>
    {
        public string ApiMethodDefinitionsModuleName { get; set; }

        public GetApiMethodDefinitionsWithModuleNameQuery(string apiMethodDefinitionsModuleName)
        {
            this.ApiMethodDefinitionsModuleName = apiMethodDefinitionsModuleName;
        }

        public class GetApiMethodDefinitionsWithModuleNameHandler : IRequestHandler<GetApiMethodDefinitionsWithModuleNameQuery, Response<List<GetApiMethodDefinitionsWithModuleNameResponseDto>>>
        {
            private readonly ILogger<GetApiMethodDefinitionsWithModuleNameHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public GetApiMethodDefinitionsWithModuleNameHandler(ILogger<GetApiMethodDefinitionsWithModuleNameHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodDefinitionsWithModuleNameResponseDto>>> Handle(GetApiMethodDefinitionsWithModuleNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodDefinitionsWithModuleNameAsync(request.ApiMethodDefinitionsModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}