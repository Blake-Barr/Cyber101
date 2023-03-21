using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WatchfulEye.ViewModels
{
    public class EditLoginViewModel
    {
        [Display(Name = "Email address")]
        public string? EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Display(Name = "Username")]
        public string? Username { get; set; }
    }
}
