using Microsoft.AspNetCore.Mvc;
using AnimeGraphExploration.Services;

namespace AnimeGraphExploration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeGraphController : ControllerBase
    {
        private readonly IAnimeGraphService _animeGraphService;

        public AnimeGraphController(IAnimeGraphService animeGraphService)
        {
            _animeGraphService = animeGraphService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var animeGraph = await _animeGraphService.GetAnimeGraph(id);
                return Ok(animeGraph);
            } catch (Exception e)
            {
                return BadRequest(e.Message); // todo
            }
        }
    }
}
