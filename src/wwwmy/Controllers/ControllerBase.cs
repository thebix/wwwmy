using Microsoft.AspNetCore.Mvc;

using wwwmy.Core.Interfaces;

namespace wwwmy.Controllers
{
    public class ControllerBase : Controller
    {
        protected ICustomLogger _Logger;

        public ControllerBase () { }

        public ControllerBase (ICustomLogger logger)
        {
            _Logger = logger;
        }
    }
}