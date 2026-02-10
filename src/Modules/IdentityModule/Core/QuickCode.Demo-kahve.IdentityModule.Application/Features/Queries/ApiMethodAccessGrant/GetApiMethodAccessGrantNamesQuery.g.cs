using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.ApiMethodAccessGrant; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . ApiMethodAccessGrant {
    public class GetApiMethodAccessGrantNamesQuery : IRequest<Response<List<GetApiMethodAccessGrantNamesResponseDto>>>
    {
        public string ApiMethodAccessGrantsPermissionGroupName { get; set; }

        public GetApiMethodAccessGrantNamesQuery(string apiMethodAccessGrantsPermissionGroupName)
        {
            this.ApiMethodAccessGrantsPermissionGroupName = apiMethodAccessGrantsPermissionGroupName;
        }

        public class GetApiMethodAccessGrantNamesHandler : IRequestHandler<GetApiMethodAccessGrantNamesQuery, Response<List<GetApiMethodAccessGrantNamesResponseDto>>>
        {
            private readonly ILogger<GetApiMethodAccessGrantNamesHandler> _logger;
            private readonly IApiMethodAccessGrantRepository _repository;
            public GetApiMethodAccessGrantNamesHandler(ILogger<GetApiMethodAccessGrantNamesHandler> logger, IApiMethodAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodAccessGrantNamesResponseDto>>> Handle(GetApiMethodAccessGrantNamesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodAccessGrantNamesAsync(request.ApiMethodAccessGrantsPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}