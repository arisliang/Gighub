using Gighub.WebClient.Data;
using Gighub.WebClient.Models;
using Gighub.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var vm = new GigViewModel
            {
                Genres = new SelectList(_context.Genres.ToList(), "Id", "Name")
            };

            return View(vm);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GigViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Genres = new SelectList(_context.Genres.ToList(), "Id", "Name");

                return View("Create", vm);
            }

            var artist = _context.Users.Single(u => u.UserName == User.Identity.Name);

            var model = new Gig
            {
                ArtistId = artist.Id,
                Date = vm.GetDateTime(),
                GenreId = vm.Genre,
                Venue = vm.Venue
            };

            _context.Gigs.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
