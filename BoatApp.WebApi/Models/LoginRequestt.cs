﻿using System.ComponentModel.DataAnnotations;

namespace BoatApp.WebApi.Models
{
    public class LoginRequestt
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
