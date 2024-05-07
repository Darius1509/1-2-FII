using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_FII.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswerCommandValidator()
        {
            RuleFor(p => p.AnswerContent)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.AnswerStudentId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
            RuleFor(p => p.AnswerAssignmentRespondedId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
        }
    }
}
