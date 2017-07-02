using Gighub.WebClient.Data;
using Gighub.WebClient.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var vm = new GigViewModel
            {
                Genres = new SelectList(_context.Genres.ToList(), "Id", "Name")
            };

            return View(vm);
        }
    }
}
