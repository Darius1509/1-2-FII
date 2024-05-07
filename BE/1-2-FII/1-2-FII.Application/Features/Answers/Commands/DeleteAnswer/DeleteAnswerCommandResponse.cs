using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandResponse : BaseResponse
    {
        public DeleteAnswerCommandResponse() : base()
        {
            
        }

        public AnswerDto AnswerDto { get; set; }
    }
}
