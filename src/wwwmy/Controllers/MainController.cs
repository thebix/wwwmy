using Microsoft.AspNetCore.Mvc;

using wwwmy.Core.Interfaces;


namespace wwwmy.Controllers
{
    public class MainController : ControllerBase
    {
        public MainController (ICustomLogger logger) : base(logger)
        {
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index.React");
        }
    }
}
