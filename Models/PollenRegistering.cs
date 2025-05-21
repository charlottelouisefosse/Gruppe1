namespace Gruppe1.Models
{
    public class PollenRegistering
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string? PlantName { get; set; }
        public int Amount { get; set; }
        // Legg til flere egenskaper etter behov
    }
}