using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQuery : IRequest<AssignmentDto>
    {
        public Guid AssignmentId { get; set; }

        public GetAssignmentByIdQuery(Guid assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}
