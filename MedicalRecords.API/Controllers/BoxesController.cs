using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalRecords.API.Data;
using MedicalRecords.API.Dto;
using MedicalRecords.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetBoxes() 
    {
        var boxes = await _repo.GetBoxes();

        var boxesToReturn = _mapper.Map<IEnumerable<BoxForListDto>>(boxes);

        return Ok(boxesToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBox(int id)
    {
      var box = await _repo.GetBox(id);

      var boxToReturn = _mapper.Map<BoxForDetailedDto>(box);
      
      return Ok(boxToReturn);
    }

    // [HttpPost("createbox")]
    // public async Task<IActionResult> CreateBox(BoxForCreateDto boxForCreateDto)
    // {
    //   if (await _repo.BoxExists(boxForCreateDto.BarcodeNum))
    //   {
    //     return BadRequest("Box with that barcode number already exists");
    //   }

    //   var boxTocreate = new Box {
    //     BarcodeNum = boxForCreateDto.BarcodeNum
    //     ,Department = boxForCreateDto.Department
    //     ,County = boxForCreateDto.County
    //   };

    //   var createdBox = await _repo.CreateBox(boxTocreate);

    //   return StatusCode(201);
    // }
  }
}