using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace _1_2_FII.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreateAnswerCommandResponse>
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateAnswerCommandHandler(IAnswerRepository answerRepository, IAssignmentRepository assignmentRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.answerRepository = answerRepository;
            this.assignmentRepository = assignmentRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateAnswerCommandResponse();
            var validator = new CreateAnswerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userGuid = Guid.Parse(userId);

            var answer = Answer.Create(command.AnswerAssignmentRespondedId, userGuid, command.AnswerContent);
            if (!answer.IsSuccess)
            {
                response.Success = false;
                response.ValidationErrors = new List<string> { answer.ErrorMessage };
                return response;
            }

            await answerRepository.AddAsync(answer.Value);

            //Attach answer to assignment
            var assignment = await assignmentRepository.FindByIdAsync(command.AnswerAssignmentRespondedId);
            if (assignment == null)
            {
                response.Success = false;
                response.Message = "Related assignment not found.";
                return response;
            }

            var attachResult = Assignment.AttachAnswer(assignment, answer.Value.AnswerId);
            if (!attachResult.IsSuccess)
            {
                response.Success = false;
                response.Message = attachResult.ErrorMessage;
                return response;
            }

            await assignmentRepository.UpdateAsync(assignment.Value);

            response.AnswerDto = new AnswerDto
            {
                AnswerId = answer.Value.AnswerId,
                AnswerStudentId = answer.Value.AnswerStudentId,
                AnswerAssignmentRespondedId = answer.Value.AnswerAssignmentRespondedId,
                AnswerContent = answer.Value.AnswerContent
            };
            response.Success = true;
            return response;
        }

    }
}
