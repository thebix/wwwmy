using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wwwmy.Core.Interfaces;

namespace wwwmy.Controllers
{
    public class ErrorController : Controller
    {
        ICustomLogger _logger;
        public ErrorController (ICustomLogger logger)
        { 
            _logger = logger;
        }

        [Route("/Error")]
        public IActionResult Index()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if(error != null)
            {
                _logger.LogException(error.Error);
            }
            return View();
        }
    }
}