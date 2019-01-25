using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.AggregatesModel;
using ProjectEntity=Project.Domain.AggregatesModel.Project;
using Project.Domain.SeedWork;


namespace Project.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Domain.AggregatesModel.Project> AddAsync(ProjectEntity project)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEntity> UpdateAsync(ProjectEntity project)
        {
            throw new NotImplementedException();
        }
    }
}
