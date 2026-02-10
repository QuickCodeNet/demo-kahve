using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.AspNetUser; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . AspNetUser {
    public class GetItemAspNetUserQuery : IRequest<Response<AspNetUserDto>>
    {
        public string Id { get; set; }

        public GetItemAspNetUserQuery(string id)
        {
            this.Id = id;
        }

        public class GetItemAspNetUserHandler : IRequestHandler<GetItemAspNetUserQuery, Response<AspNetUserDto>>
        {
            private readonly ILogger<GetItemAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetItemAspNetUserHandler(ILogger<GetItemAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserDto>> Handle(GetItemAspNetUserQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}