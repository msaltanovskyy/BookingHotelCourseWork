using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("user")]
    public class User : IdentityUser
    {
        [Column("name")]
        [Display(Name = "Имя")]
        [StringLength(20, ErrorMessage = "Максимальная длина 20")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Column("lastname")]
        [Display(Name = "Фамилия")]
        [StringLength(20, ErrorMessage = "Максимальная длина 20")]
        public string Lastmname { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Column("middlename")]
        [Display(Name = "Отчество")]
        [StringLength(20, ErrorMessage = "Максимальная длина 20")]
        public string Middlename { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Номер телефона")]
        [StringLength(20, ErrorMessage = "Максимальная длина 15")]
        public override string PhoneNumber { get; set; }

        [Column("birthday")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime BirthDay { get; set; }
    }
}
