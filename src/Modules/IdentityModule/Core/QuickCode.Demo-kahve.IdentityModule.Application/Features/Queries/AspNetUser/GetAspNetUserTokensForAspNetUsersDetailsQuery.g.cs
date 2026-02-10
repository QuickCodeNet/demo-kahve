using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.AspNetUser; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . AspNetUser {
    public class GetAspNetUserTokensForAspNetUsersDetailsQuery : IRequest<Response<GetAspNetUserTokensForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public string AspNetUserTokensUserId { get; set; }

        public GetAspNetUserTokensForAspNetUsersDetailsQuery(string aspNetUsersId, string aspNetUserTokensUserId)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.AspNetUserTokensUserId = aspNetUserTokensUserId;
        }

        public class GetAspNetUserTokensForAspNetUsersDetailsHandler : IRequestHandler<GetAspNetUserTokensForAspNetUsersDetailsQuery, Response<GetAspNetUserTokensForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetAspNetUserTokensForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserTokensForAspNetUsersDetailsHandler(ILogger<GetAspNetUserTokensForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUserTokensForAspNetUsersResponseDto>> Handle(GetAspNetUserTokensForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserTokensForAspNetUsersDetailsAsync(request.AspNetUsersId, request.AspNetUserTokensUserId);
                return returnValue.ToResponse();
            }
        }
    }
}