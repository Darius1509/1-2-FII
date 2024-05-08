using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, CreateAssignmentCommandResponse>
    {
        private readonly IAssignmentRepository repository;

        public CreateAssignmentCommandHandler(IAssignmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateAssignmentCommandResponse> Handle(CreateAssignmentCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateAssignmentCommandResponse();
            var validator = new CreateAssignmentCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var assignment = Assignment.Create(command.AssignmentQuestion, command.AssignmentCode, command.AssignmentCourseId, command.AssignmentProfessorId);
                if(assignment.IsSuccess)
                {
                    await repository.AddAsync(assignment.Value);
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
