using MediatR;

namespace _1_2_FII.Application.Features.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<DeleteCourseCommandResponse>
    {
        public Guid CourseId { get; set; }
    }
}
