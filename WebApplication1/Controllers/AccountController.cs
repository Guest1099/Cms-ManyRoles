using Application.Services;
using Application.Services.Abs;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


        [AllowAnonymous]
        [HttpGet("getUserByEmail/{email}")]
        public async Task<ActionResult<TaskResult<ApplicationUser>>> GetUserByEmail(string email)
        {
            try
            {
                var taskResult = await _accountService.GetUserByEmail(email);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<TaskResult<RegisterViewModel>>> Register(RegisterViewModel model)
        {
            try
            {
                var taskResult = await _accountService.Register(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<TaskResult<LoginViewModel>>> Login(LoginViewModel model)
        {
            try
            {
                var taskResult = await _accountService.Login(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }




        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _accountService.Logout();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [Authorize(Roles = "Administrator, User")]
        [HttpPost("changeEmail")]
        public async Task<ActionResult<TaskResult<ChangeEmailViewModel>>> ChangeEmail(ChangeEmailViewModel model)
        {
            try
            {
                var taskResult = await _accountService.ChangeEmail(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [Authorize(Roles = "Administrator, User")]
        [HttpPost("changePassword")]
        public async Task<ActionResult<TaskResult<ChangePasswordViewModel>>> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var taskResult = await _accountService.ChangePassword(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [Authorize(Roles = "Administrator, User")]
        [HttpPost("updateAccount")]
        public async Task<ActionResult<TaskResult<ApplicationUser>>> UpdateAccount(ApplicationUser model)
        {
            try
            {
                var taskResult = await _accountService.UpdateAccount(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [Authorize(Roles = "Administrator")]
        [HttpGet("userInRole/{email}/{roleName}")]
        public async Task<ActionResult<TaskResult<bool>>> UserInRole(string email, string roleName)
        {
            try
            {
                var taskResult = await _accountService.UserInRole(email, roleName);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPost("generateNewToken")]
        public async Task<ActionResult<TaskResult<string>>> GenerateNewToken(TokenViewModel model)
        {
            try
            {
                var taskResult = await _accountService.GenerateNewToken(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        /*
                [HttpPost("refreshToken")]
                public IActionResult RefreshToken([FromBody] RefreshTokenRequest (string request)
                {
                    // Znajdź refresh token w bazie danych i sprawdź jego ważność
                    var storedRefreshToken = _accountService.GetStoredRefreshToken(request.RefreshToken);
                    if (storedRefreshToken != null && storedRefreshToken.IsValid)
                    {
                        var claims = new[]
                        {
                                    new Claim(JwtRegisteredClaimNames.Sub, storedRefreshToken.Username),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                };

                        var newAccessToken = _tokenService.GenerateAccessToken(claims);
                        var newRefreshToken = _tokenService.GenerateRefreshToken();

                        // Zaktualizuj refresh token w bazie danych
                        UpdateStoredRefreshToken(storedRefreshToken.Username, newRefreshToken);

                        return Ok(new
                        {
                            AccessToken = newAccessToken,
                            RefreshToken = newRefreshToken
                        });
                    }

                    return Unauthorized();
                }*/


    }
}
