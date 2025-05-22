using System.Collections.Generic;

namespace Gruppe1.Models.PollenAPI
{
    public class PollenAPIResponse
    {
        public List<dailyInfo>? dailyInfo { get; set; }
    }

    public class dailyInfo
    {
        public string? date { get; set; }
        public string? pollenType { get; set; }
        public int index { get; set; }
    }
}