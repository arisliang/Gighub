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

        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedDataAsync()
        {
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
