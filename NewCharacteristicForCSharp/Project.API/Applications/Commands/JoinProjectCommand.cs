using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.CodeAnalysis;

namespace Project.API.Applications.Commands
{
    public class JoinProjectCommand: IRequest
    {
        public Domain.AggregatesModel.ProjectContributors Contributor { get; set; }
    }
}
