using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, UpdateAnswerCommandRepsonse>
    {
        private readonly IAnswerRepository repository;

        public UpdateAnswerCommandHandler(IAnswerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateAnswerCommandRepsonse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateAnswerCommandRepsonse();
            var validator = new UpdateAnswerCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var answer = Answer.Update(request.AnswerId, request.AnswerStudentId, request.AnswerAssignmentRespondedId, request.AnswerContent);
                if(answer.IsSuccess)
                {
                    await repository.UpdateAsync(answer.Value);
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
