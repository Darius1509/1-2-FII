using _1_2_FII.Application.Features.Assignments.Commands.AttachAnswer;
using _1_2_FII.Application.Features.Assignments.Commands.CreateAssignment;
using _1_2_FII.Application.Features.Assignments.Commands.DeleteAssignment;
using _1_2_FII.Application.Features.Assignments.Commands.UpdateAssignment;
using _1_2_FII.Application.Features.Assignments.Queries.GetAllAssignments;
using _1_2_FII.Application.Features.Assignments.Queries.GetAssignmentById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _12FIIAPI.Controllers
{
    public class AssignmentsController : ApiControllerBase
    {
        [Authorize(Roles="Admin, Professor, Student")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result  = await Mediator.Send(new GetAllAssignmentsQuery());
            return Ok(result);
        }

        [Authorize(Roles="Admin, Professor, Student")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetAssignmentByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles="Admin, Professor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateAssignmentCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize(Roles="Admin, Professor")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(DeleteAssignmentCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

        [Authorize(Roles="Admin, Professor")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateAssignmentCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Accepted(result);
        }

        [Authorize(Roles="Admin, Student")]
        [HttpPost("{assignmentId}/attach-answer/{answerId}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AttachAnswer(Guid assignmentId, Guid answerId)
        {
            var command = new AttachAnswerCommand
            {
                AssignmentId = assignmentId,
                AnswerId = answerId
            };
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Accepted(result);
        }

        



    }
}
