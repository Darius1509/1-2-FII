using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Resources.Commands.CreateResource
{
    public class CreateResourceCommandResponse : BaseResponse
    {
        public CreateResourceCommandResponse() : base()
        {
            
        }
        public ResourceDto ResourceDto { get; set; }
    }
}
