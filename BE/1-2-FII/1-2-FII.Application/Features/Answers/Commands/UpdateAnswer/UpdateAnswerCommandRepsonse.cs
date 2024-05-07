using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandRepsonse : BaseResponse
    {
        public UpdateAnswerCommandRepsonse() : base()
        {
            
        }

        public AnswerDto AnswerDto { get; set; }
    }
}