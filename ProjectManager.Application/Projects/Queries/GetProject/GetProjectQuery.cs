using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.DTO;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Projects.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectDto>
    {
        public int ProjectID { get; set; }
    }

    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetProjectQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.ProjectID);
            if(entity == null)
            {
                throw new Exception($"Entity {typeof(Project)}, {request.ProjectID} not found.");
            }

            return _mapper.Map<ProjectDto>(entity);

        }
    }
}
