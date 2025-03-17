namespace Slot3_CodeFirst.DTO.PlayerInstrument
{
    public class CreatePlayerInstrumentRequest
    {
        public int PlayerId { get; set; }
        public int InstrumentTypeId { get; set; }
        public string ModelName { get; set; }
        public string Level {  get; set; }
    }
}
