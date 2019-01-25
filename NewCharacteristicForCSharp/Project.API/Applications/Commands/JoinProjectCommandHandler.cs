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
    public class JoinProjectCommandHandler : IRequestHandler<JoinProjectCommand>
    {
        private IProjectRepository _projectRepository;

        public JoinProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
       

        public async Task<Unit> Handle(JoinProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.Contributor.ProjectId);
            if (project == null)
            {
                throw new ProjectDomainException($"projectid not found : {request.Contributor.ProjectId}");
            }
            project.AddContributor(request.Contributor);
            await _projectRepository.UnitOfWork.SaveChangesAsync();
            return new Unit();
        }

     
    }
}
