using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Queries.GetAllAssignments
{
    public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, List<AssignmentDto>>
    {
        private readonly IAssignmentRepository repository;

        public GetAllAssignmentsQueryHandler(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<AssignmentDto>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var assignments = await repository.FindAllAsync();
            var listOfAssignments = new List<AssignmentDto>();

            foreach (var assignment in assignments.Value)
            {
                listOfAssignments.Add(new AssignmentDto
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
