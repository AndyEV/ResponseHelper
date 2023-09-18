using Microsoft.AspNetCore.Mvc;
using Response.Core;

namespace Response.Simulator.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ResponseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IResponse<WeatherForecast[]> GetArray()
        {
            return GetResponse();
        }

        [HttpGet]
        public ActionResult<WeatherForecast[]> GetAction()
        {
            return Response(GetResponse());
        }

        [HttpGet]
        public async Task<ActionResult> GetTaskActionAsync()
        {
            return Response(await GetResponseAsync());
        }

        [HttpGet]
        public ActionResult GetPaginatedAsync()
        {
            return Response(GetPaginatedResponseAsync(1, 10));
        }

        [HttpGet]
        public ActionResult FailedRequest()
        {
            return Response(FailObject());
        }


        [NonAction]
        public IResponse<WeatherForecast[]> GetResponse() 
        {
            return Response<WeatherForecast[]>.Success(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
        }

        [NonAction]
        public async Task<IResponse<WeatherForecast[]>> GetResponseAsync()
        {
            return await Response<WeatherForecast[]>.SuccessAsync(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
        }

        [NonAction]
        public PaginatedRespose<WeatherForecast> GetPaginatedResponseAsync(int pageNumber, int pageSize)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToPaginatedList(pageNumber, pageSize);
        }

        [NonAction]
        public IResponse FailObject()
        {
            return Core.Response.Fail("Fail request simulation");
        }
    }
}