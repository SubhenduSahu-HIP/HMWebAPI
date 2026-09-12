using Asp.Versioning;
using HM_Admin.CQRSImplementation;
using HM_Admin.Models;
using HM_Admin.Services.IService;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HM_Admin.Controllers
{
    [ApiController] // Adds default API behaviors
   
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // Supports URL path versioning: api/v5/HMAdmin
    [Route("api/[controller]")] // Supports Header/Query versioning: api/HMAdmin
    public class HMAdminController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminUserService _adminUserServicee;
        private readonly IMediator _mediator;
        public HMAdminController(IAdminUserService adminUserServicee, IMediator mediator, IConfiguration configuration)
        {
            _adminUserServicee = adminUserServicee;
            _mediator = mediator;
            _configuration = configuration;
        }

        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        [HttpPost("CreateAdminUser")]
        public async Task<IActionResult> CreatAdminUser([FromBody] AdminUser value)
        {
            var keyvalue = _configuration["Keyvalutsecret2:test"];//getting keyvault secret value from azure key vault
            var newAdminUser = await _adminUserServicee.CreateAdminUser(value);

            if (newAdminUser == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newAdminUser.UserId);//not correct return as ok
            }
            
        }

        [MapToApiVersion("1.0")]
        [HttpPost("CQRSImplementionCreateAdminUser")]
        public async Task<IActionResult> CQRSImplementionCreatAdminUser([FromBody] AdminUser value)
        {
            // Send the command through MediatR pipeline
            var newAdminUser = await _mediator.Send(new CreateAdminUserCommand(value));

            if (newAdminUser == null)
            {
                return BadRequest();
            }

            return Created($"/api/adminusers/{newAdminUser.UserId}", newAdminUser);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("CQRSImplementionGetAdminUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var allUsers = await _mediator.Send(new GetAllAdminUsersQuery());
            return Ok(allUsers);
        }
    }
}
