using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyController : ControllerBase
    {
        [HttpPost]
        [Route("request")]
        public async Task<ActionResult> Post([FromBody] PostBody body)
        {
            if (body?.Body == null)
                return BadRequest("No object named 'body' could be found.");

            var url = @"https://urldefense.proofpoint.com/v2/url?u=http-3A__example.com_request&d=DwIGAg&c=iWzD8gpC8N4xSkOHZBDmCw&r=R0U6eziUSfkIiSy6xlVVHEbyT-5CVX85B2177L6G3Po&m=yeOGbdLEit9cyYWgLXxv5PRcMgRiallgPowRbt59hFw&s=lZ8qcf2Nw6VP2qI311Xp3wnZgZDhuaIrUg7krpQgTr4&e= """;

            var data = new
            {
                body = body.Body,
                callback = "/callback"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(data));
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            var response = await client.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode)
            {
                var requestId = await response.Content.ReadAsStringAsync();

                // TODO: add requestId to DB

                return new OkObjectResult(requestId);
            }

            return BadRequest("An exception occurred while communicating with the third party service.");
        }

        [HttpPost]
        [Route("callback")]
        [ProducesResponseType(204)]
        public async Task<NoContentResult> PostCallback(string body)
        {
            return NoContent();
        }

        [HttpPut]
        [Route("callback")]
        [ProducesResponseType(204)]
        public async Task<NoContentResult> PutCallback([FromBody] PutBody body)
        {
            return NoContent();
        }

        [HttpGet]
        [Route("status/{id}")]
        public async Task<OkObjectResult> Get(Guid id)
        {
            return new OkObjectResult(new GetBody("status", "detail", "body"));
        }
    }
}