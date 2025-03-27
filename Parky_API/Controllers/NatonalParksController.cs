using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parky_API.Models;
using Parky_API.Models.Dtos;
using Parky_API.Repository.IRepository;

namespace Parky_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "NatonalParks")]

    public class NatonalParksController : ControllerBase
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;

        public NatonalParksController(INationalParkRepository npRepo,IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetNatonalParks() 
        {

            var obj = _npRepo.GetNationalParks();
            var objDto = new List<NationalParkDto>();

            foreach(var objj in obj)
            {

                objDto.Add(_mapper.Map<NationalParkDto>(objj) );

            }

            return Ok(objDto);
        }


        [HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        [Authorize]

        public IActionResult GetNatonalPark(int nationalParkId)
        {

            var obj = _npRepo.GetNationalPark(nationalParkId);

            if (obj == null) { return NotFound(); }



            var objDto = _mapper.Map<NationalParkDto>(obj);





            return Ok(objDto);
        }


        [HttpPost]

        public IActionResult CreateNatonalPark([FromBody] NationalParkDto natonalParksDto){

            if (natonalParksDto==null)
            {

                return BadRequest(ModelState);
            }

            if (_npRepo.NationalParkExist(natonalParksDto.Name)) {

                ModelState.AddModelError("","Natonal Park Exist");
                return StatusCode(404,ModelState);

            }

      


            var obj = _mapper.Map<NationalPark>(natonalParksDto);

            if (!_npRepo.CreateNationalPark(obj))
            {

                ModelState.AddModelError("", $"Something went worng when saving the record {obj.Name}");
                return StatusCode(500, ModelState);

            }
            return CreatedAtRoute("GetNationalPark",new { nationalParkId = obj.Id }, obj);
        
        
        
        }




        [HttpPatch("{nationalParkId:int}", Name = "UpdateNatonalPark")]

        public IActionResult UpdateNatonalPark(int nationalParkId, [FromBody] NationalParkDto natonalParksDto)
        {
            if (natonalParksDto == null || nationalParkId != natonalParksDto.Id)
            {

                return BadRequest(ModelState);
            }

            /*       if (_npRepo.NationalParkExist(natonalParksDto.Name))
                   {

                       ModelState.AddModelError("", "Natonal Park Exist");
                       return StatusCode(404, ModelState);

                   }
       */


            var obj = _mapper.Map<NationalPark>(natonalParksDto);

            if (!_npRepo.UpdateNationalPark(obj))
            {

                ModelState.AddModelError("", $"Something went worng when updating the record {obj.Name}");
                return StatusCode(500, ModelState);

            }
            return NoContent();

            //return CreatedAtRoute("GetNationalPark", new { nationalParkId = obj.Id }, obj);


        }




        [HttpDelete("{nationalParkId:int}", Name = "DeleteNatonalPark")]

        public IActionResult DeleteNatonalPark(int nationalParkId)
        {


            if (!_npRepo.NationalParkExist(nationalParkId))
            {

                return NotFound();

            }



            var obj = _npRepo.GetNationalPark(nationalParkId);

            if (!_npRepo.DeleteNationalPark(obj))
            {

                ModelState.AddModelError("", $"Something went worng when deleting the record {obj.Name}");
                return StatusCode(500, ModelState);

            }
            return NoContent();

            //return CreatedAtRoute("GetNationalPark", new { nationalParkId = obj.Id }, obj);


        }


    }
}
