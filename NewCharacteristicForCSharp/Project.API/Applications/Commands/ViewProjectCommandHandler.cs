using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Domain.AggregatesModel;
using Project.Domain.Exceptions;

namespace Project.API.Applications.Commands
{
    public class ViewProjectCommandHandler : IRequestHandler<ViewProjectCommand>
    {
        private IProjectRepository _projectRepository;

        public ViewProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(ViewProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.ProjectId);
            if (project == null)
            {
                throw new ProjectDomainException($"projectid not found : {request.ProjectId}");
            }
            project.AddvViewer(request.UserID, request.Avatar, request.Avatar);
            await _projectRepository.UnitOfWork.SaveChangesAsync();
            return new Unit();

        }
    }
}
