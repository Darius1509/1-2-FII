using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandResponse : BaseResponse
    {
        public UpdateCourseCommandResponse() : base()
        {
            
        }
        public CourseDto CourseDto { get; set; }
    }
}
