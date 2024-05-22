using _1_2_FII.Application.Persistence;
using _1_2_FII.Domain.Common;
using MediatR;

namespace _1_2_FII.Application.Features.Answers.Queries.GetAnswerByAssignmentId
{
    public class GetAnswerByAssignmnetIdQueryHandler : IRequestHandler<GetAnswerByAssignmentIdQuery, List<AnswerDto>>
    {
        private readonly IAnswerRepository repository;

        public GetAnswerByAssignmnetIdQueryHandler(IAnswerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<AnswerDto>> Handle(GetAnswerByAssignmentIdQuery query, CancellationToken cancellationToken)
        {
            var answers = await repository.FindAnswersByAnswerAssignmentId(query.AssignmentId);
            var listOfAnswers = new List<AnswerDto>();
            foreach (var answer in answers.Value)
            {
                listOfAnswers.Add(
                                       new AnswerDto
                                       {
                        AnswerId = answer.AnswerId,
                        AnswerStudentId = answer.AnswerStudentId,
                        AnswerAssignmentRespondedId = answer.AnswerAssignmentRespondedId,
                        AnswerContent = answer.AnswerContent
                    });
            }
            return listOfAnswers;
        }
    }
}
