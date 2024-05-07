using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, DeleteAnswerCommandResponse>
    {
        private readonly IAnswerRepository repository;

        public DeleteAnswerCommandHandler(IAnswerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteAnswerCommandResponse();
            var answer = await repository.DeleteAsync(request.AnswerId);

            if(!answer.IsSuccess)
            {
                response.Success = false;
                response.Message = "Deletion was unsuccessful";
                
                return response;
            }

            response.Success = true;
            response.AnswerDto = new AnswerDto
            {
                AnswerId = answer.Value.AnswerId,
                AnswerStudentId = answer.Value.AnswerStudentId,
                AnswerAssignmentRespondedId = answer.Value.AnswerAssignmentRespondedId,
                AnswerContent = answer.Value.AnswerContent
            };

            return response;
        }
    }
}
