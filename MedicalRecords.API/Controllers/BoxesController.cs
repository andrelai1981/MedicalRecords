using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dto;
using MedicalRecords.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using MedicalRecords.API.Helpers;

namespace MedicalRecords.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class BoxesController : ControllerBase
  {
    private readonly IMedicalRecordsRepository _repo; 
    private readonly IMapper _mapper; 
    public BoxesController(IMedicalRecordsRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }
    // GET api/boxes
    [HttpGet]
    public async Task<IActionResult> GetBoxes([FromQuery]BoxParams boxParams) 
    {
        var boxes = await _repo.GetBoxes(boxParams);

        var boxesToReturn = _mapper.Map<IEnumerable<BoxForListDto>>(boxes);

        Response.AddPagination(boxes.CurrentPage, boxes.PageSize, boxes.TotalCount, boxes.TotalPages);

        return Ok(boxesToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBox(int id)
    {
      var box = await _repo.GetBox(id);

      var boxToReturn = _mapper.Map<BoxForDetailedDto>(box);
      return Ok(boxToReturn);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateBox(BoxForCreateDto boxForCreateDto)
    {
      if (await _repo.BoxExists(boxForCreateDto.BarcodeNum))
      {
        return BadRequest("Box with that barcode number already exists");
      }

      var boxTocreate = _mapper.Map<Box>(boxForCreateDto);

      var dept = await _repo.GetDepartment(boxForCreateDto.Department);
      var county = await _repo.GetCounty(boxForCreateDto.County);
      
      boxTocreate.Department = dept;
      boxTocreate.County = county;

      var createdBox = await _repo.CreateBox(boxTocreate);

      return StatusCode(201);
    }

    [HttpPost("{id}/files/create")]
    public async Task<IActionResult> CreateFile(int id, FileForCreateDto fileForCreateDto)
    {
      var fileToCreate = _mapper.Map<File>(fileForCreateDto);
      var box = await _repo.GetBox(id);
      var client = await _repo.GetClient(fileForCreateDto.ClientId);

      fileToCreate.Box = box;
      fileToCreate.Client = client;

      var createdFile = await _repo.CreateFile(fileToCreate);

      return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBox(int id, BoxForUpdateDto boxForUpdateDto)
    {
      var boxToUpdate = await _repo.GetBox(id);
      var numberOfFilesInBox = await _repo.GetNumberOfFilesInBox(id);
      
      if (boxForUpdateDto.Destroyed && boxToUpdate.Destroyed)
        return BadRequest("Box is already destroyed");
      
      // if user registers a destruction date and the box in the db is currently not destroyed, mark for destruction -- user is destroying the box
      if (boxForUpdateDto.ActualDestructionDate != null && !boxToUpdate.Destroyed)
        boxForUpdateDto.Destroyed = true;
      // if user registers clears the actual destruction date and the box in the db is currently destroyed, mark for restoration -- user is reversing the destruction
      else if (boxForUpdateDto.ActualDestructionDate == null && boxToUpdate.Destroyed)
        boxForUpdateDto.Destroyed = false;

      if (boxForUpdateDto.ActualDestructionDate == null)
      {
        boxForUpdateDto.ActualDestructionDate = DateTime.Now;
      }

      _mapper.Map(boxForUpdateDto, boxToUpdate);

      var dept = await _repo.GetDepartment(boxForUpdateDto.Department);
      var county = await _repo.GetCounty(boxForUpdateDto.County);

      boxToUpdate.Department = dept;
      boxToUpdate.County = county;

      if (boxToUpdate.Destroyed == true && numberOfFilesInBox > 0) 
        return BadRequest("Cannot destroy a box if more than 1 file exists in that box.");

      if (await _repo.SaveAll())
        return NoContent();

      throw new Exception($"Updating box {id} failed on save");
    }
  }
}