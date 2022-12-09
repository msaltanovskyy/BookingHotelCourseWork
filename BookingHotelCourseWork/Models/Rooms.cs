using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("room")]
    public class Rooms
    {
        [Column("room_id")]
        public int RoomsId { get; set; }
        [Column("class_id")]
        [Display(Name = "Класс комнаты")]
        [Required(ErrorMessage = "Введите класс комнаты")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [Column("hotel_id")]
        [Display(Name = "отель")]
        [Required(ErrorMessage = "Выберите отель")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Column("price")]
        [Display(Name = "Цена")]
        [Range(1, 999999, ErrorMessage = "Диапазон от 1 до 999999")]
        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }
        [Column("chair")]
        [Display(Name = "Коло-во мест")]
        [Range(1,20,ErrorMessage = "Диапазон от 1 до 20")]
        [Required(ErrorMessage = "Введите коло-во мест")]
        public int Chair { get; set; }
        [Column("desc")]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание комнаты")]
        [StringLength(500, ErrorMessage = "Максимальная длина 500 символов")]
        public string Description { get; set; }
        [Column("status")]
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Выберите статус")]
        public bool isStatus { get; set; }

    }
}
