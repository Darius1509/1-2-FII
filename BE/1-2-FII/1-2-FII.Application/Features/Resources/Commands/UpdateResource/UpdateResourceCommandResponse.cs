using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Resources.Commands.UpdateResource
{
    public class UpdateResourceCommandResponse : BaseResponse
    {
        public UpdateResourceCommandResponse() : base()
        {
            
        }
        public ResourceDto ResourceDto { get; set; }
    }
}
