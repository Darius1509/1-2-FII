using _1_2_FII.Application.Responses;

namespace _1_2_FII.Application.Features.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommandResponse : BaseResponse
    {
        public CreateAssignmentCommandResponse() : base()
        {
            
        }

        public AssignmentDto AssignmentDto { get; set; }
    }
}
