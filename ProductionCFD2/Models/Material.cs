using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductionCFD2.Models
{
    public class Material
    {
        [Key]
        public int Material_Id { get; set; }
        [Required]
        [DisplayName("Material Number")]
        public required string Material_Number { get; set; }
    }
}
