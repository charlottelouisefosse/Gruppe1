namespace Gruppe1.Models
{
    public class PollenResponse
    {
        public int ID { get; set; }

        public int DateInfoID { get; set; }
        public DateInfo? DateInfo { get; set; } // Navigering

        public int PlantInfoID { get; set; }
        public PlantInfo? PlantInfo { get; set; } // Navigering
    }
}