using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.UserViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Input your user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Input your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
