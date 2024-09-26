using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int PeopleAvaible { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Status { get; set; }
        //Fk: TypePeopleID
        //CategoriesID
    }
}
