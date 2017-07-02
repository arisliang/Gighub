using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gighub.WebClient.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gighub.WebClient.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Attendance>(a =>
            {
                a.HasKey(c => new { c.GigId, c.AttendeeId });
            });
            builder.Entity<Attendance>()
                .HasOne(a => a.Gig_)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
