using MediatR;

namespace _1_2_FII.Application.Features.Courses.Queries.GetCourseByName
{
    public class GetCourseByNameQuery : IRequest<CourseDto>
    {
        public string CourseName { get; set; }
        public GetCourseByNameQuery(string courseName)
        {
            CourseName = courseName;
        }
    }
}
