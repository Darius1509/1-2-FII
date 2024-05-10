using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Resources.Commands.UpdateResource
{
    public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand, UpdateResourceCommandResponse>
    {
        private readonly IResourceRepository repository;

        public UpdateResourceCommandHandler(IResourceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateResourceCommandResponse> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateResourceCommandResponse();
            var validator = new UpdateResourceCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
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
                using (var memoryStream = new MemoryStream())
                {
                    await request.ResourceFileContent.CopyToAsync(memoryStream);
                    fileContents = memoryStream.ToArray();
                }
                var resource = Resource.Update(request.ResourceId, request.ResourceName, request.ResourceDescription, request.ResourceType, request.ResourcePrerequisites, fileContents, request.ResourceCourseId);
                if(resource.IsSuccess)
                {
                    await repository.UpdateAsync(resource.Value);
                    response.ResourceDto = new ResourceDto
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
