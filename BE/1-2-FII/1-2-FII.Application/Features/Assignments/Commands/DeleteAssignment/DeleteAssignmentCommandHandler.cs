using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, DeleteAssignmentCommandResponse>
    {
        private readonly IAssignmentRepository repository;

        public DeleteAssignmentCommandHandler(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteAssignmentCommandResponse> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteAssignmentCommandResponse();
            var assignment = await repository.DeleteAsync(request.AssignmentId);
            if (!assignment.IsSuccess)
            {
                response.Success = false;
                response.Message = "Deletion was unsuccessful.";

                return response;
            }
            response.Success = true;
            response.AssignmentDto = new AssignmentDto
            {
                AssignmentId = assignment.Value.AssignmentId,
                AssignmentQuestion = assignment.Value.AssignmentQuestion,
                AssignmentCode = assignment.Value.AssignmentCode,
                AssignmentCourseId = assignment.Value.AssignmentCourseId,
                AssignmentProfessorId = assignment.Value.AssignmentProfessorId
            };

            return response;
        }
    }
}
