using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace WebAPI.UnitTests
{
    public class PostCallbackTests : BaseTests
    {
        [Fact]
        public async Task given_a_valid_string_should_return_204_status_code()
        {
            var response = await _sut.PostCallback("My magic string");

            Assert.IsType<NoContentResult>(response);
        }
    }
}