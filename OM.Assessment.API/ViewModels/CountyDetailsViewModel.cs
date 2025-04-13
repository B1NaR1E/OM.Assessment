using OM.Assessment.API.Models;

namespace OM.Assessment.API.ViewModels;

public class CountyDetailsViewModel
{
    public string Name { get; set; }
    public string Flag { get; set; }
    public string Capital { get; set; }
    public int Population { get; set; }

    public CountyDetailsViewModel(string name, string flag, string capital, int population)
    {
        Name = name;
        Flag = flag;
        Capital = capital;
        Population = population;
    }

    public static CountyDetailsViewModel FromCountry(Country country)
    {
        return new CountyDetailsViewModel(country.Name.Common, country.Flags.Svg, country.Capital.First(), country.Population);
    }
}