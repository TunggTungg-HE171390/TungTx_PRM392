using Slot3_CodeFirst.DTO.PlayerInstrument;

namespace Slot3_CodeFirst.DTO.Player
{
    public class GetPlayerDetailResponse
    {
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstrument {  get; set; }
    }
}
