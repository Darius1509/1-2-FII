using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandResponse : BaseResponse
    {
        public DeleteCourseCommandResponse() : base()
        {
            
        }

        public CourseDto CourseDto { get; set; }
    }
}
