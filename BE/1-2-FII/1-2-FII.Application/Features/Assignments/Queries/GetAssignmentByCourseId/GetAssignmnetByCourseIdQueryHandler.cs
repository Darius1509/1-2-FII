using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Queries.GetAssignmentByCourseId
{
    public class GetAssignmnetByCourseIdQueryHandler : IRequestHandler<GetAssignmentByCourseIdQuery, List<AssignmentDto>>
    {
        private readonly IAssignmentRepository repository;

        public GetAssignmnetByCourseIdQueryHandler(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<AssignmentDto>> Handle(GetAssignmentByCourseIdQuery query, CancellationToken cancellationToken)
        {
            var assignments = await repository.FindByCourseIdAsync(query.CourseId);
            var listOfAssignments = new List<AssignmentDto>();
            foreach (var assignment in assignments.Value)
            {
                listOfAssignments.Add(
                    new AssignmentDto
                    {
                        AssignmentId = assignment.AssignmentId,
                        AssignmentQuestion = assignment.AssignmentQuestion,
                        AssignmentCode = assignment.AssignmentCode,
                        AssignmentCourseId = assignment.AssignmentCourseId,
                        AssignmentProfessorId = assignment.AssignmentProfessorId,
                        AssignmentAnswersId = assignment.AssignmentAnswersId

                    });
            }
            return listOfAssignments;
        }
    }
}
