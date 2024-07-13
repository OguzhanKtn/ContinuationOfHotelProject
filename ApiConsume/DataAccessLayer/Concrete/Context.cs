using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>(entry =>
            {
                entry.ToTable("Rooms", tb => tb.HasTrigger("RoomIncrease"));
                entry.ToTable("Rooms", tb => tb.HasTrigger("RoomDecrease"));
            });

            builder.Entity<Staff>(entry => 
            {
                entry.ToTable("Staffs", tb => tb.HasTrigger("StaffIncrease"));
                entry.ToTable("Staffs", tb => tb.HasTrigger("StaffDecrease"));
            });

            builder.Entity<Guest>(entry =>
            {
                entry.ToTable("Guests", tb => tb.HasTrigger("GuestIncrease"));
                entry.ToTable("Guests", tb => tb.HasTrigger("GuestDecrease"));
            });
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Testimonial> Testimonials { get; set;}
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
    }
}
