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
        [ForeignKey("Patient")]
        public string? CurrentPatientId { get; set; }

        public bool LowBattery { get; set; } = true;

        public ulong WeightTreshhold { get; set; }

        // Navigation property to access the current patient 
        public Patient CurrentPatient { get; set; } // Navigation property

        // Navigation property to access measurements associated with this chair
        public ICollection<Measurement> Measurements { get; set; }
    }
}
