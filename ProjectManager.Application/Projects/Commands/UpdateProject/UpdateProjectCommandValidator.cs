using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(prop => prop.TeamSize)
                .NotEmpty()
                .LessThan(int.MaxValue)
                .GreaterThan(0);
        }
    }
}
