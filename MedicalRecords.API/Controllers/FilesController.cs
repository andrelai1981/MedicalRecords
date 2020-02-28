using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dto;
using MedicalRecords.API.Helpers;
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
    public async Task<IActionResult> GetFiles([FromQuery]FileParams fileParams)
    {
      var files = await _repo.GetFiles(fileParams);

      var filesToReturn = _mapper.Map<IEnumerable<FileForListDto>>(files);

      Response.AddPagination(files.CurrentPage, files.PageSize, files.TotalCount, files.TotalPages);

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

      if (fileForUpdateDto.Destroyed && fileToUpdate.Destroyed)
        return BadRequest("File is already destroyed.");

      // if user registers a destruction date and the box in the db is currently not destroyed, mark for destruction -- user is destroying the box
      if (fileForUpdateDto.ActualDestructionDate != null && !fileToUpdate.Destroyed)
        fileForUpdateDto.Destroyed = true;
      // if user registers clears the actual destruction date and the box in the db is currently destroyed, mark for restoration -- user is reversing the destruction
      else if (fileForUpdateDto.ActualDestructionDate == null && fileToUpdate.Destroyed)
        fileForUpdateDto.Destroyed = false;

      if (fileForUpdateDto.ActualDestructionDate == null)
      {
        fileForUpdateDto.ActualDestructionDate = DateTime.Now;
      }

      if (fileForUpdateDto.Destroyed == true
          && fileForUpdateDto.ActualDestructionDate < fileForUpdateDto.AnticipatedDestructionDate)
        return BadRequest("Cannot delete file that has an antipated destruction date in the future.");

      _mapper.Map(fileForUpdateDto, fileToUpdate);

      var client = await _repo.GetClient(fileForUpdateDto.ClientId);
      var box = await _repo.GetBox(fileForUpdateDto.BoxId);

      fileToUpdate.Client = client;
      fileToUpdate.Box = box;


      if (await _repo.SaveAll())
        return NoContent();

      throw new Exception($"Updating file {id} failed on save");
    }
  }
}