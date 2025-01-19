using BoatApp.Business.Operations.Feature;
using BoatApp.Business.Operations.Feature.Dtos;
using BoatApp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeateuresController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeateuresController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateFeature(AddFeatureRequest request)
        {
            var addFeatureDto = new AddFeatureDto
            {
                Title = request.Title,
                Description = request.Description
            };

            var result = await _featureService.AddFeature(addFeatureDto);
            if (result.IsSucceed)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}