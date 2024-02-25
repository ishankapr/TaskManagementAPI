using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please set username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please set password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
