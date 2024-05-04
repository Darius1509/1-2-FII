﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _12FIIAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private ISender mediator = null!;
        protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}