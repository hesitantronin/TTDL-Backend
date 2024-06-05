using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTDL_Backend.Models
{
    public class Chair
    {
        [Key]
        [MaxLength(50)]
        public string ChairId { get; set; }

        [MaxLength(50)]
        public string PatientId { get; set; }

        public bool BatteryState { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        public ICollection<Measurement> Measurements { get; set; }
    }
}
