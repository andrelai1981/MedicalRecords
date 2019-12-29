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
    public class ClientsController : ControllerBase
    {
        private readonly IMedicalRecordsRepository _repo;
        private readonly IMapper _mapper;
        public ClientsController (IMedicalRecordsRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _repo.GetClients();

            var clientsToReturn = _mapper.Map<IEnumerable<ClientForListDto>>(clients);

            return Ok(clientsToReturn);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _repo.GetClient(id);

            var clientToReturn = _mapper.Map<ClientForListDto>(client);

            return Ok(clientToReturn);
        }
    }
}