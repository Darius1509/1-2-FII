using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Resources.Queries.GetResourceById
{
    public class GetResourceByIdQueryHandler : IRequestHandler<GetResourceByIdQuery, ResourceDto>
    {
        private readonly IResourceRepository repository;

        public GetResourceByIdQueryHandler(IResourceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResourceDto> Handle(GetResourceByIdQuery request, CancellationToken cancellationToken)
        {
            var resource = await repository.FindByIdAsync(request.ResourceId);
            if (resource.IsSuccess)
            {
                return new ResourceDto
                {
                    ResourceId = resource.Value.ResourceId,
                    ResourceName = resource.Value.ResourceName,
                    ResourceDescription = resource.Value.ResourceDescription,
                    ResourceType = resource.Value.ResourceType,
                    ResourcePrerequisites = resource.Value.ResourcePrerequisites,
                    ResourceFileContent = resource.Value.ResourceFileContent,
                    ResourceCourseId = resource.Value.ResourceCourseId
                };
            }

            return new ResourceDto();
        }
    }
}
