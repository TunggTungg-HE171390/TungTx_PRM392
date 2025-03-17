using Slot3_CodeFirst.Db.Models;
using Slot3_CodeFirst.DTO.PlayerInstrument;
using System.ComponentModel.DataAnnotations;

namespace Slot3_CodeFirst.DTO.Player
{
    public class CreatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
        public List<CreatePlayerInstrumentRequest> PlayerInstruments { get; set; }
    }
}
