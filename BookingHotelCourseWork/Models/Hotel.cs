using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("hotel")]
    public class Hotel
    {
        [Column("hotel_id")]
        public int HotelId { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Введите название отеля")]
        [StringLength(100, ErrorMessage = "Максимальная длина 100 символов")]
        [Display(Name = "Название отеля")]
        public string Name { get; set; }

        [Column("country")]
        [Required(ErrorMessage = "Введите страну")]
        [StringLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Column("adress")]
        [Required(ErrorMessage = "Введите адресс")]
        [StringLength(100, ErrorMessage = "Максимальная длина 100 символов")]
        [Display(Name = "Адресс")]
        public string Adress { get; set; }

        [Column("number_rooms")]
        [Required(ErrorMessage = "Введите коло-во комнат")]
        [Display(Name = "Коло-во комнат")]
        public int NumberRooms { get; set; }

        [Column("raiting")]
        [Required(ErrorMessage = "Выберите рейтинг")]
        [Display(Name = "Рейтинг")]
        public int RaitingId { get; set; }
        public Raiting Raiting { get; set; }

        [Column("type_hotel")]
        [Required(ErrorMessage = "Выберите тип отеля")]
        [Display(Name = "Тип отеля")]
        public int TypeHotelId { get; set; }
        public TypeHotel TypeHotel { get; set; }

        [Column("number_phone")]
        [Required(ErrorMessage = "Введите номер телефона")]
        [StringLength(15, ErrorMessage = "Максимальная длина 15 символов")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Введите почту")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Column("administrator")]
        [Required(ErrorMessage = "Выберите администратора отеля")]
        [Display(Name = "Администратор")]
        public string UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Rooms> rooms { get; set; }
    }
}
