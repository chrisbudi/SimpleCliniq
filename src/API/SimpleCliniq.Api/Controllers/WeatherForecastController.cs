using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Infrastructure;

namespace SimpleCliniq.Controllers
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

        public IConfiguration _config;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet(Name = "connectionstring")]
        public async Task<IActionResult> Get()
        {
            // check database connected
            var connectionString = _config.GetValue<string>("DB_CONNECTION_STRING");
            var options = new DbContextOptionsBuilder<SimpleClinicContext>()
                .UseNpgsql(connectionString)
                .Options;

            try
            {
                using (var context = new SimpleClinicContext(options))
                {
                    await context.Database.OpenConnectionAsync();
                    await context.Database.CloseConnectionAsync();
                    return Ok("connected");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("not connected");
            }


        }

        //[HttpGet(Name = "ConnectionString")]
        //public async Task<IActionResult> GetConnectionString()
        //{

        //}
    }
}
