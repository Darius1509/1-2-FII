using MediatR;

namespace _1_2_FII.Application.Features.Resources.Commands.DownloadResource
{
    public class DownloadResourceCommand : IRequest<DownloadResourceCommandResponse>
    {
        public Guid ResourceId { get; set; }
    }
}
