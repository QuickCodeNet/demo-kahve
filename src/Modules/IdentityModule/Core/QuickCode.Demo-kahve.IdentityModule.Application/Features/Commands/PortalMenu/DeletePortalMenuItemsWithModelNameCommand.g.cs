using System;
using System.Linq;
using QuickCode.Demo-kahve.Common.Mediator; using  Microsoft . Extensions . Logging ;  using  System . Threading ;  using  System . Threading . Tasks ;  using  System . Collections . Generic ;  using  QuickCode . Demo
-kahve.Common.Models; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Entities; using  QuickCode . Demo
-kahve.IdentityModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.IdentityModule.Application.Dtos.PortalMenu; using  QuickCode . Demo
-kahve.IdentityModule.Domain.Enums;
namespace QuickCode.Demo - kahve . IdentityModule . Application . Features . PortalMenu {
    public class DeletePortalMenuItemsWithModelNameCommand : IRequest<Response<int>>
    {
        public string PortalMenusKey { get; set; }
        public string PortalMenusName { get; set; }

        public DeletePortalMenuItemsWithModelNameCommand(string portalMenusKey, string portalMenusName)
        {
            this.PortalMenusKey = portalMenusKey;
            this.PortalMenusName = portalMenusName;
        }

        public class DeletePortalMenuItemsWithModelNameHandler : IRequestHandler<DeletePortalMenuItemsWithModelNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalMenuItemsWithModelNameHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public DeletePortalMenuItemsWithModelNameHandler(ILogger<DeletePortalMenuItemsWithModelNameHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalMenuItemsWithModelNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalMenuItemsWithModelNameAsync(request.PortalMenusKey, request.PortalMenusName);
                return returnValue.ToResponse();
            }
        }
    }
}