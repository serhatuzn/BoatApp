using BoatApp.Business.Operations.Boats.Dtos;
using BoatApp.Business.Operations.NewFolder;
using BoatApp.WebApi.ActionFilter;
using BoatApp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatsController : ControllerBase
    {
        private readonly IBoatService _boatService;

        public BoatsController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoat(int id)
        {

            var boat = await _boatService.GetBoat(id);

            if (boat == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(boat);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoats()
        {
            var boats = await _boatService.GetAllBoats();
            return Ok("Boats");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBoat(AddBoatRequest request)
        {
            var addBoatDto = new AddBoatDto
            {
                Name = request.Name,
                BoatType = request.BoatType,
                Location = request.Location,
                Length = request.Length,
                Capacity = request.Capacity,
                ManufactureYear = request.ManufactureYear
            };

            var result = await _boatService.AddBoatDto(addBoatDto);

            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }

        [HttpPatch("{id}/capacity")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateBoatCapacity(int id, int changeBy)
        {
            var result = await _boatService.UpdateBoatCapacity(id, changeBy);
            if (!result.IsSucceed)
            {
                return NotFound();
            }
            else
            {
                return Ok(result.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteBoat(int id)
        {
            var result = await _boatService.DeleteBoat(id);
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [TimeControlFilter]
        public async Task<IActionResult> UpdateBoat(int id, UpdateBoatRequest request)
        {
            var updateBoatDto = new UpdateBoatDto
            {
                Id = id,
                Name = request.Name,
                BoatType = request.BoatType,
                Location = request.Location,
                Length = request.Length,
                Capacity = request.Capacity,
                ManufactureYear = request.ManufactureYear
            };

            var result = await _boatService.UpdateBoat(updateBoatDto);
            
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }

        }
    }
}
