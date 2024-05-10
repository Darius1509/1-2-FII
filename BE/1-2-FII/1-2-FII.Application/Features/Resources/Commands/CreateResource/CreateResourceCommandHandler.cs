using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Resources.Commands.CreateResource
{
    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, CreateResourceCommandResponse>
    {
        private readonly IResourceRepository repository;

        public CreateResourceCommandHandler(IResourceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateResourceCommandResponse> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateResourceCommandResponse();
            var validator = new CreateResourceCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(response.Success)
            {
                byte[] fileContents;
                using(var memoryStream = new MemoryStream())
                {
                    await request.ResourceFileContent.CopyToAsync(memoryStream);
                    fileContents = memoryStream.ToArray();
                }
                var resource = Resource.Create(request.ResourceName, request.ResourceDescription, request.ResourceType, request.ResourcePrerequisites, fileContents, request.ResourceCourseId);
                if(resource.IsSuccess)
                {
                    await repository.AddAsync(resource.Value);
                    response.ResourceDto = new ResourceDto
                    {
                        ResourceId = resource.Value.ResourceId,
                        ResourceName = resource.Value.ResourceName,
                        ResourceDescription = resource.Value.ResourceDescription,
                        ResourceType = resource.Value.ResourceType,
                        ResourcePrerequisites = resource.Value.ResourcePrerequisites,
                        ResourceCourseId = resource.Value.ResourceCourseId,
                        ResourceFileContent = resource.Value.ResourceFileContent
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>
                    {
                        resource.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
