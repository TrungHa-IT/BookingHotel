﻿using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Extras
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime? Created_at { get; set; }
    }
}
