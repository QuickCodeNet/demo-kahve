using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.PermissionGroup; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . PermissionGroup {
    public class GetApiMethodAccessGrantsForPermissionGroupsDetailsQuery : IRequest<Response<GetApiMethodAccessGrantsForPermissionGroupsResponseDto>>
    {
        public string PermissionGroupsName { get; set; }
        public string ApiMethodAccessGrantsPermissionGroupName { get; set; }

        public GetApiMethodAccessGrantsForPermissionGroupsDetailsQuery(string permissionGroupsName, string apiMethodAccessGrantsPermissionGroupName)
        {
            this.PermissionGroupsName = permissionGroupsName;
            this.ApiMethodAccessGrantsPermissionGroupName = apiMethodAccessGrantsPermissionGroupName;
        }

        public class GetApiMethodAccessGrantsForPermissionGroupsDetailsHandler : IRequestHandler<GetApiMethodAccessGrantsForPermissionGroupsDetailsQuery, Response<GetApiMethodAccessGrantsForPermissionGroupsResponseDto>>
        {
            private readonly ILogger<GetApiMethodAccessGrantsForPermissionGroupsDetailsHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetApiMethodAccessGrantsForPermissionGroupsDetailsHandler(ILogger<GetApiMethodAccessGrantsForPermissionGroupsDetailsHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetApiMethodAccessGrantsForPermissionGroupsResponseDto>> Handle(GetApiMethodAccessGrantsForPermissionGroupsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodAccessGrantsForPermissionGroupsDetailsAsync(request.PermissionGroupsName, request.ApiMethodAccessGrantsPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}