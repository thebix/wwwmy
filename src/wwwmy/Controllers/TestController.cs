using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using wwwmy.Interfaces.Repositories;
using wwwmy.ViewModels;
using wwwmy.Config;


namespace wwwmy.Controllers
{
    //[Route("[controller]/[action]")]
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

        [Route("[action]")]
        public IActionResult Test()
        {
            return View("Index", new TestViewModel{
                Name = "TEST action",
                Key = "TEST action",
                IsComplete = true,
                Options = _options
            });
        }
    }
}