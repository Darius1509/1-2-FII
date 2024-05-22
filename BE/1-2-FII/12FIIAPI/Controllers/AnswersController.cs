using _1_2_FII.Application.Features.Answers.Commands.CreateAnswer;
using _1_2_FII.Application.Features.Answers.Commands.DeleteAnswer;
using _1_2_FII.Application.Features.Answers.Commands.UpdateAnswer;
using _1_2_FII.Application.Features.Answers.Queries.GetAllAnswers;
using _1_2_FII.Application.Features.Answers.Queries.GetAnswerByAssignmentId;
using _1_2_FII.Application.Features.Answers.Queries.GetAnswerById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _12FIIAPI.Controllers
{
    public class AnswersController : ApiControllerBase
    {
        [Authorize(Roles ="Admin, Professor")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllAnswersQuery());
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Professor")]
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetAnswerByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles ="Admin, Professor")]
        [HttpGet("assignment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAssignmentId(Guid id)
        {
            var result = await Mediator.Send(new GetAnswerByAssignmentIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Student")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(DeleteAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin, Student")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Accepted(result);
        }   

    }
}
