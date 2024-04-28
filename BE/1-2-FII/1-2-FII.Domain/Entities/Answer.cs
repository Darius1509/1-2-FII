using _1_2_FII.Domain.Common;

namespace _1_2_FII.Domain.Entities
{
    public class Answer
    {
        public Answer(Guid answerAssignmentRespodedId, Guid answerStudentId, string answerContent)
        {
            AnswerId = Guid.NewGuid();
            AnswerAssignmentRespondedId = answerAssignmentRespodedId;
            AnswerStudentId = answerStudentId;
            AnswerContent = answerContent;
        }

        public Guid AnswerId { get; private set; }
        public Guid AnswerAssignmentRespondedId { get; private set; }
        public Guid AnswerStudentId { get; private set; }
        public string AnswerContent { get; private set; }

        public static Result<Answer> Create(Guid answerAssignmentRespodedId, Guid answerStudentId, string answerContent)
        {
            var validation = ValidateParameters(answerAssignmentRespodedId, answerStudentId, answerContent);
            if (validation != null)
            {
                return validation;
            }
            return Result<Answer>.Success(new Answer(answerAssignmentRespodedId, answerStudentId, answerContent));
        }

        public static Result<Answer> Update(Guid answerId, Guid answerAssignmentRespodedId, Guid answerStudentId, string answerContent)
        {
            var validation = ValidateParameters(answerAssignmentRespodedId, answerStudentId, answerContent);
            if (validation != null)
            {
                return validation;
            }
            var answer = new Answer(answerAssignmentRespodedId, answerStudentId, answerContent)
            {
                AnswerId = answerId
            };
            return Result<Answer>.Success(answer);
        }

        private static Result<Answer>? ValidateParameters(Guid answerAssignmentRespodedId, Guid answerStudentId, string answerContent)
        {
            if (answerAssignmentRespodedId == Guid.Empty)
            {
                return Result<Answer>.Failure("Answer assignment responded id cannot be empty");
            }
            if (answerStudentId == Guid.Empty)
            {
                return Result<Answer>.Failure("Answer student id cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(answerContent))
            {
                return Result<Answer>.Failure("Answer content cannot be empty");
            }
            return null;
        }
    }
}
