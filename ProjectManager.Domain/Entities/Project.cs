using ProjectManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Domain.Entities
{
    public class Project : BaseEntity
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int TeamSize { get; set; }
    }
}
