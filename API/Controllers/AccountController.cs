using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //4.35{
    public class AccountController : BaseApiController
    {
        //4.43{
        private readonly ITokenService _tokenService;

//}4.43
        private readonly DataContext _context;
        public AccountController(DataContext context /*4.43:*/, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult</*AppUser 4.43:*/UserDto>> Register(/*4.37:*/RegisterDto registerDto/*string username, string password*/)
        {

            if (await UserExists(registerDto.Username))
            {

                return BadRequest("Username is taken");
            }

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {

                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
          //  return user;
          //4.43{
return new UserDto{
    Username=user.UserName,
    Token = _tokenService.CreateToken(user)

};
              //}4.43
        }
        //4.39{
        [HttpPost("login")]
        public async Task<ActionResult</*AppUser 4.43:*/UserDto>> Login(/*4.39:*/LoginDto loginDto/*string username, string password*/)
        {

            var user = await _context.Users
            .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }
            //4.43{
                return new UserDto{
    Username=user.UserName,
    Token = _tokenService.CreateToken(user)

};

            //}4.43
        }
        //}4.39
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
    //}4.35
}