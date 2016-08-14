using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using wwwmy.Interfaces.Repositories;
using wwwmy.DataLayer; 
using wwwmy.Models;
using wwwmy.Config;


namespace wwwmy.Controllers
{
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepo _testRepo;
        private readonly TestConfig _options;


        public TestController (ITestRepo testRepo, IOptions<TestConfig> optionsAccessor) : base()
        {
            _testRepo = testRepo;
            if(optionsAccessor != null)
                _options = optionsAccessor.Value; //Test Options
            else
                _options = new TestConfig(); 
        }

        // [HttpGet]
        // public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpGet("{id?}")]
        public IActionResult GetById(string id)
        {

            return View("Index", new TestViewModel{
                Name = id,
                Key = id,
                IsComplete = true,
                Options = _options
            });
        }
    }
}