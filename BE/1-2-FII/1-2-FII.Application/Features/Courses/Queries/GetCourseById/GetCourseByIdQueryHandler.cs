using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
    {
        private readonly ICourseRepository repository;

        public GetCourseByIdQueryHandler(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CourseDto> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
        {
            var course = await repository.FindByIdAsync(query.CourseId);
            if(course.IsSuccess)
            {
                return new CourseDto
                {
                    CourseId = query.CourseId,
                    CourseName = course.Value.CourseName,
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
