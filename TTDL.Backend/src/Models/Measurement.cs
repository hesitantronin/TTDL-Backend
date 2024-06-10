using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTDL_Backend.Models
{
    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; } // Primary key

        [Required]
        [MaxLength(50)]
        [ForeignKey("Chair")]
        public string ChairId { get; set; }

        [MaxLength(50)]
        [ForeignKey("Patient")]
        public string CurrentPatientId { get; set; }

        [Required]
        public List<int> Data { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public bool BatteryState { get; set; }

        public Chair Chair { get; set; } // Navigation property
        public Patient CurrentPatient { get; set; } // Navigation property
    }
}
