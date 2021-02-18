using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Security.Controllers
{
    public class LoginModel
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }
    }
}