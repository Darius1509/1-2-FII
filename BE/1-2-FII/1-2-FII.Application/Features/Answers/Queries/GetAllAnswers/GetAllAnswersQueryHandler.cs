using _1_2_FII.Application.Persistence;
using MediatR;

namespace _1_2_FII.Application.Features.Answers.Queries.GetAllAnswers
{
    public class GetAllAnswersQueryHandler : IRequestHandler<GetAllAnswersQuery, List<AnswerDto>>
    {
        private readonly IAnswerRepository repository;

        public GetAllAnswersQueryHandler(IAnswerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<AnswerDto>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
        {
            var answers = await repository.FindAllAsync();
            var listOfAnswers =  new List<AnswerDto>();

            foreach(var answer in answers.Value)
            {
                listOfAnswers.Add(new AnswerDto
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
