using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;

namespace _1_2_FII.Application.Persistence
{
    public interface IAssignmentRepository : IAsyncRepository<Assignment>
    {
        public Task<Result<IReadOnlyList<Assignment>>> FindByCourseIdAsync(Guid courseId);
    }
}
