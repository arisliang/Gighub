using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.Models
{
    public class Attendance
    {
        [ForeignKey("Gig_")]
        public int GigId { get; set; }

        public Gig Gig_ { get; set; }

        [ForeignKey("Attendee")]
        public string AttendeeId { get; set; }

        public ApplicationUser Attendee { get; set; }
    }
}
