﻿using Microsoft.AspNetCore.Mvc;

namespace AnimeGraphExploration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5)
            .ToArray();
        }
    }
}