using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("service_hotel")]
    public class Service_Hotel
    {
        [Column("service_hotel_id")]
        public int Service_HotelId { get; set; }
        [Column("hotel_id")]
        [Display(Name = "Индитификатор отеля")]
        public int HotelId { get; set; }
        [Column("service_id")]
        [Display(Name = "Индитификатор сервиса")]
        public int ServiceId { get; set; }
    }
}
