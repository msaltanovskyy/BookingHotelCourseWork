using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("booking")]
    public class Booking
    {
        [Column("booking_id")]
        public int BookingId { get; set; }
        [Column("room_id")]
        [Display(Name = "Индитификатор комнаты")]
        public int RoomId { get; set; }
        public  Rooms room { get; set; }
        [Column("user_id")]
        [Display(Name = "Индитификатор пользователя")]
        public string UserId{ get; set; }
        public User user { get; set; }
        [Column("date_start")]
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [Column("date_end")]
        [Display(Name = "Дата конца")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

    }
}
