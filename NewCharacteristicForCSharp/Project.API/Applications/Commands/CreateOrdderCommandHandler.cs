using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Domain.AggregatesModel;

namespace Project.API.Applications.Commands
{
    public class CreateOrdderCommandHandler : IRequestHandler<CreateOrdderCommand, Project.Domain.AggregatesModel.Project>
    {
        private IProjectRepository _projectRepository;

        public CreateOrdderCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Domain.AggregatesModel.Project> Handle(CreateOrdderCommand request, CancellationToken cancellationToken)
        {
            //检查
            await _projectRepository.AddAsync(request.Project);
            await _projectRepository.UnitOfWork.SaveChangesAsync();
            return request.Project;
        }
    }
}
