using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TSK.API.Models;
using TSK.Application.Interfaces;
using TSK.ExceptionHandler;
using TSK.Model;
using TSK.Model.Login;

namespace TSK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _service;

        public LoginController(IConfiguration configuration, ILoginService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Token))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(TskExceptionModel))]
        public ActionResult<Token> Login([FromBody] Login login)
        {
            try
            {
                string key = _configuration.GetSection("TokenConfiguration:Key").Value;
                string validIssuer = _configuration.GetSection("TokenConfiguration:ValidIssuer").Value;
                string validAudience = _configuration.GetSection("TokenConfiguration:ValidAudience").Value;
                return _service.Login(login, key, validIssuer, validAudience);
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        [HttpGet]
        [Route("GenerateHash")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(TskExceptionModel))]
        public ActionResult<string> GenerateHash(string source)
        {
            try
            {
                return _service.GenerateHash(source);
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }

        [HttpGet]
        [Route("CompareHash")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(TskExceptionModel))]
        public ActionResult<bool> CompareHash(string firstHash, string secondHash)
        {
            try
            {
                return _service.CompareHash(firstHash, secondHash);
            }
            catch (Exception exception)
            {
                var error = ExceptionManager.ReturnErrorMessage(exception);
                return StatusCode(error.StatusCode.GetValueOrDefault(500), error.Value);
            }
        }
    }
}
