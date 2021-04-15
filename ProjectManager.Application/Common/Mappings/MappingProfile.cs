using AutoMapper;
using ProjectManager.Application.Projects.DTO;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>();
        }
    }
}
