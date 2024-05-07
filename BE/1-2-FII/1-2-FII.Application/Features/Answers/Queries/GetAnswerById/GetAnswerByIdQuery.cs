using MediatR;

namespace _1_2_FII.Application.Features.Answers.Queries.GetAnswerById
{
    public class GetAnswerByIdQuery : IRequest<AnswerDto>
    {
        public Guid AnswerId { get; }

        public GetAnswerByIdQuery(Guid answerId)
        {
            AnswerId = answerId;
        }
    }
}
