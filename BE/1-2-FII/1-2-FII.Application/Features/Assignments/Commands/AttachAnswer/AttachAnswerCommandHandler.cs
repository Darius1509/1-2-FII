using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace _1_2_FII.Application.Features.Assignments.Commands.AttachAnswer
{
    public class AttachAnswerCommandHandler : IRequestHandler<AttachAnswerCommand, AttachAnswerCommandResponse>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AttachAnswerCommandHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<AttachAnswerCommandResponse> Handle(AttachAnswerCommand command, CancellationToken cancellationToken)
        {
            var response = new AttachAnswerCommandResponse();
            var assignment = await _assignmentRepository.FindByIdAsync(command.AssignmentId);
            if (assignment == null)
            {
                response.Success = false;
                response.Message = "Assignment not found.";
                return response;
            }

            var result = Assignment.AttachAnswer(assignment, command.AnswerId);
            if(!result.IsSuccess)
            {
                response.Success = false;
                response.Message = result.ErrorMessage;
                return response;
            }

            await _assignmentRepository.UpdateAsync(assignment.Value);
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
