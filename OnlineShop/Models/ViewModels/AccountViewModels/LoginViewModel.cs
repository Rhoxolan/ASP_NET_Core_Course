﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; } = default!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Display(Name = "Remember me")]
        public bool IsPersistent { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
