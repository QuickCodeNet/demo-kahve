using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.PermissionGroup; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . PermissionGroup {
    public class DeleteItemPermissionGroupCommand : IRequest<Response<bool>>
    {
        public string Name { get; set; }

        public DeleteItemPermissionGroupCommand(string name)
        {
            this.Name = name;
        }

        public class DeleteItemPermissionGroupHandler : IRequestHandler<DeleteItemPermissionGroupCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemPermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public DeleteItemPermissionGroupHandler(ILogger<DeleteItemPermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemPermissionGroupCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.Name);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}