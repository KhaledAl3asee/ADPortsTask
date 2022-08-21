using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ADPortsTask.Data.Models;
using ADPortsTask.DTOs;
using ADPortsTask.Helpers;
using ADPortsTask.Services.Interfaces;
using ADPortsTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ADPortsTask.Exceptions;

namespace ADPortsTask.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IJwtService jwtService;
        private readonly IMapperService mapper;

        public AuthController( IUserService userService, IJwtService jwtService, IMapperService mapper)
        {
            this.userService = userService;
            this.jwtService = jwtService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AuthLoginDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = null;
            bool userNotFound = false;
            try
            {
                user = await userService.GetUserByEmail(dto.Email);
            }
            catch (CurrentEntryNotFoundException)
            {
                userNotFound = true;
            }            

            if (userNotFound || !await userService.CheckPassword(user, dto.Password))
            {
                ModelState.AddModelError("loginFailure", "Invalid email or password");
                return BadRequest(ModelState);
            }

            if (!(user.ApprovalStatus ?? false))
            {
                ModelState.AddModelError("loginFailure", "Not approved yet");
                return BadRequest(ModelState);
            }

            if (user.IsBlocked ?? false)
            {
                ModelState.AddModelError("loginFailure", "Account has been blocked");
                return BadRequest(ModelState);
            }

            var userClaims = await jwtService.GetClaimsAsync(user);
            var accessToken = jwtService.GenerateJwtAccessToken(userClaims);
             
            var tokens = new AuthTokensDto
            {
                AccessToken = accessToken,                 
                ExpireOn = jwtService.ExpirationTime
            };

            return Ok(tokens);
        }

        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody]AuthTokensDto dto)
        {
            var principal = jwtService.GetPrincipalFromExpiredAccessToken(dto.AccessToken);
            
            return Ok();
        }

    }
}