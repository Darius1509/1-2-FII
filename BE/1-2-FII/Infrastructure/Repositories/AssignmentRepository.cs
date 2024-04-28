using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(_12FIIContext context) : base(context) { }
    }
}
