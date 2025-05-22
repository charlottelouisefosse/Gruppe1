namespace Gruppe1.Models
{
    public class DateInfo
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public ICollection<PollenResponse>? PollenResponses { get; set; }
    }
}