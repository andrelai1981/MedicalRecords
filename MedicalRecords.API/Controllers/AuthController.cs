using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dtos;
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
    // private readonly IMapper _mapper; 

    public AuthController(IAuthRepository repo, IConfiguration config)
    {
    //   _mapper = mapper;
      _config = config;
      _repo = repo;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Register(UserForCreateDto userForCreateDto)
    {

      // if ApiController is not used, this is checked against the model/dto
      // if (!ModelState.IsValid ) {
      //     return BadRequest(ModelState);
      // }
      userForCreateDto.UserName = userForCreateDto.UserName.ToLower();

      if (await _repo.UserExists(userForCreateDto.UserName))
      {
        return BadRequest("Username already exists");
      }

        var userToCreate = new User{
            UserName = userForCreateDto.UserName
        };

        var createdUser = await _repo.CreateUser(userToCreate, userForCreateDto.Password);

        return StatusCode(201);
    //   var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

    //   return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.UserId}, userToReturn);
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

      // var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new
            {
              token = tokenHandler.WriteToken(token),

            });

    }
  }
}