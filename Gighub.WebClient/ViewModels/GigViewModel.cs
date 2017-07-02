using Gighub.WebClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gighub.WebClient.ViewModels
{
    public class GigViewModel
    {
        public string Venue { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public byte Genre { get; set; }

        public SelectList Genres { get; set; }
        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", this.Date, this.Time));
            }
        }
    }
}
