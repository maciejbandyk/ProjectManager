using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Projects.Commands.CreateProject;
using ProjectManager.Application.Projects.Commands.DeleteProject;
using ProjectManager.Application.Projects.Commands.UpdateProject;
using ProjectManager.Application.Projects.Queries.DTO;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Projects.Queries.GetProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Controllers
{
    public class ProjectsController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects([FromQuery] GetProjectsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            return await Mediator.Send(new GetProjectQuery() { ProjectID = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProjectCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProjectCommand command)
        {
            if (id != command.ProjectID)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProjectCommand() { ProjectID = id });
            return NoContent();
        }


    }
}
