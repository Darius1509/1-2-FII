using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseRepository repository;

        public GetAllCoursesQueryHandler(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<CourseDto>> Handle(GetAllCoursesQuery query, CancellationToken cancellationToken)
        {
            var courses = await repository.FindAllAsync();
            var listOfCourses = new List<CourseDto>();

            foreach (var course in courses.Value)
            {
                listOfCourses.Add(new CourseDto
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription,
                    CourseNrOfCredits = course.CourseNrOfCredits,
                    CourseSemester = course.CourseSemester
                });
            }

            return listOfCourses;
        }
    }
}
