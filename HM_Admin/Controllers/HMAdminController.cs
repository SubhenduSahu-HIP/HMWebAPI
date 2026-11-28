using Asp.Versioning;
using HM_Admin.CQRSImplementation;
using HM_Admin.Models;
using HM_Admin.Services.IService;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace HM_Admin.Controllers
{
    [ApiController] // Adds default API behaviors

    [ApiVersion(1)]
    [ApiVersion(2)]
    [Route("api/v{version:apiVersion}/[controller]")] // Supports URL path versioning: api/v5/HMAdmin
    //[Route("api/[controller]")] // Supports Header/Query versioning: api/HMAdmin
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


        [MapToApiVersion(2)]
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
        [MapToApiVersion(1)]
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> CQRSImplementionGetAllUser()
        {
            var allUsers = await _mediator.Send(new GetAllUsers());
            return Ok(allUsers);
        }
        [MapToApiVersion(1)]
        [HttpPost("CreateUser")]
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

        [MapToApiVersion(1)]
        [HttpGet("GetAdminUser")]
        public async Task<IActionResult> CQRSImplementionGetAllAdminUser()
        {
            var allUsers = await _mediator.Send(new GetAllAdminUsers());
            return Ok(allUsers);
        }

        [MapToApiVersion(1)]
        [HttpGet("GetUserById")]
        public async Task<IActionResult> CQRSImplementionGetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [MapToApiVersion(1)]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> CQRSImplementionUpdateUser(AdminUser userDetails)
        {
            var user = await _mediator.Send(new UpdateUserCommand(userDetails));
            if (user == null)
            {
                return NotFound();
            }
            return StatusCode((int)HttpStatusCode.OK, user);
        }

        [MapToApiVersion(1)]
        [HttpGet("GetUserByEmailAndPassword")]
        public async Task<ActionResult<AdminUser>> GetUserEmailAndPassword(string email, string password)
        {
            var objectUser = await _mediator.Send(new GetUserByEmailAndPassword(email, password));
            if (objectUser == null )
            {
                return NotFound();
                //throw new Exception();
            }


            return Ok(objectUser);
        }
    }
}
