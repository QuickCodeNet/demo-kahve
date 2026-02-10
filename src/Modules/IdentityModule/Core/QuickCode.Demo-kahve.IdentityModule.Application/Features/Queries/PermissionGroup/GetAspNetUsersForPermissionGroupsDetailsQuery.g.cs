using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.PermissionGroup; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . PermissionGroup {
    public class GetAspNetUsersForPermissionGroupsDetailsQuery : IRequest<Response<GetAspNetUsersForPermissionGroupsResponseDto>>
    {
        public string PermissionGroupsName { get; set; }
        public string AspNetUsersId { get; set; }

        public GetAspNetUsersForPermissionGroupsDetailsQuery(string permissionGroupsName, string aspNetUsersId)
        {
            this.PermissionGroupsName = permissionGroupsName;
            this.AspNetUsersId = aspNetUsersId;
        }

        public class GetAspNetUsersForPermissionGroupsDetailsHandler : IRequestHandler<GetAspNetUsersForPermissionGroupsDetailsQuery, Response<GetAspNetUsersForPermissionGroupsResponseDto>>
        {
            private readonly ILogger<GetAspNetUsersForPermissionGroupsDetailsHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetAspNetUsersForPermissionGroupsDetailsHandler(ILogger<GetAspNetUsersForPermissionGroupsDetailsHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUsersForPermissionGroupsResponseDto>> Handle(GetAspNetUsersForPermissionGroupsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUsersForPermissionGroupsDetailsAsync(request.PermissionGroupsName, request.AspNetUsersId);
                return returnValue.ToResponse();
            }
        }
    }
}