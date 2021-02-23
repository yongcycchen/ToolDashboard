using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<FSUser> _userManager;
        private readonly SignInManager<FSUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<FSUser> userManager, SignInManager<FSUser> signInManager, ITokenService tokenService
        )
        // , IMapper mapper)
        {
            // _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.FSId)) 
                return BadRequest("already have account");
            var user = new FSUser
            {
                UserName = registerDto.FSId,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };
            user.UserName = registerDto.FSId.ToLower();
            var result = await _userManager.CreateAsync(user,registerDto.FSId.ToLower());
            if (!result.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                FSId = user.UserName,
                Token = await _tokenService.CreateToken(user),
            };
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            loginDto.FSId = loginDto.FSId.ToLower();
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.FSId);
            if (user == null)
                return Unauthorized("Unregister");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user,loginDto.FSId,false);
            if (!result.Succeeded) return Unauthorized();
            
            return new UserDto
            {
                FSId = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
    }
}