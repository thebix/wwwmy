using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using wwwmy.Core.Interfaces;

namespace wwwmy.ViewComponents
{
    public class TestSharedViewComponent : ViewComponent
    {
        ICustomLogger _logger;
        public TestSharedViewComponent(ICustomLogger logger)
        {
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync(int someValue)
        {
            someValue += someValue;
            return View(someValue);
        }
    }
}