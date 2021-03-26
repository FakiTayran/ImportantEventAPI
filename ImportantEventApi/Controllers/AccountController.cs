using ImportantEventDataAccess.EfCore;
using ImportantEventEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoApi;
using TodoApi.Dtos;

namespace ImportantEventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ImportantEventDbContext _dbContext;

        public AccountController(UserManager<AppUser> userManager, IOptions<AppSettings> appSettings,ImportantEventDbContext dbContext)
        {
            _userManager = userManager;
            _appSettings = appSettings;
            _dbContext = dbContext;
        }

        // api/Accounts/Login
        // https://dotnetdetail.net/asp-net-core-5-web-api-token-based-authentication-example-using-jwt/
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm]LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(dto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user,dto.Password))
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes(_appSettings.Value.JwtSecret));

                var token = new JwtSecurityToken(
                    issuer:_appSettings.Value.JwtIssuer,
                    audience : _appSettings.Value.JwtIssuer,
                    expires:DateTime.Now.AddDays(7),
                    claims:authClaims,
                    signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
                    );

                var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new 
                {
                    token = stringToken ,
                    expiration = token.ValidTo 
                });
            }

            return BadRequest("Something Wrong");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInformation()
        {
            var user = 
            if (user != null)
            {
                return Ok(user.Email);
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser()
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return Ok();
            }


            return BadRequest(result);
        }
    }
}
