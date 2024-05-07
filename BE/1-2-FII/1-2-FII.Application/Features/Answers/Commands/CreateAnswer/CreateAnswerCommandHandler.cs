using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreateAnswerCommandResponse>
    {
        private readonly IAnswerRepository repository;

        public CreateAnswerCommandHandler(IAnswerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateAnswerCommandResponse();
            var validator = new CreateAnswerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(response.Success)
            {
                var answer = Answer.Create(command.AnswerStudentId, command.AnswerAssignmentRespondedId, command.AnswerContent);
                if(answer.IsSuccess)
                {
                    await repository.AddAsync(answer.Value);
                    response.AnswerDto = new AnswerDto
                    {
                        AnswerId = answer.Value.AnswerId,
                        AnswerStudentId = answer.Value.AnswerStudentId,
                        AnswerAssignmentRespondedId = answer.Value.AnswerAssignmentRespondedId,
                        AnswerContent = answer.Value.AnswerContent
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>
                    {
                        answer.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
