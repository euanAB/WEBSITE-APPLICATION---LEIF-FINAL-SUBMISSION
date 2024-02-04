using System.ComponentModel.DataAnnotations;

namespace Leif_Gym_Manager.Models
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
