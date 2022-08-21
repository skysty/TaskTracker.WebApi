using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Validator
{
    public class ProjectValidator :AbstractValidator<ProjectModel>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.ProjectName).NotNull().MinimumLength(5).MaximumLength(250).WithMessage("Please write project name");
            RuleFor(p => p.Priority).NotNull().NotEqual(0).LessThan(4).WithMessage("in Priority field must be written 1 and 3 not write 0 and greater than 3");
        }
    }
}
