using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI.UnitTests
{
    public class PostCallbackTests
    {
        private readonly ThirdPartyController _sut;

        public PostCallbackTests()
        {
            _sut = new ThirdPartyController();
        }

        [Fact]
        public async Task given_a_valid_string_should_return_204_status_code()
        {
            var response = await _sut.PostCallback("My magic string");

            Assert.Equal(204, response.StatusCode);
        }
    }
}