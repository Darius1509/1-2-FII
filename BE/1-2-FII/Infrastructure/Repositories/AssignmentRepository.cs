using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(_12FIIContext context) : base(context) { }

        public async Task<Result<IReadOnlyList<Assignment>>> FindByCourseIdAsync(Guid courseId)
        {
            var assignments = await context.Set<Assignment>()
                                           .Where(a => a.AssignmentCourseId == courseId)
                                           .ToListAsync();
            if (assignments == null || assignments.Count == 0)
            {
                return Result<IReadOnlyList<Assignment>>.Failure($"No assignments found for course ID {courseId}.");
            }
            return Result<IReadOnlyList<Assignment>>.Success(assignments);
        }
    }
}
