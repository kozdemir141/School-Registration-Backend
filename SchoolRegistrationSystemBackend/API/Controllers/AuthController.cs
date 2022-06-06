using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]

        public ActionResult UserLogin(LoginDto loginDto)
        {
            var educatorToExists = _authService.EducatorExists(loginDto.UserName);

            if (educatorToExists.Success)
            {
                var educatorToLogin = _authService.EducatorLogin(loginDto);

                if (!educatorToLogin.Success)
                {
                    return BadRequest(educatorToLogin.Message);
                }

                var educatorResult = _authService.CreateAccessTokenForEducator(educatorToLogin.Data);

                if (educatorResult.Success)
                {
                    return Ok(educatorResult.Data);
                }
                return BadRequest(educatorResult.Message);

            }

            var studentToLogin = _authService.StudentLogin(loginDto);

            if (!studentToLogin.Success)
            {
                return BadRequest(studentToLogin.Message);
            }

            var studentresult = _authService.CreateAccessTokenForStudent(studentToLogin.Data);

            if (studentresult.Success)
            {
                return Ok(studentresult.Data);
            }
            return BadRequest(studentresult.Message);
        }


        [HttpPost("register")]

        public ActionResult UserRegister(RegisterDto registerDto)
        {
            var userExists = _authService.UserExists(registerDto.Email);

            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            if (registerDto.Email.Contains("@pau.edu.tr"))
            {
                var educatorRegisterResult = _authService.EducatorRegister(registerDto);

                var educatorResult = _authService.CreateAccessTokenForEducator(educatorRegisterResult.Data);

                if (educatorResult.Success)
                {
                    return Ok(educatorResult.Data);
                }
                return BadRequest(educatorResult.Message);
            }

            var studentregisterResult = _authService.StudentRegister(registerDto);

            var studentResult = _authService.CreateAccessTokenForStudent(studentregisterResult.Data);

            if (studentResult.Success)
            {
                return Ok(studentResult.Data);
            }
            return BadRequest(studentResult.Message);
        }
    }
}
