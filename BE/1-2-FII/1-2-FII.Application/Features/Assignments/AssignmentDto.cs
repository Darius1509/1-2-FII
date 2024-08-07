﻿namespace _1_2_FII.Application.Features.Assignments
{
    public class AssignmentDto
    {
        public Guid AssignmentId { get; set; }
        public string AssignmentQuestion { get; set; }
        public string AssignmentCode { get; set; }
        public Guid AssignmentCourseId { get; set; }
        public Guid AssignmentProfessorId { get; set; }
        public List<Guid> AssignmentAnswersId { get; set; }
    }
}
