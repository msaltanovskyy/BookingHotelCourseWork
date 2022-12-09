using BookingHotelCourseWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingHotelCourseWork.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.HasData(
                new Services {
                    ServicesId = 1,
                    Name = "Free-Wifi",
                    Description = "Free-Wifi"
                },
                new Services {
                    ServicesId = 2,
                    Name = "Сауна, басейн",
                    Description = "Сайуна, басейн"
                },
                new Services {
                    ServicesId = 3,
                    Name = "Конфирент-зал",
                    Description = "Конфирент-зал"
                },
                new Services
                {
                    ServicesId = 4,
                    Name = "Доставка",
                    Description = "Доставка"
                }
            );
        }

    }
}
