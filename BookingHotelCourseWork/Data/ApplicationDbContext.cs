using BookingHotelCourseWork.Configuration;
using BookingHotelCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelCourseWork.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<Service_Hotel> serviceHotels { get; set; }
        public DbSet<TypeHotel> typeHotels { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Raiting> raitings { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<Booking> bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().ToTable("users");
            builder.Entity<IdentityRole>().ToTable("role");
            builder.Entity<IdentityUserRole<string>>().ToTable("users_role");
            builder.Entity<IdentityUserToken<string>>().ToTable("users_token");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("role_claim");
            builder.Entity<IdentityUserClaim<string>>().ToTable("user_claim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("user_login");

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new ClassConfiguration());
            builder.ApplyConfiguration(new RaitingConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new TypeHotelConfiguration());
        }


    }
}