using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;
using Xunit;

namespace WebAPI.UnitTests
{
    public class GetCallbackTests
    {
        public GetCallbackTests()
        {
            _sut = new ThirdPartyController();
        }

        private readonly ThirdPartyController _sut;

        [Fact]
        public async Task given_a_valid_string_should_return_204_status_code()
        {
            var response = await _sut.Get(Guid.NewGuid());

            Assert.Equal(200, response.StatusCode);

            var data = (GetBody) response.Value;
            Assert.NotNull(data.Status);
            Assert.NotNull(data.Detail);
            Assert.NotNull(data.Body);
        }
    }
}