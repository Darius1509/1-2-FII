using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Answers.Queries.GetAnswerById
{
    public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, AnswerDto>
    {
        private readonly IAnswerRepository repository;

        public GetAnswerByIdQueryHandler(IAnswerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AnswerDto> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var answer = await repository.FindByIdAsync(request.AnswerId);
            if (answer.IsSuccess)
            {
                return new AnswerDto
                {
                    AnswerId = answer.Value.AnswerId,
                    AnswerStudentId = answer.Value.AnswerStudentId,
                    AnswerAssignmentRespondedId = answer.Value.AnswerAssignmentRespondedId,
                    AnswerContent = answer.Value.AnswerContent
                };
            }
            return new AnswerDto();
        }
    }
}
