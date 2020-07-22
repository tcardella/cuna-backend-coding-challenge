using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;

namespace WebAPI.UnitTests
{
    public abstract class BaseTests
    {
        protected readonly ThirdPartyController _sut;
        protected readonly RequestContext _context;

        protected BaseTests()
        {
            _context = new RequestContext(new DbContextOptionsBuilder<RequestContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

            _sut = new ThirdPartyController(_context);
        }
    }
}