﻿using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
