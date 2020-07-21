using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyController : ControllerBase
    {
        [HttpPost]
        [Route("request")]
        public async Task<OkObjectResult> Post([FromBody] PostBody body)
        {
            return new OkObjectResult("Change Me");
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
            return new OkObjectResult(new GetBody());
        }
    }
}