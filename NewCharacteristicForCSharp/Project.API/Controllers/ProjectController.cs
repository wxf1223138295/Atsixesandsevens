using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.API.Applications.Commands;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        [Route("view/{projectId}")]
        public async Task<IActionResult> ViewProject(int projectId)
        {
            var command = new ViewProjectCommand() {ProjectId = projectId, UserName = "", UserID = 0, Avatar = ""};
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("view/{projectId}")]
        public async Task<IActionResult> CreateProject(Project.Domain.AggregatesModel.Project project)
        {
            var command = new CreateOrdderCommand() {Project = project};
            var res = await _mediator.Send(command);
            return Ok(res);

        }
        [HttpPut]
        [Route("join/{projectId}")]
        public Task<IActionResult> JoinProject(int projectId)
        {

        }
    }
}