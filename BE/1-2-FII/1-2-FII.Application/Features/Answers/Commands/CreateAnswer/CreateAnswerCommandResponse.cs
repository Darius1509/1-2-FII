using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandResponse : BaseResponse
    {
        public CreateAnswerCommandResponse() : base()
        {
            
        }
        public AnswerDto AnswerDto { get; set; }
    }
}
