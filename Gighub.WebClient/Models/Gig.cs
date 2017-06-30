﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Artist { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Genre Genre_ { get; set; }
    }
}