using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandResponse : BaseResponse
    {
        public CreateCourseCommandResponse() : base()
        {
            
        }

        public CourseDto CourseDto { get; set; }
    }
}
