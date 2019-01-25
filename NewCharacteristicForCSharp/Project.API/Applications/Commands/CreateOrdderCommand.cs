using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Project.API.Applications.Commands
{
    public class CreateOrdderCommand: IRequest<Domain.AggregatesModel.Project>
    {
        //复杂之后用 viewmodel 映射 领域模型
        //现在直接传领域模型
        public Domain.AggregatesModel.Project Project { get; set; }
    }
}
