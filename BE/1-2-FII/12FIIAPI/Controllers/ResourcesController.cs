﻿using _1_2_FII.Application.Features.Resources.Commands.CreateResource;
using _1_2_FII.Application.Features.Resources.Commands.DeleteResource;
using _1_2_FII.Application.Features.Resources.Commands.UpdateResource;
using _1_2_FII.Application.Features.Resources.Queries.GetAllResources;
using _1_2_FII.Application.Features.Resources.Queries.GetResourceById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _12FIIAPI.Controllers
{
    public class ResourcesController : ApiControllerBase
    {
        //[Authorize(Roles = "Admin, Student, Professor")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllResourcesQuery());
            return Ok(result);
        }

        //[Authorize(Roles = "Admin, Student, Professor")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetResourceByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //[Authorize(Roles = "Admin, Professor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateResourceCommand command)
        {
            if (command.ResourceFileContent == null || command.ResourceFileContent.Length == 0)
            {
                return BadRequest("Non-empty file is required.");
            }
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //[Authorize(Roles = "Admin, Professor")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(DeleteResourceCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

        //[Authorize(Roles = "Admin, Professor")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateResourceCommand command)
        {
            if (command.ResourceFileContent == null || command.ResourceFileContent.Length == 0)
            {
                return BadRequest("Non-empty file is required.");
            }
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Accepted(result);
        }
    }
}