using MediatR;

namespace _1_2_FII.Application.Features.Answers.Queries.GetAnswerByAssignmentId
{
    public class GetAnswerByAssignmentIdQuery : IRequest<List<AnswerDto>>
    {
        public Guid AssignmentId { get; set; }
        public GetAnswerByAssignmentIdQuery(Guid assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}
