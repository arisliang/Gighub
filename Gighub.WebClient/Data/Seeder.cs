using Gighub.WebClient.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.Data
{
    public class Seeder
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public Seeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            // user
            if (await _userManager.FindByEmailAsync("user1@gmail.com") == null)
            {
                await _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "user1",
                    Email = "user1@gmail.com"
                }, "P@ssw0rd01!");
            }

            // genre
            if (!_context.Genres.Any())
            {
                _context.Genres.Add(new Models.Genre()
                {
                    Id = 1,
                    Name = "Jazz"
                });
                _context.Genres.Add(new Models.Genre()
                {
                    Id = 2,
                    Name = "Blues"
                });
                _context.Genres.Add(new Models.Genre()
                {
                    Id = 3,
                    Name = "Rock"
                });
                _context.Genres.Add(new Models.Genre()
                {
                    Id = 4,
                    Name = "Country"
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
