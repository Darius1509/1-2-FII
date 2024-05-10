using MediatR;

namespace _1_2_FII.Application.Features.Resources.Commands.DeleteResource
{
    public class DeleteResourceCommand : IRequest<DeleteResourceCommandResponse>
    {
        public Guid ResourceId { get; set; }
    }
}
