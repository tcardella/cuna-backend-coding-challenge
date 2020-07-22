using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Xunit;

namespace WebAPI.UnitTests
{
    public class GetCallbackTests : BaseTests
    {
        [Fact]
        public async Task given_a_valid_string_should_return_204_status_code()
        {
            var response = await _sut.Get(""); // TODO: Figure out what id should be here

            Assert.IsType<OkObjectResult>(response);

            var data = (GetBody) ((OkObjectResult)response).Value;
            Assert.NotNull(data.Status);
            Assert.NotNull(data.Detail);
            Assert.NotNull(data.Body);
        }
    }
}