using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
// using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dto;
using MedicalRecords.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MedicalRecords.API.Controllers
{
  
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;
   private readonly IMapper _mapper; 

    public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
    {
       _mapper = mapper;
      _config = config;
      _repo = repo;
    }



    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {

      var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password, userForLoginDto.IsAdmin);

      if (userFromRepo == null)
      {
        return Unauthorized();
      }

      var claims = new[]  {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new
            {
              token = tokenHandler.WriteToken(token),
              user
            });

    }
  }
}