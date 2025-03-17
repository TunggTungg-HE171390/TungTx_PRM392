using System.ComponentModel.DataAnnotations;

namespace Slot3_CodeFirst.DTO.Player
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }

    }
}
