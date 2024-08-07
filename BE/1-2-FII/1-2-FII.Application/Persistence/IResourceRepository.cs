﻿using _1_2_FII.Domain.Common;
using _1_2_FII.Domain.Entities;

namespace _1_2_FII.Application.Persistence
{
    public interface IResourceRepository : IAsyncRepository<Resource>
    {
        Task<Result<IReadOnlyList<Resource>>> FindByCourseIdAsync(Guid courseId);
    }
}
