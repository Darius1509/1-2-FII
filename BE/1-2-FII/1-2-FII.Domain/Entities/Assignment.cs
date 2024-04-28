using _1_2_FII.Domain.Common;

namespace _1_2_FII.Domain.Entities
{
    public class Assignment
    {
        public Assignment(string assignmentQuestion, string assignmentCode, Guid assignmentCourseId, Guid assignmentProfessorId)
        {
            AssignmentId = Guid.NewGuid();
            AssignmentQuestion = assignmentQuestion;
            AssignmentCode = assignmentCode;
            AssignmentCourseId = assignmentCourseId;
            AssignmentProfessorId = assignmentProfessorId;
            AssignmentAnswersId = new List<Guid>();
        }

        public Guid  AssignmentId { get; private set; }
        public string AssignmentQuestion { get; private set; }
        public string AssignmentCode { get; private set; }
        public Guid AssignmentCourseId { get; private set; }
        public Guid AssignmentProfessorId { get; private set; }
        public List<Guid> AssignmentAnswersId { get; private set; }

        public static Result<Assignment> Create(string assignmentQuestion, string assignmentCode, Guid assignmentCourseId, Guid assignmentProfessorId)
        {
            var validation = ValidateParameters(assignmentQuestion, assignmentCode, assignmentCourseId, assignmentProfessorId);
            if (validation != null)
            {
                return validation;
            }
            return Result<Assignment>.Success(new Assignment(assignmentQuestion, assignmentCode, assignmentCourseId, assignmentProfessorId));
        }

        public static Result<Assignment> Update(Guid assignmentId, string assignmentQuestion, string assignmentCode, Guid assignmentCourseId, Guid assignmentProfessorId)
        {
            var validation = ValidateParameters(assignmentQuestion, assignmentCode, assignmentCourseId, assignmentProfessorId);
            if (validation != null)
            {
                return validation;
            }
            var assignment = new Assignment(assignmentQuestion, assignmentCode, assignmentCourseId, assignmentProfessorId)
            {
                AssignmentId = assignmentId
            };
            return Result<Assignment>.Success(assignment);
        }

        private static Result<Assignment>? ValidateParameters(string assignmentQuestion, string assignmentCode, Guid assignmentCourseId, Guid assignmentProfessorId)
        {
            if (string.IsNullOrWhiteSpace(assignmentQuestion))
            {
                return Result<Assignment>.Failure("Assignment question cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(assignmentCode))
            {
                return Result<Assignment>.Failure("Assignment code cannot be empty");
            }
            if (assignmentCourseId == Guid.Empty)
            {
                return Result<Assignment>.Failure("Assignment course id cannot be empty");
            }
            if (assignmentProfessorId == Guid.Empty)
            {
                return Result<Assignment>.Failure("Assignment professor id cannot be empty");
            }
            return null;
        }

        public void AttachAnswer(Guid answerId)
        {
            if (answerId == Guid.Empty)
            {
                throw new ArgumentException("Answer id cannot be empty");
            }
            if (AssignmentAnswersId == null)
            {
                AssignmentAnswersId = new List<Guid>();
            }
            AssignmentAnswersId.Add(answerId);
        }
    }
}
