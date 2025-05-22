namespace Gruppe1.Models
{
    public class IndexInfo
    {
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
        public int Value { get; set; }
        public string? Category { get; set; }
        public string? IndexDescription { get; set; }

        public int ColorInfoID { get; set; }
        public ColorInfo? ColorInfo { get; set; }
    }
}