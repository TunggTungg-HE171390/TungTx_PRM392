using System.ComponentModel.DataAnnotations;

namespace PT2.DTO.InstrumentType
{
    public class CreateInstrumentTypeRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
