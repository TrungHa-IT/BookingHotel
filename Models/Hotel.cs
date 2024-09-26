using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public bool Avaiable { get; set; }
        [Required]
        public int Status { get; set; }
        //Fk: City
        //HotelImage
        //HotelPolicies
        //RoomID
        //FeedbackID
    }
}
