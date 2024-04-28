using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class ResourceRepository : BaseRepository<Resource>, IResourceRepository
    {
        public ResourceRepository(_12FIIContext context) : base(context) { }
    }
}
