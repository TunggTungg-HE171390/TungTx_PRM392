namespace Slot3_CodeFirst.Db.Models
{
    public class PlayerInstrument
    {
        public int PlayerInstrumentId { get; set; }
        public int PlayerId { get; set; }

        public int InstrumentTypeId { get; set; }
        public string ModelName { get; set; }
        public string level {  get; set; }
    }
}
