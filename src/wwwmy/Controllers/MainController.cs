using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wwwmy.Interfaces.Repositories;

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
            return View();
        }
    }
}
