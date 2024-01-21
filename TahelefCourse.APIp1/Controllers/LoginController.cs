using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahelef.Core.Models;
using Tahelef.Core.Service;

namespace TahelefCourse.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult GenerateToken(Login login)
        {
            var token = loginService.GenerateToken(login);
            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
