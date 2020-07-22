using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;
using Xunit;

namespace WebAPI.UnitTests
{
    public class PostTests
    {
        public PostTests()
        {
            _sut = new ThirdPartyController();
        }

        private readonly ThirdPartyController _sut;

        [Fact]
        public async Task given_a_key_when_POSTed_should_return_200()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task given_a_key_when_POSTed_should_return_key()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            Assert.IsType<string>(response.Value);
            Assert.True(response.Value.ToString().Length > 0);
        }
    }
}