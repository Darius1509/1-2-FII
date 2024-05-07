using MediatR;

namespace _1_2_FII.Application.Features.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommand : IRequest<UpdateAnswerCommandRepsonse>
    {
        public Guid AnswerId { get; set; }
        public Guid AnswerStudentId { get; set; }
        public Guid AnswerAssignmentRespondedId { get; set; }
        public string AnswerContent { get; set; }
    }
}
