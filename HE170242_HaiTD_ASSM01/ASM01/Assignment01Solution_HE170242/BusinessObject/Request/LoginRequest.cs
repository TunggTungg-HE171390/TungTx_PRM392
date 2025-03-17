using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Request
{
    public class LoginRequest
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
