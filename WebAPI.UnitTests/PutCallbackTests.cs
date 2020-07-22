using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Xunit;

namespace WebAPI.UnitTests
{
    public class PutCallbackTests : BaseTests
    {
        [Fact]
        public async Task given_a_valid_PutBody_should_return_NoContentResult()
        {
            var response = await _sut.PutCallback(new PutBody("My Status", "My Detail"));

            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task given_a_valid_PutBody_should_store_changes_in_db()
        {
            var id = ""; // TODO: What should id be?

            var response = await _sut.PutCallback(new PutBody("My Status", "My Detail"));

            var request = await _context.Requests.SingleOrDefaultAsync(r => r.Id == id);

            Assert.NotNull(request);
        }
    }
}