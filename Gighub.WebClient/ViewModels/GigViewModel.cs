﻿using Gighub.WebClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.ViewModels
{
    public class GigViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        //[FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public SelectList Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", this.Date, this.Time));
        }
    }
}
