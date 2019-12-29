using System;
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
  [Route("api/[controller]")]
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
    public async Task<IActionResult> GetFiles()
    {
      var files = await _repo.GetFiles();

      var filesToReturn = _mapper.Map<IEnumerable<FileForListDto>>(files);

      return Ok(filesToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFile(int id)
    {
      var file = await _repo.GetFile(id);

      var fileToReturn = _mapper.Map<FileForDetailDto>(file);

      return Ok(fileToReturn);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFile(int id, FileForUpdateDto fileForUpdateDto)
    {
      var fileToUpdate = await _repo.GetFile(id);

      _mapper.Map(fileForUpdateDto, fileToUpdate);

      var client = await _repo.GetClient(fileForUpdateDto.ClientId);

      fileToUpdate.Client = client;

      if (await _repo.SaveAll())
        return NoContent();

      throw new Exception($"Updating file {id} failed on save");
    }
  }
}