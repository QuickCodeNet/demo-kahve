using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.PermissionGroup; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . PermissionGroup {
    public class DeletePermissionGroupCommand : IRequest<Response<bool>>
    {
        public PermissionGroupDto request { get; set; }

        public DeletePermissionGroupCommand(PermissionGroupDto request)
        {
            this.request = request;
        }

        public class DeletePermissionGroupHandler : IRequestHandler<DeletePermissionGroupCommand, Response<bool>>
        {
            private readonly ILogger<DeletePermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public DeletePermissionGroupHandler(ILogger<DeletePermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeletePermissionGroupCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}