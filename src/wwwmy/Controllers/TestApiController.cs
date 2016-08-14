using Microsoft.AspNetCore.Mvc;

using wwwmy.Interfaces.Repositories;
using wwwmy.DataLayer; 
using wwwmy.Models;

namespace wwwmy.Controllers
{
    [Route("api/[controller]")]
    public class TestApiController : ControllerBase
    {
        private readonly ITestRepo _testRepo;

        public TestApiController (ITestRepo testRepo) : base()
        {
            _testRepo = testRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var item = _testRepo.TestRepoMethod(id);
            if(null == item) {
                return NotFound();
            }

            var res = new TestViewModel{
                Key = @"Key is " + item,
                Name = @"Name is " + item
            };
            return new ObjectResult(res);
        }
    }
}