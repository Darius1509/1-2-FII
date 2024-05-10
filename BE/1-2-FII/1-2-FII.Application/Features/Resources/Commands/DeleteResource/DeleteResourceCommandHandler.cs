using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Resources.Commands.DeleteResource
{
    public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommand, DeleteResourceCommandResponse>
    {
        private readonly IResourceRepository repository;

        public DeleteResourceCommandHandler(IResourceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteResourceCommandResponse> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteResourceCommandResponse();
            var resource = await repository.DeleteAsync(request.ResourceId);

            if(!resource.IsSuccess)
            {
                response.Message = "Deletion was unsuccsessful.";
                response.Success = false;
                return response;
            }

            response.Success = true;
            response.ResourceDto = new ResourceDto
            {
                ResourceId = resource.Value.ResourceId,
                ResourceName = resource.Value.ResourceName,
                ResourceDescription = resource.Value.ResourceDescription,
                ResourcePrerequisites = resource.Value.ResourcePrerequisites,
                ResourceType = resource.Value.ResourceType,
                ResourceCourseId = resource.Value.ResourceCourseId,
                ResourceFileContent = resource.Value.ResourceFileContent
            };

            return response;

        }
    }
}
