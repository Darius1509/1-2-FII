using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ResourceRepository : BaseRepository<Resource>, IResourceRepository
    {
        public ResourceRepository(_12FIIContext context) : base(context) { }

        public async Task<Result<IReadOnlyList<Resource>>> FindByCourseIdAsync(Guid courseId)
        {
            var resources = await context.Set<Resource>()
                                         .Where(r => r.ResourceCourseId == courseId)
                                         .ToListAsync();
            if (resources == null || resources.Count == 0)
            {
                return Result<IReadOnlyList<Resource>>.Failure($"No resources found for course ID {courseId}.");
            }
            return Result<IReadOnlyList<Resource>>.Success(resources);
        }
    }
}
