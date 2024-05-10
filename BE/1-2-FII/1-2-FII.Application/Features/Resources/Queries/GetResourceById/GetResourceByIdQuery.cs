using MediatR;

namespace _1_2_FII.Application.Features.Resources.Queries.GetResourceById
{
    public class GetResourceByIdQuery : IRequest<ResourceDto>
    {
        public Guid ResourceId { get; set; }
        public GetResourceByIdQuery(Guid resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
