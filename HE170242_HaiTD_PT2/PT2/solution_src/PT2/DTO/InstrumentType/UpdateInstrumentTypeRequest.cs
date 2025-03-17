using System.ComponentModel.DataAnnotations;

namespace PT2.DTO.InstrumentType
{
    public class UpdateInstrumentTypeRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
