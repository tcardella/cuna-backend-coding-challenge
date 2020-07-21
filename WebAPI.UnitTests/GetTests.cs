using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;
using Xunit;

namespace WebAPI.UnitTests
{
    public class PutCallbackTests
    {
        private readonly ThirdPartyController _sut;

        public PutCallbackTests()
        {
            _sut = new ThirdPartyController();
        }

        [Fact]
        public async Task given_a_valid_string_should_return_204_status_code()
        {
            var response = await _sut.PutCallback(new PutBody("My Status", "My Detail"));

            Assert.Equal(204, response.StatusCode);
        }
    }
}