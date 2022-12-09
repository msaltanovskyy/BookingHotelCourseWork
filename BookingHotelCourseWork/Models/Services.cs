using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("services")]
    public class Services
    {
        [Column("services_id")]
        public int ServicesId { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Название услуги")]
        [StringLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        [Display(Name = "Название услуги")]
        public string Name { get; set; }
        [Column("description")]
        [Required(ErrorMessage = "Введите описание услуги")]
        [StringLength(500, ErrorMessage = "Максимальная длина 500 символов")]
        [Display(Name = "Описание услуги")]
        public string Description { get; set; }
    }
}
