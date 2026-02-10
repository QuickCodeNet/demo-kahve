using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.RefreshToken; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . RefreshToken {
    public class UpdateRefreshTokensCommand : IRequest<Response<int>>
    {
        public string RefreshTokensToken { get; set; }
        public UpdateRefreshTokensRequestDto UpdateRequest { get; set; }

        public UpdateRefreshTokensCommand(string refreshTokensToken, UpdateRefreshTokensRequestDto updateRequest)
        {
            this.RefreshTokensToken = refreshTokensToken;
            this.UpdateRequest = updateRequest;
        }

        public class UpdateRefreshTokensHandler : IRequestHandler<UpdateRefreshTokensCommand, Response<int>>
        {
            private readonly ILogger<UpdateRefreshTokensHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public UpdateRefreshTokensHandler(ILogger<UpdateRefreshTokensHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(UpdateRefreshTokensCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.UpdateRefreshTokensAsync(request.RefreshTokensToken, request.UpdateRequest);
                return returnValue.ToResponse();
            }
        }
    }
}