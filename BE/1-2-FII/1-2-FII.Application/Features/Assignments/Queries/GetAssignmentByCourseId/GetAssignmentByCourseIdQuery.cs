using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Queries.GetAssignmentByCourseId
{
    public class GetAssignmentByCourseIdQuery : IRequest<List<AssignmentDto>>
    {
        public Guid CourseId { get; set; }

        public GetAssignmentByCourseIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
