namespace OM.Assessment.API.Models;

public class Country
{
    public Name Name { get; set; }
    public string[] Tld { get; set; }
    public string Cca2 { get; set; }
    public string Ccn3 { get; set; }
    public string Cca3 { get; set; }
    public bool Independent { get; set; }
    public string Status { get; set; }
    public bool UnMember { get; set; }
    public string[] Capital { get; set; }
    public string[] AltSpellings { get; set; }
    public string Region { get; set; }
    public double[] Latlng { get; set; }
    public bool Landlocked { get; set; }
    public double Area { get; set; }
    public string Flag { get; set; }
    public int Population { get; set; }
    public string[] Timezones { get; set; }
    public string[] Continents { get; set; }
    public Flags Flags { get; set; }
    public string StartOfWeek { get; set; }
}

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
}
public class Flags
{
    public string Png { get; set; }
    public string Svg { get; set; }
}

