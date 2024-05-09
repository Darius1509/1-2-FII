using MediatR;

namespace _1_2_FII.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<CourseDto>
    {
        public Guid CourseId { get; set; }
        
        public GetCourseByIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
