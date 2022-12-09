using BookingHotelCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingHotelCourseWork.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User
            {
                Id = "1",
                UserName = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Name = "Admin",
                Lastmname = "Admin",
                Middlename = "Admin",
                PhoneNumber = "+380999999",
                BirthDay = DateTime.UtcNow,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var user2 = new User
            {
                Id = "2",
                UserName = "administrator@gmail.com",
                NormalizedEmail = "ADMINISTRATOR@GMAIL.COM",
                Email = "admininstrator@gmail.com",
                NormalizedUserName = "ADMINISTRATOR@GMAIL.COM",
                Name = "Administartor",
                Lastmname = "Administartor",
                Middlename = "Administartor",
                PhoneNumber = "+380999999",
                BirthDay = DateTime.UtcNow,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var user3 = new User
            {
                Id = "3",
                UserName = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                Email = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Name = "User",
                Lastmname = "User",
                Middlename = "User",
                PhoneNumber = "+380999999",
                BirthDay = DateTime.UtcNow,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, "Admin@1");
            user2.PasswordHash = hasher.HashPassword(user2, "Admin@1");
            user3.PasswordHash = hasher.HashPassword(user3, "Admin@1");
            builder.HasData(user, user2, user3);
        }
    }
}
