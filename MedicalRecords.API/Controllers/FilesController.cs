using System.Collections.Generic;
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
  [Route("api/boxes/{boxId}/files/")]
  [ApiController]
  public class FilesController : ControllerBase
  {
    private readonly IMedicalRecordsRepository _repo;
    private readonly IMapper _mapper;
    public FilesController(IMedicalRecordsRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }
    // GET api/files
    [HttpGet]
    public async Task<IActionResult> GetFilesForBox(int boxId)
    {
      var files = await _repo.GetFilesForBox(boxId);

      var filesToReturn = _mapper.Map<IEnumerable<FileForListDto>>(files);

      return Ok(filesToReturn);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetFile(int id)
    // {
    //   var file = await _repo.GetFile(id);

    //   var fileToReturn = _mapper.Map<FileForListDto>(file);

    //   return Ok(fileToReturn);
    // }


    [HttpPost("create")]
    public async Task<IActionResult> CreateFile(int boxId, FileForCreateDto fileForCreateDto)
    {
      var fileToCreate = _mapper.Map<File>(fileForCreateDto);
      var box = await _repo.GetBox(boxId);
      var client = await _repo.GetClient(fileForCreateDto.Client);

      fileToCreate.Box = box;
      fileToCreate.Client = client;

      var createdFile = await _repo.CreateFile(fileToCreate);

      return StatusCode(201);
    }
  }
}