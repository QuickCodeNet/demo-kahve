using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.AspNetUser; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . AspNetUser {
    public class GetAspNetUserRolesForAspNetUsersDetailsQuery : IRequest<Response<GetAspNetUserRolesForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public string AspNetUserRolesUserId { get; set; }

        public GetAspNetUserRolesForAspNetUsersDetailsQuery(string aspNetUsersId, string aspNetUserRolesUserId)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.AspNetUserRolesUserId = aspNetUserRolesUserId;
        }

        public class GetAspNetUserRolesForAspNetUsersDetailsHandler : IRequestHandler<GetAspNetUserRolesForAspNetUsersDetailsQuery, Response<GetAspNetUserRolesForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetAspNetUserRolesForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserRolesForAspNetUsersDetailsHandler(ILogger<GetAspNetUserRolesForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUserRolesForAspNetUsersResponseDto>> Handle(GetAspNetUserRolesForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserRolesForAspNetUsersDetailsAsync(request.AspNetUsersId, request.AspNetUserRolesUserId);
                return returnValue.ToResponse();
            }
        }
    }
}