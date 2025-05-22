namespace Gruppe1.Models.PollenAPI
{
    public class ViewModelPollen
    {
        public int ID { get; set; }
        public string? Date { get; set; }
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
        public int Value { get; set; }
        public string? Category { get; set; }
        public string? IndexDescription { get; set; }
        public string? ColorHex { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }
}