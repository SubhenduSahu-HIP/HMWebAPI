using Asp.Versioning;
using HM_Admin.CQRSImplementation;
using HM_Admin.Services.IService;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HM_Admin.Controllers
{
    [ApiController] // Adds default API behaviors

    [ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    //[Route("api/v{version:apiVersion}/[controller]")] // Supports URL path versioning: api/v5/HMAdmin
    //[Route("api/[controller]")] // Supports Header/Query versioning: api/HMAdmin
    public class HMMasterDataController : Controller
    {
        
        private readonly IMediator _mediator;
        public HMMasterDataController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [MapToApiVersion("1.0")]
        [HttpGet("GetAllCountry")]
       public async Task<ActionResult<IEnumerable<HM_Admin.Models.Countries>>> GetAllCountry()
        {
            // Implement your logic to retrieve all countries here
            var countries = await _mediator.Send(new GetMasterDataCommand());
            return new ActionResult<IEnumerable<HM_Admin.Models.Countries>>(countries); 
        }
    }
}
