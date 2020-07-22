using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Xunit;

namespace WebAPI.UnitTests
{
    public class PostTests : BaseTests
    {
        [Fact]
        public async Task given_a_body_when_POSTed_should_return_key()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            Assert.True(((OkObjectResult) response).Value.ToString().Length > 0);
        }

        [Fact]
        public async Task given_a_body_when_POSTed_should_return_Ok()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task given_a_body_when_POSTed_should_store_key_in_database()
        {
            var id = ""; // TODO: What value should be here?
            var response = await _sut.Post(new PostBody("My magic string"));

            var request = await _context.Requests.SingleOrDefaultAsync(r => r.Id == id);

            Assert.NotNull(request);
        }
    }
}