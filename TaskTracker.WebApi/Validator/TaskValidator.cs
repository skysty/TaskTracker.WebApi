using FluentValidation;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Validator
{
    public class TaskValidator: AbstractValidator<TaskModel>
    {
        public TaskValidator()
        {
            RuleFor(t=>t.TaskName).NotEmpty().MinimumLength(5).MaximumLength(250).WithMessage("Please write Task name");
            RuleFor(t => t.Priority).NotNull().NotEqual(0).LessThan(4).WithMessage("in Priority field must be written 1 and 3 not write 0 and greater than 3");
        }
    }
}
