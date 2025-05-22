using System.ComponentModel.DataAnnotations;

namespace Gruppe1.Models
{
    public class PollenRegistering
    {
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string? TypeOfPollen { get; set; }

        [Range(0, 2000)] // NAAF sine sider indikerer 1000+ som høyeste nivå, har satt 2000 for å fange eventuelle verdier over dette
        public int Level { get; set; }
        // Legg til flere egenskaper etter behov
    }
}