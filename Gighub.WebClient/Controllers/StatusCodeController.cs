using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.Controllers
{
    [Route("STATUS")]
    public class StatusCodeController : Controller
    {
        // 404
        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
