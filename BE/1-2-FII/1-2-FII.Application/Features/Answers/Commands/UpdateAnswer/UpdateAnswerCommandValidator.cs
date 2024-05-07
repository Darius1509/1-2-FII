using FluentValidation;

namespace _1_2_FII.Application.Features.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandValidator : AbstractValidator<UpdateAnswerCommand>
    {
        public UpdateAnswerCommandValidator()
        {
            RuleFor(p => p.AnswerId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.AnswerStudentId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.AnswerAssignmentRespondedId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.AnswerContent)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                .NotNull();
        }
    }
}
