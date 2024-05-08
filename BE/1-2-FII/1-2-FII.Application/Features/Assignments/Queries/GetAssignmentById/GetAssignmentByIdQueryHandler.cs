using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQueryHandler : IRequestHandler<GetAssignmentByIdQuery, AssignmentDto>
    {
        private readonly IAssignmentRepository repository;

        public GetAssignmentByIdQueryHandler(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AssignmentDto> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var assignment = await repository.FindByIdAsync(request.AssignmentId);
            if (assignment.IsSuccess)
            {
                return new AssignmentDto
                {
                    AssignmentId = assignment.Value.AssignmentId,
                    AssignmentQuestion = assignment.Value.AssignmentQuestion,
                    AssignmentCode = assignment.Value.AssignmentCode,
                    AssignmentCourseId = assignment.Value.AssignmentCourseId,
                    AssignmentProfessorId = assignment.Value.AssignmentProfessorId,
                    AssignmentAnswersId = assignment.Value.AssignmentAnswersId

                };
            }
            return new AssignmentDto();
        }
    }
}
