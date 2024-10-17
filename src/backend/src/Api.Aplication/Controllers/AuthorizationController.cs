
using System.Net;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.UPX4.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authService;


        public AuthorizationController(IAuthorizationService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _authService.Login(loginDto);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    }
}