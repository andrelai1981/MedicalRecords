using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dto;
using MedicalRecords.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecords.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMedicalRecordsRepository _repo;
        private readonly IMapper _mapper;
        public UsersController (IMedicalRecordsRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }
        
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserForCreateDto userForCreateDto)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var currentUserIsAdmin = await _repo.IsAdmin(currentUserId);

            if (!currentUserIsAdmin) {
                return BadRequest("User is not an administrator cannot create account.");
            }

            // if ApiController is not used, this is checked against the model/dto
            // if (!ModelState.IsValid ) {
            //     return BadRequest(ModelState);
            // }
            userForCreateDto.UserName = userForCreateDto.UserName.ToLower();

            if (await _repo.UserExists(userForCreateDto.UserName))
            {
                return BadRequest("Username already exists");
            }
        
            var userToCreate = _mapper.Map<User>(userForCreateDto);

            var createdUser = await _repo.CreateUser(userToCreate, userForCreateDto.Password);
            
            var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

            return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.UserId}, userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            var userToUpdate = _mapper.Map<User>(userForUpdateDto);

            if (await _repo.UpdateUser(userToUpdate, userForUpdateDto.Password))
                return NoContent();
          
            throw new Exception($"Updating user failed on save");
        }
  }
}