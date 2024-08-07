﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace _1_2_FII.Application.Features.Resources.Commands.CreateResource
{
    public class CreateResourceCommand : IRequest<CreateResourceCommandResponse>
    {
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourceType { get; set; }
        public string ResourcePrerequisites { get; set; }
        public IFormFile ResourceFileContent { get; set; }
        public Guid ResourceCourseId { get; set; }
    }
}
