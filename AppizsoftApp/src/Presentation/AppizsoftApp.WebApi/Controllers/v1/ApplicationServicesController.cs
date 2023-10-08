using AppizsoftApp.Application.Constants;
using AppizsoftApp.Application.CustomAttributes;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Interfaces.Services.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers
{

    [Route("api/v1/app-services")]
    [ApiVersion("1")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ApplicationServicesController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("get-authorize-definition-endpoints")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Authorize Definition Endpoints", Menu = AuthorizeDefinitionConstants.ApplicationServices)]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
        [HttpGet("get-all-definition-endpoints")]
        public IActionResult GetAllDefinitionEndpoints()
        {
            var datas = _applicationService.GetAllDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}

