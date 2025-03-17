using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? CompanyName { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(50)]
        public string? Country { get; set; }
        [StringLength(30)]
        public string? Passsword { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
