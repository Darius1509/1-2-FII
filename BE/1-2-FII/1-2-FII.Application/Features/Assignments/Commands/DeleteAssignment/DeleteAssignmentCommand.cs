using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommand : IRequest<DeleteAssignmentCommandResponse>
    {
        public Guid AssignmentId { get; set; }

    }
}
