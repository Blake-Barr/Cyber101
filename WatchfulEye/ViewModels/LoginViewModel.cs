using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WatchfulEye.ViewModels
{
    public class LoginViewModel
    {
        [Display (Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
