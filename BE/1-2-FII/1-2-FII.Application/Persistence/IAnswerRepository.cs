using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;

namespace _1_2_FII.Application.Persistence
{
    public interface IAnswerRepository : IAsyncRepository<Answer>
    {
        public Task<Result<IReadOnlyList<Answer>>> FindAnswersByAnswerAssignmentId(Guid assignmentId);
    }
}
