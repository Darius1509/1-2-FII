using MediatR;

namespace _1_2_FII.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<UpdateCourseCommandResponse>
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseSemester { get; set; }
        public int CourseNrOfCredits { get; set; }
        public string CourseWebsite { get; set; }
    }
}
