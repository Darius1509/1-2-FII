using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(_12FIIContext context) : base(context) { }

        public async Task<Result<IReadOnlyList<Answer>>> FindAnswersByAnswerAssignmentId(Guid assignmentId)
        {
                var answers = await context.Set<Answer>()
                                           .Where(a => a.AnswerAssignmentRespondedId == assignmentId)
                                           .ToListAsync();
                if (answers == null || answers.Count == 0)
                {
                    return Result<IReadOnlyList<Answer>>.Failure($"No answers found for assignment ID {assignmentId}.");
                }
                return Result<IReadOnlyList<Answer>>.Success(answers);
        }
    }
}
