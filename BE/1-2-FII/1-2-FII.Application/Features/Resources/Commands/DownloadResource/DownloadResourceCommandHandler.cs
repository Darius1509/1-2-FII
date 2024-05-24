using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Resources.Commands.DownloadResource
{
    public class DownloadResourceCommandHandler : IRequestHandler<DownloadResourceCommand, DownloadResourceCommandResponse>
    {
        private readonly IResourceRepository repository;

        public DownloadResourceCommandHandler(IResourceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DownloadResourceCommandResponse> Handle(DownloadResourceCommand request, CancellationToken cancellationToken)
        {
            var resource = await repository.FindByIdAsync(request.ResourceId);
            if (resource.IsSuccess)
            {
                return new DownloadResourceCommandResponse
                {
                    ResourceFileContent = resource.Value.ResourceFileContent,
                    ResourceFileName = resource.Value.ResourceName,
                    ResourceContentType = "application/octet-stream"
                };
            }
            return new DownloadResourceCommandResponse();
        }
    }
}
