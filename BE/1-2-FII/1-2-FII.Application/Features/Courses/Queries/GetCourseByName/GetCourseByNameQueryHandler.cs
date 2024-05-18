using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Courses.Queries.GetCourseByName
{
    public class GetCourseByNameQueryHandler : IRequestHandler<GetCourseByNameQuery, CourseDto>
    {
        private readonly ICourseRepository repository;

        public GetCourseByNameQueryHandler(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CourseDto> Handle(GetCourseByNameQuery query, CancellationToken cancellationToken)
        {
            var course = await repository.FindByNameAsync(query.CourseName);
            if(course.IsSuccess)
            {
                return new CourseDto
                {
                    CourseId = course.Value.CourseId,
                    CourseName = query.CourseName,
                    CourseDescription = course.Value.CourseDescription,
                    CourseNrOfCredits = course.Value.CourseNrOfCredits,
                    CourseSemester = course.Value.CourseSemester,
                    CourseWebsite = course.Value.CourseWebsite
                };
            }
            return new CourseDto();
        }
    }
}
