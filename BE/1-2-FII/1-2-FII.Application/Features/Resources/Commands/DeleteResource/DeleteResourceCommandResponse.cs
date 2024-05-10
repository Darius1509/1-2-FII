using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Resources.Commands.DeleteResource
{
    public class DeleteResourceCommandResponse : BaseResponse
    {
        public DeleteResourceCommandResponse() : base()
        {
            
        }

        public ResourceDto ResourceDto { get; set; }
    }
}
