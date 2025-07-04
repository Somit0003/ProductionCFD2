using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductionCFD2.Models
{
    public class Shift
    {
        [Key]
        [DisplayName("Shift Id")]
        public int Shift_Id { get; set; }

        [DisplayName("Shift Name")]
        public string Shift_Name { get; set; }
    }
}
