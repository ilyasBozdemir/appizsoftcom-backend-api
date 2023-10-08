using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]

    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

