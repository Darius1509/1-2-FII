using MediatR;

namespace _1_2_FII.Application.Features.Resources.Queries.GetResourceByCourseId
{
    public class GetResourceByCourseIdQuery : IRequest<List<ResourceDto>>
    {
        public Guid CourseId { get; set; }

        public GetResourceByCourseIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
