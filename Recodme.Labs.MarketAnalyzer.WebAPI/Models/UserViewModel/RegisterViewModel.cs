using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.PersonViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Input the user name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Input the first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Input the last name")]
        public string LastName { get; set; }

        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "Input the birthdate")]
        public DateTime BirthDate { get; set; }   

        [Required(ErrorMessage = "Input the email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Input the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
