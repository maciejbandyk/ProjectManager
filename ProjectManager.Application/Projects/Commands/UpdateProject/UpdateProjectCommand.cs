using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int TeamSize { get; set; }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private IApplicationDbContext _context { get; set; }
        public UpdateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.ProjectID);
            if(entity == null)
            {
                throw new Exception($"Entity {nameof(Project)}, {request.ProjectID} not found");
            }

            entity.ProjectName = request.ProjectName;
            entity.DateOfStart = request.DateOfStart;
            entity.TeamSize = request.TeamSize;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
