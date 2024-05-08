using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Commands.AttachAnswer
{
    public class AttachAnswerCommand : IRequest<AttachAnswerCommandResponse>
    {
        public Guid AssignmentId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
