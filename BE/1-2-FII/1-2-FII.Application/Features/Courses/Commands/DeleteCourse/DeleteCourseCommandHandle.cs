using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandle : IRequestHandler<DeleteCourseCommand, DeleteCourseCommandResponse>
    {
        private readonly ICourseRepository repository;

        public DeleteCourseCommandHandle(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCourseCommandResponse> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
        {
            var response = new DeleteCourseCommandResponse();
            var course = await repository.DeleteAsync(command.CourseId);

            if(!course.IsSuccess)
            {
                response.Success = false;
                response.Message = "Deletion was unsuccessful";

                return response;
            }

            response.Success = true;
            response.CourseDto =  new CourseDto
            {
                CourseId = course.Value.CourseId,
                CourseName = course.Value.CourseName,
                CourseDescription = course.Value.CourseDescription,
                CourseNrOfCredits = course.Value.CourseNrOfCredits,
                CourseSemester = course.Value.CourseSemester
            };

            return response;
        }
    }
}
