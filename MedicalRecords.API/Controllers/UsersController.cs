using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dto;
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

        // [HttpGet("{id}/isAdmin", Name = "IsAdmin")]
        // public async Task<IActionResult> IsAdmin(int id)
        // {
        // var user = await _repo.IsAdmin(id);

        // // var userToReturn = _mapper.Map<UserForDetailedDto>(user);

        // return Ok(user);
        // }
  }
}