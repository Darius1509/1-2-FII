using FluentValidation;

namespace _1_2_FII.Application.Features.Resources.Commands.UpdateResource
{
    public class UpdateResourceCommandValidator : AbstractValidator<UpdateResourceCommand>
    {
        public UpdateResourceCommandValidator()
        {
            RuleFor(p => p.ResourceId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.ResourceCourseId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
