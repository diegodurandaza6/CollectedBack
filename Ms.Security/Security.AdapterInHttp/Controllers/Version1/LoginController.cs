using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Domain.IPortsIn;
using Security.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Security.AdapterInHttp.Controllers.Version1
{

    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("GetToken")]
        public IActionResult GetToken([FromBody, Required] UserLoginDto login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (login.UserName == null || login.Password == null)
                {
                    return BadRequest("Se requiere un objeto válido en el cuerpo de la solicitud.");
                }
                UserModelDto? user = _loginService.Authenticate(login);
                if (user != null)
                {
                    return Ok(_loginService.GenerateToken(user));
                }

                return Unauthorized();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
