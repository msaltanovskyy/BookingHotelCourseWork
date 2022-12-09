using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelCourseWork.Models
{
    [Table("class_room")]
    public class Class
    {
        [Column("class_id")]
        public int ClassId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
