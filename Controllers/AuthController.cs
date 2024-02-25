using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.Models;
using Microsoft.AspNetCore.Authorization;
using TaskManagement.Services;
using System.Threading.Tasks;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        { 
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser request)
        {
            try
            {
                var response = _authService.AuthenticateAsync(request);

                return new ObjectResult(response) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return BadRequest(new TaskErrorResponse()
                {
                    Message = ex.Message
                });
            }
        }

    }
}
