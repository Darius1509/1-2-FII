namespace _1_2_FII.Application.Features.Resources
{
    public class ResourceDto
    {
        public Guid ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourceType { get; set; }
        public string ResourcePrerequisites { get; set; }
        public byte[] ResourceFileContent { get; set; }
        public Guid ResourceCourseId { get; set; }
    }
}
