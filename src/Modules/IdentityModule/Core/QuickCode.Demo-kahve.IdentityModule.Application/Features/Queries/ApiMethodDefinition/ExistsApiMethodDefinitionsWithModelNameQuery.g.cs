using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.ApiMethodDefinition; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . ApiMethodDefinition {
    public class ExistsApiMethodDefinitionsWithModelNameQuery : IRequest<Response<bool>>
    {
        public string ApiMethodDefinitionsModelName { get; set; }

        public ExistsApiMethodDefinitionsWithModelNameQuery(string apiMethodDefinitionsModelName)
        {
            this.ApiMethodDefinitionsModelName = apiMethodDefinitionsModelName;
        }

        public class ExistsApiMethodDefinitionsWithModelNameHandler : IRequestHandler<ExistsApiMethodDefinitionsWithModelNameQuery, Response<bool>>
        {
            private readonly ILogger<ExistsApiMethodDefinitionsWithModelNameHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public ExistsApiMethodDefinitionsWithModelNameHandler(ILogger<ExistsApiMethodDefinitionsWithModelNameHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ExistsApiMethodDefinitionsWithModelNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ExistsApiMethodDefinitionsWithModelNameAsync(request.ApiMethodDefinitionsModelName);
                return returnValue.ToResponse();
            }
        }
    }
}