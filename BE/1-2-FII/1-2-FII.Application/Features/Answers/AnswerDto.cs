namespace _1_2_FII.Application.Features.Answers
{
    public class AnswerDto
    {
        public Guid AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public Guid AnswerStudentId { get; set; }
        public Guid AnswerAssignmentRespondedId { get; set; }
    }
}
