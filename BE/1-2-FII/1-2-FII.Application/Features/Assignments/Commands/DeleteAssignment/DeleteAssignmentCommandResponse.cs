using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommandResponse : BaseResponse
    {
        public DeleteAssignmentCommandResponse() : base()
        {
            
        }
        public AssignmentDto AssignmentDto { get; set; }
    }
}
