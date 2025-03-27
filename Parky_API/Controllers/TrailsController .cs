using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parky_API.Models;
using Parky_API.Models.Dtos;
using Parky_API.Repository.IRepository;

namespace Parky_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Trails")]

    public class TrailsController : ControllerBase
    {
        private ITrailRepository _trailRepo;
        private readonly IMapper _mapper;

        public TrailsController(ITrailRepository trailRepo, IMapper mapper)
        {
            _trailRepo = trailRepo;
            _mapper = mapper;
        } 
         
        [HttpGet]

        public IActionResult GetTrails() 
        {

            var obj = _trailRepo.GetTrails();
            var objDto = new List<TrailDto>();

            foreach(var objj in obj)
            {

                objDto.Add(_mapper.Map<TrailDto>(objj) );

            }

            return Ok(objDto);
        }


        [HttpGet("{TrailId:int}", Name = "GetTrail")]

        public IActionResult GetTrail(int TrailId)
        {

            var obj = _trailRepo.GetTrail(TrailId);

            if (obj == null) { return NotFound(); }
             


            var objDto = _mapper.Map<TrailDto>(obj);





            return Ok(objDto);
        }

        [HttpGet("[action]/{nationalParkId:int}", Name = "GetTrailsInNationalPark")]

        public IActionResult GetTrailsInNationalPark(int nationalParkId)
        {

            var objList = _trailRepo.GetTrailsInNationalPark(nationalParkId);

            if (objList == null) { return NotFound(); }
            var objDtoList = new List<TrailDto>();
            foreach (var obj in objList) {
                 objDtoList.Add (_mapper.Map<TrailDto>(obj));


            }






            return Ok(objDtoList);
        }

        [HttpPost]

        public IActionResult CreateTrail([FromBody] TrailCreateDto trailDto)
        {

            if (trailDto == null)
            {

                return BadRequest(ModelState);
            }

            if (_trailRepo.TrailExist(trailDto.Name)) {

                ModelState.AddModelError("","Trail Exist");
                return StatusCode(404,ModelState);

            }

      


            var obj = _mapper.Map<Trail>(trailDto);

            if (!_trailRepo.CreateTrail(obj))
            {

                ModelState.AddModelError("", $"Something went worng when saving the record {obj.Name}");
                return StatusCode(500, ModelState);

            }
            return CreatedAtRoute("GetTrail",new { TrailId = obj.Id }, obj);
        
        
        
        }




        [HttpPatch("{TrailId:int}", Name = "UpdateTrail")]

        public IActionResult UpdateTrail(int TrailId, [FromBody] TrailUpdateDto trailDto)
        {
            if (trailDto == null || TrailId != trailDto.Id)
            {

                return BadRequest(ModelState);
            }

            /*       if (_trailRepo.TrailExist(TrailsDto.Name))
                   {
             
                       ModelState.AddModelError("", "Trail Exist");
                       return StatusCode(404, ModelState);

                   }
       */


            var obj = _mapper.Map<Trail>(trailDto);

            if (!_trailRepo.UpdateTrail(obj))
            {

                ModelState.AddModelError("", $"Something went worng when updating the record {obj.Name}");
                return StatusCode(500, ModelState);

            }
            return NoContent();

            //return CreatedAtRoute("GetTrail", new { TrailId = obj.Id }, obj);


        }




        [HttpDelete("{TrailId:int}", Name = "DeleteTrail")]

        public IActionResult DeleteTrail(int TrailId)
        {


            if (!_trailRepo.TrailExist(TrailId))
            {

                return NotFound();

            }



            var obj = _trailRepo.GetTrail(TrailId);

            if (!_trailRepo.DeleteTrail(obj))
            {

                ModelState.AddModelError("", $"Something went worng when deleting the record {obj.Name}");
                return StatusCode(500, ModelState);

            }
            return NoContent();

            //return CreatedAtRoute("GetTrail", new { TrailId = obj.Id }, obj);


        }


    }
}
