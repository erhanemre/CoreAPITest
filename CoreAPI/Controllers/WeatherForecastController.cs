using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.DataBase.Entities;
using CoreAPI.DataBase.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITestService testService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestService testService)
        {
            _logger = logger;
            this.testService = testService;
        }

        [HttpGet]
        public async Task<ActionResult<TempTable1>> Get()
        {
            var result = await testService.Query1();
            return Ok(result);
        }
    }
}
