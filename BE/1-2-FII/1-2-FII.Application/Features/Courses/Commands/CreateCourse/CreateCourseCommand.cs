using MediatR;

namespace _1_2_FII.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<CreateCourseCommandResponse>
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseSemester { get; set; }
        public int CourseNrOfCredits { get; set; }
        public string CourseWebsite { get; set; }
    }
}
