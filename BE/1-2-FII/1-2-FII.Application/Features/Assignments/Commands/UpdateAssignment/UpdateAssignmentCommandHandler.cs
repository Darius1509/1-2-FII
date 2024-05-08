using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, UpdateAssignmentCommandResponse>
    {
        private readonly IAssignmentRepository repository;

        public UpdateAssignmentCommandHandler(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateAssignmentCommandResponse> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateAssignmentCommandResponse();
            var validator = new UpdateAssignmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(response.Success)
            {
                var assignment = Assignment.Update(request.AssignmentId, request.AssignmentQuestion, request.AssignmentCode, request.AssignmentCourseId, request.AssignmentProfessorId);
                if(assignment.IsSuccess)
                {
                    await repository.UpdateAsync(assignment.Value);
                    response.AssignmentDto = new AssignmentDto
                    {
                        AssignmentId = assignment.Value.AssignmentId,
                        AssignmentQuestion = assignment.Value.AssignmentQuestion,
                        AssignmentCode = assignment.Value.AssignmentCode,
                        AssignmentCourseId = assignment.Value.AssignmentCourseId,
                        AssignmentProfessorId = assignment.Value.AssignmentProfessorId
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>()
                    {
                        assignment.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
