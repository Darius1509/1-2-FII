using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommandResponse : BaseResponse
    {
        public UpdateAssignmentCommandResponse() : base()
        {
            
        }

        public AssignmentDto AssignmentDto { get; set; }
    }
}
