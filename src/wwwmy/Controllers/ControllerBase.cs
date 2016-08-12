using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using wwwmy.Core.Interfaces;

namespace wwwmy.Controllers
{
    //TODO: возможно, нельзя, т.к. нативный класс
    public class ControllerBase : Controller
    {
        protected ICustomLogger _Logger;

        public ControllerBase ()
        {
          
        }

        public ControllerBase (ICustomLogger logger)
        {
            _Logger = logger;
        }
    }
}