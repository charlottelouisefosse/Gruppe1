using System.Collections.Generic;

namespace Gruppe1.Models.PollenAPI

{
    public class PollenAPIResponse
    {
        public required List<PollenDay> dailyInfo { get; set; }
    }

    public class PollenDay
    {
        public required DateObj date { get; set; }
        public required List<PollenTypeInfo> pollenTypeInfo { get; set; }
        public required List<PlantInfo> plantInfo { get; set; }
    }

    public class DateObj
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }

    public class PollenTypeInfo
    {
        public string? code { get; set; }
        public string? displayName { get; set; }
        public bool? inSeason { get; set; }
        public IndexInfo? indexInfo { get; set; }
        public List<string>? healthRecommendations { get; set; }
    }

    public class IndexInfo
    {
        public string? code { get; set; }
        public string? displayName { get; set; }
        public int value { get; set; }
        public string? category { get; set; }
        public string? indexDescription { get; set; }
        public ColorInfo? color { get; set; }
    }

    public class ColorInfo
    {
        public float? red { get; set; }
        public float? green { get; set; }
        public float? blue { get; set; }
    }

    public class PlantInfo
    {
        public string? code { get; set; }
        public string? displayName { get; set; }
    }

}