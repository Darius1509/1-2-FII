using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(_12FIIContext context) : base(context) { }
    }
}
