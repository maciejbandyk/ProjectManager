using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Application.Projects.DTO
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int TeamSize { get; set; }
    }
}
