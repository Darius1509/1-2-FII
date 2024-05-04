﻿using _1_2_FII.Application.Contracts.Interfaces;
using System.Security.Claims;

namespace _12FIIAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public ClaimsPrincipal GetCurrentClaimsPrincipal()
        {
            if(httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null)
            {
                return httpContextAccessor.HttpContext.User;
            }
            else
            {
                return null;
            }
        }

        public string GetCurrentUserId()
        {
            if(httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null)
            {
                return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            else
            {
                return null;
            }
        }
    }
}
