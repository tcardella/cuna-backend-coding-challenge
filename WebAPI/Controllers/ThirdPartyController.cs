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
        private readonly RequestContext _context;

        public ThirdPartyController(RequestContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("request")]
        public async Task<ActionResult> Post([FromBody] PostBody body)
        {
            if (body?.Body == null)
                return BadRequest("No object named 'body' could be found.");

            // TODO: I'm not sure this url is correct. Also, this url should be stored in a settings file so that it can be updated as needed.
            var url = @"https://urldefense.proofpoint.com/v2/url?u=http-3A__example.com_request&d=DwIGAg&c=iWzD8gpC8N4xSkOHZBDmCw&r=R0U6eziUSfkIiSy6xlVVHEbyT-5CVX85B2177L6G3Po&m=yeOGbdLEit9cyYWgLXxv5PRcMgRiallgPowRbt59hFw&s=lZ8qcf2Nw6VP2qI311Xp3wnZgZDhuaIrUg7krpQgTr4&e= ";

            var data = new
            {
                body = body.Body,
                callback = "/callback"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(data));
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string requestId;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, stringContent);

                if (!response.IsSuccessStatusCode)
                    return BadRequest("An exception occurred while communicating with the third party service.");

                requestId = await response.Content.ReadAsStringAsync();
            }

            try
            {
                await _context.Requests.AddAsync(new Request(requestId));
                await _context.SaveChangesAsync();

                return new OkObjectResult(requestId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("callback")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> PostCallback(string body)
        {
            var requestId = ""; // TODO: Where does this come from? Is it in a header from the Third Party Service? Should this REST API be stateful? Is this what body should be?

            var request = await _context.Requests.SingleOrDefaultAsync(r => r.Id == requestId);

            if (request == null)
                return NotFound($"A request with the id '{requestId}' could not be found.");

            request.Body = body;

            try
            {
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("callback")]
        [ProducesResponseType(204)]
        public async Task<NoContentResult> PutCallback([FromBody] PutBody body)
        {
            // TODO: load request log and append status update

            return NoContent();
        }

        [HttpGet]
        [Route("status/{id}")]
        public async Task<OkObjectResult> Get(Guid id)
        {
            // TODO: load request log and return it.

            return new OkObjectResult(new GetBody("status", "detail", "body"));
        }
    }
}