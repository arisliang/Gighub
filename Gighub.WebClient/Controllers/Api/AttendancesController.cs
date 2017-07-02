using Gighub.WebClient.Data;
using Gighub.WebClient.Dtos;
using Gighub.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.Controllers.Api
{
    [Route("Api/[controller]")]
    //[Authorize]
    public class AttendancesController : Controller
    {
        private ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Attend")]
        [HttpPost]
        public async Task<IActionResult> Attend(AttendanceCreateDTO dto)
        {
            var user = _context.Users.Single(u => u.UserName == User.Identity.Name);

            if (_context.Attendances.Any(a => a.GigId == dto.GigId && a.AttendeeId == user.Id))
            {
                return BadRequest("The attendance already exists");
            }

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = user.Id
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
