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
        public string ChairId { get; set; }

        [MaxLength(50)]
        public string CurrentPatientId { get; set; }

        [Required]
        public List<int> Data { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public bool BatteryState { get; set; }

        [ForeignKey(nameof(ChairId))]
        public Chair Chair { get; set; }

        [ForeignKey(nameof(CurrentPatientId))]
        public Patient CurrentPatient { get; set; }
    }
}
