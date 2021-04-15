using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Project> Projects { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
