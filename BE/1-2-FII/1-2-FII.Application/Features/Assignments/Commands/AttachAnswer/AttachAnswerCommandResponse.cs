using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Assignments.Commands.AttachAnswer
{
    public class AttachAnswerCommandResponse : BaseResponse
    {
        public AttachAnswerCommandResponse() : base()
        {
        }

        public AssignmentDto AssignmentDto { get; set; }
    }
}
