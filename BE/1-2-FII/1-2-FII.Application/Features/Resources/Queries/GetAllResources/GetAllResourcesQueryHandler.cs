using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Resources.Queries.GetAllResources
{
    public class GetAllResourcesQueryHandler : IRequestHandler<GetAllResourcesQuery, List<ResourceDto>>
    {
        private readonly IResourceRepository repository;

        public GetAllResourcesQueryHandler(IResourceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ResourceDto>> Handle(GetAllResourcesQuery query, CancellationToken cancellationToken)
        {
            var resources = await repository.FindAllAsync();
            var listOfResources = new List<ResourceDto>();
            foreach (var resource in resources.Value)
            {
                listOfResources.Add(
                    new ResourceDto
                    {
                        ResourceId = resource.ResourceId,
                        ResourceName = resource.ResourceName,
                        ResourceDescription = resource.ResourceDescription,
                        ResourceType = resource.ResourceType,
                        ResourcePrerequisites = resource.ResourcePrerequisites,
                        ResourceCourseId = resource.ResourceCourseId,
                        ResourceFileContent = resource.ResourceFileContent
                    });
            }

            return listOfResources;
        }
    }
}
