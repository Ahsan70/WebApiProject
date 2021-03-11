using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FxTradeApi.Models;
using FxTradeApi.Repository.IRepository;

namespace FxTradeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private INationalParkRepository _nationalParkRepository;
        private IMapper _mapper;

        public NationalParksController(INationalParkRepository nationalParkRepository,IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllNationalParks()
        {
            var data = _nationalParkRepository.GetNationalParks();
            var objectdto = new List<NationalParkDto>();
            foreach (var item in data)
            {
                objectdto.Add(_mapper.Map<NationalParkDto>(item));
            }
            return Ok(objectdto);
        }

        [HttpGet("{nationalParkId:int}")]
        public IActionResult GetAllNationalParks(int nationalParkId)
        {
            var data = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (data == null)
            {
                return NotFound();
            }

            var objectdto = _mapper.Map<NationalParkDto>(data);
            return Ok(objectdto);
        }

        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_nationalParkRepository.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("","National Park Exist !");
                return StatusCode(404, ModelState);

            }

          

            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);

            if (!_nationalParkRepository.CreateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("",$"Something wents wrong when saving record {nationalParkDto.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}
