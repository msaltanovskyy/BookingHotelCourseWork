using BookingHotelCourseWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingHotelCourseWork.Configuration
{
    public class TypeHotelConfiguration : IEntityTypeConfiguration<TypeHotel>
    {
        public void Configure(EntityTypeBuilder<TypeHotel> builder)
        {
            builder.HasData(
                new TypeHotel { 
                    TypeHotelId = 1,
                    Name = "Гостиница или отель",
                    Description = "Отели, которые располагаются в городской черте и предлагают широкий набор услуг. " +
                    "В них останавливаются во время экскурсионного тура или бизнес-поездок."
                },
                new TypeHotel {
                    TypeHotelId = 2,
                    Name = "Апартаменты и апарт-отели",
                    Description = "Апартаменты представляют собой квартиры, иногда небольшие домики, виллы или половину дома с отдельным входом, " +
                    "которые сдаются в аренду туристам на разный срок."
                },
                new TypeHotel {
                    TypeHotelId = 3,
                    Name = "Бизнесс-отели",
                    Description = "Отели, специализирующиеся на обслуживании деловых поездок, проведении конференций " +
                    "и деловых выездных мероприятий, когда гостям нужно предоставить места для заседаний и переговоров. " +
                    "Обычно содержат один или несколько конференц-залов, могут содержать комнаты для переговоров и встреч."
                }
            );
        }
    }
}
