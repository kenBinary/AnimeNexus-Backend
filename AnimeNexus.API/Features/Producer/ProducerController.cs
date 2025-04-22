using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Features.Producer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Producer
{
    [ApiController]
    [Route("api/producers")]
    public class ProducerController : ControllerBase
    {

        private readonly IProducerService _producerService;
        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducers([FromQuery] ProducerSearchQueryParameters queryParameters)
        {
            var producerList = await _producerService.GetAnimeProducers(queryParameters);

            if (producerList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(producerList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducerById(int id)
        {
            var producerData = await _producerService.GetAnimeProducerById(id);

            if (producerData == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(producerData);
        }

    }
}