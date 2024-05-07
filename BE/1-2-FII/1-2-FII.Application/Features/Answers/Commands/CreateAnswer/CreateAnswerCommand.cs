using MediatR;

namespace _1_2_FII.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommand : IRequest<CreateAnswerCommandResponse>
    {
        public Guid AnswerId { get; set; }
        public Guid AnswerStudentId { get; set; }
        public Guid AnswerAssignmentRespondedId { get; set; }
        public string AnswerContent { get; set; }
    }
}