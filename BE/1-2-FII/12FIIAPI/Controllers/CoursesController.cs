using _1_2_FII.Application.Features.Courses.Commands.CreateCourse;
using _1_2_FII.Application.Features.Courses.Commands.DeleteCourse;
using _1_2_FII.Application.Features.Courses.Commands.UpdateCourse;
using _1_2_FII.Application.Features.Courses.Queries.GetAllCourses;
using _1_2_FII.Application.Features.Courses.Queries.GetCourseById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _12FIIAPI.Controllers
{

    public class CoursesController : ApiControllerBase
    {
        [Authorize(Roles = "Admin, Student, Professor")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllCoursesQuery());
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Student, Professor")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetCourseByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            var result = await Mediator.Send(command);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(DeleteCourseCommand command)
        {
            var result =  await Mediator.Send(command);
            if(!result.Success)
            {
                return NotFound(result);
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateCourseCommand command)
        {
            var result = await Mediator.Send(command);
            if(!result.Success)
            {
                return NotFound(result);
            }
            return Accepted(result);
        }
    }
}
