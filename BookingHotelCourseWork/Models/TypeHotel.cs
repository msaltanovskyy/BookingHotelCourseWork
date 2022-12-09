using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("type_hotel")]
    public class TypeHotel
    {
        [Column("type_hotel_id")]
        public int TypeHotelId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
