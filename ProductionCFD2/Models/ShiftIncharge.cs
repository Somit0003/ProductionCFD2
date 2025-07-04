using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductionCFD2.Models
{
    public class ShiftIncharge
    {
        [Key]
        [DisplayName("Shift Incharge Id")]
        public int ShiftIncharge_Id { get; set; }

        [DisplayName("Shift Incharge Name")]
        public string ShiftIncharge_Name { get; set; }
    }
}
