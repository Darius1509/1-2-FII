using _1_2_FII.Domain.Common;

namespace _1_2_FII.Domain.Entities
{
    public class Resource
    {
        public Resource(string resourceName, string resourceDescription, string resourceType, string resourcePrerequisites, byte[] resourceFileContent, Guid resourceCourseId)
        {
            ResourceId = Guid.NewGuid();
            ResourceName = resourceName;
            ResourceDescription = resourceDescription;
            ResourceType = resourceType;
            ResourcePrerequisites = resourcePrerequisites;
            ResourceFileContent = resourceFileContent;
            ResourceCourseId = resourceCourseId;
        }

        public Guid ResourceId { get; private set; }
        public string ResourceName { get; private set; }
        public string ResourceDescription { get; private set; }
        public string ResourceType { get; private set; }
        public string ResourcePrerequisites { get; private set; }
        public byte[] ResourceFileContent { get; private set; }
        public Guid ResourceCourseId { get; private set; }

        public static Result<Resource> Create(string resourceName, string resourceDescription, string resourceType, string resourcePrerequisites, byte[] resourceFileContent, Guid resourceCourseId)
        {
            var validation = ValidateParameters(resourceName, resourceDescription, resourceType, resourcePrerequisites, resourceFileContent, resourceCourseId);
            if (validation != null)
            {
                return validation;
            }
            return Result<Resource>.Success(new Resource(resourceName, resourceDescription, resourceType, resourcePrerequisites, resourceFileContent, resourceCourseId));
        }

        public static Result<Resource> Update(Guid resourceId, string resourceName, string resourceDescription, string resourceType, string resourcePrerequisites, byte[] resourceFileContent, Guid resourceCourseId)
        {
            var validation = ValidateParameters(resourceName, resourceDescription, resourceType, resourcePrerequisites, resourceFileContent, resourceCourseId);
            if (validation != null)
            {
                return validation;
            }
            var resource = new Resource(resourceName, resourceDescription, resourceType, resourcePrerequisites, resourceFileContent, resourceCourseId)
            {
                ResourceId = resourceId
            };
            return Result<Resource>.Success(resource);
        }

        private static Result<Resource>? ValidateParameters(string resourceName, string resourceDescription, string resourceType, string resourcePrerequisites, byte[] resourceFileContent, Guid resourceCourseId)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                return Result<Resource>.Failure("Resource name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(resourceDescription))
            {
                return Result<Resource>.Failure("Resource description cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(resourceType))
            {
                return Result<Resource>.Failure("Resource type cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(resourcePrerequisites))
            {
                return Result<Resource>.Failure("Resource prerequisites cannot be empty");
            }
            if (resourceFileContent.Length == 0)
            {
                return Result<Resource>.Failure("Resource file content cannot be empty");
            }
            if (resourceCourseId == Guid.Empty)
            {
                return Result<Resource>.Failure("Resource course id cannot be empty");
            }
            return null;
        }
    }
}
