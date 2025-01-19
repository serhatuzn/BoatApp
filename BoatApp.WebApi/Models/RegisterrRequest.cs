﻿using System.ComponentModel.DataAnnotations;

namespace BoatApp.WebApi.Models
{
    public class RegisterrRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
    }
}
