using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.ApiMethodDefinition; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . ApiMethodDefinition {
    public class GetApiMethodAccessGrantsForApiMethodDefinitionsQuery : IRequest<Response<List<GetApiMethodAccessGrantsForApiMethodDefinitionsResponseDto>>>
    {
        public string ApiMethodDefinitionsKey { get; set; }

        public GetApiMethodAccessGrantsForApiMethodDefinitionsQuery(string apiMethodDefinitionsKey)
        {
            this.ApiMethodDefinitionsKey = apiMethodDefinitionsKey;
        }

        public class GetApiMethodAccessGrantsForApiMethodDefinitionsHandler : IRequestHandler<GetApiMethodAccessGrantsForApiMethodDefinitionsQuery, Response<List<GetApiMethodAccessGrantsForApiMethodDefinitionsResponseDto>>>
        {
            private readonly ILogger<GetApiMethodAccessGrantsForApiMethodDefinitionsHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public GetApiMethodAccessGrantsForApiMethodDefinitionsHandler(ILogger<GetApiMethodAccessGrantsForApiMethodDefinitionsHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodAccessGrantsForApiMethodDefinitionsResponseDto>>> Handle(GetApiMethodAccessGrantsForApiMethodDefinitionsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodAccessGrantsForApiMethodDefinitionsAsync(request.ApiMethodDefinitionsKey);
                return returnValue.ToResponse();
            }
        }
    }
}