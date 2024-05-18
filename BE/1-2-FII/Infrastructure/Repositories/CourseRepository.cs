using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(_12FIIContext context) : base(context) { }

        public async Task<Result<Course>> FindByNameAsync(string courseName)
        {
            var course = await context.Set<Course>().FirstOrDefaultAsync(c => c.CourseName == courseName);
            if (course == null)
            {
                return Result<Course>.Failure($"Course with name {courseName} not found.");
            }
            return Result<Course>.Success(course);
        }
    }
}
