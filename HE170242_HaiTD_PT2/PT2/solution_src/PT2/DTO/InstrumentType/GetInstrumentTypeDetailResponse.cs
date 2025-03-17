using Slot3_CodeFirst.DTO.PlayerInstrument;

namespace PT2.DTO.InstrumentType
{
    public class GetInstrumentTypeDetailResponse
    {
        public int InstrumentTypeId { get; set; }
        public string Name { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstrument { get; set; }
    }
}
