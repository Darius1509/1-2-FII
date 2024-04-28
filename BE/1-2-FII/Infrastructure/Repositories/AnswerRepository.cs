using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(_12FIIContext context) : base(context) { }
    }
}
