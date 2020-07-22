using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task given_a_key_when_POSTed_should_return_key()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            Assert.True(((OkObjectResult) response).Value.ToString().Length > 0);
        }

        [Fact]
        public async Task given_a_key_when_POSTed_should_return_Ok()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task given_a_key_when_POSTed_should_store_key_in_database()
        {
            var response = await _sut.Post(new PostBody("My magic string"));

            // TODO: get from db
        }
    }
}