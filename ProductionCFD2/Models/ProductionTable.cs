using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionCFD2.Models
{
    public class ProductionTable
    {
        [Key]
        [DisplayName("Production Id")]
        public int Production_Id { get; set; }

        [DisplayName("Production Date")]
        public DateTime Production_Date { get; set; }

        [DisplayName("Shift")]
        public int Shift_Id { get; set; }
        [ForeignKey("Shift_Id")]
        public Shift? Shift { get; set; }

        [DisplayName("Material")]
        public int Material_Id { get; set; }
        [ForeignKey("Material_Id")]
        public Material? Material { get; set; }

        [DisplayName("Material Number")]
        public string? Material_Number { get; set; }
        [ForeignKey("Material_Number")]

        [DisplayName("Input Batch")]
        public string? Input_Batch { get; set; }

        [DisplayName("Total Wt. (Kg)")]
        [Precision(18, 2)]
        public Decimal Total_Weight { get; set; }

        [DisplayName("Total I/P Qty.")]
        public int Total_Input { get; set; }

        [DisplayName("Rolling Plan Size")]
        public int Rolling_Plan_Size { get; set; }

        [DisplayName("Grinding Loss")]
        public int Grinding_Loss { get; set; }

        [DisplayName("Grinding Wheel")]
        public int Grinding_Wheel { get; set; }

        [DisplayName("End/Cut")]
        public int EndCut { get; set; }

        [DisplayName("Sample Loss")]
        public int Sample_Loss { get; set; }

        [DisplayName("Finish Wt. (Kg)")]
        [Precision(18, 2)]
        public Decimal Finish_Weight { get; set; }

        [DisplayName("Yield %")]
        [Precision(18, 2)]
        public Decimal Yield { get; set; }

        [DisplayName("Shift Incharge")]
        public int ShiftIncharge_Id { get; set; }
        [ForeignKey("ShiftIncharge_Id")]
        public ShiftIncharge? ShiftIncharge { get; set; }
    }
}
