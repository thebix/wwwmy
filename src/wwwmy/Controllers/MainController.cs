using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wwwmy.Interfaces.Repositories;

namespace wwwmy.Controllers
{
    public class MainController : ControllerBase
    {
        //TODO: на async - await
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
