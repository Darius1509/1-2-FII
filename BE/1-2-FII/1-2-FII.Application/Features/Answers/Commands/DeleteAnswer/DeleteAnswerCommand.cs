using MediatR;

namespace _1_2_FII.Application.Features.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommand : IRequest<DeleteAnswerCommandResponse>
    {
        public Guid AnswerId { get; set; }
    }
}
