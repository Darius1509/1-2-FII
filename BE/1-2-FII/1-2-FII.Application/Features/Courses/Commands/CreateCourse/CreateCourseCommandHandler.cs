using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;
using MediatR;

namespace _1_2_FII.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseCommandResponse>
    {
        private readonly ICourseRepository repository;

        public CreateCourseCommandHandler(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateCourseCommandResponse();
            var validator = new CreateCourseCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(response.Success)
            {
                var course = Course.Create(command.CourseName, command.CourseDescription, command.CourseSemester, command.CourseNrOfCredits, command.CourseWebsite);
                if(course.IsSuccess)
                {
                    await repository.AddAsync(course.Value);
                    response.CourseDto = new CourseDto
                    {
                        CourseId = course.Value.CourseId,
                        CourseName = course.Value.CourseName,
                        CourseDescription = course.Value.CourseDescription,
                        CourseNrOfCredits = course.Value.CourseNrOfCredits,
                        CourseSemester = course.Value.CourseSemester
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>
                    {
                        course.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
