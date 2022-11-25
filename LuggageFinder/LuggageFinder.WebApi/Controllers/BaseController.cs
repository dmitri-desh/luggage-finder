using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LuggageFinder.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => 
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal long UserId => !User.Identity.IsAuthenticated ? 0 : long.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); 
    }
}
