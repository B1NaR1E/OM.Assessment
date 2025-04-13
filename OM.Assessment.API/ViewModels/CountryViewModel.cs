using OM.Assessment.API.Models;

namespace OM.Assessment.API.ViewModels;

public class CountryViewModel(string name, string flag)
{
    public string Name { get; set; } = name;
    public string Flag { get; set; } = flag;

    public static CountryViewModel FromCountry(Country country)
    {
        return new CountryViewModel(country.Name.Common, country.Flags.Svg);
    }
    
    public static IEnumerable<CountryViewModel> FromCountry(IEnumerable<Country> countries)
    {
        var result = new List<CountryViewModel>();

        foreach (var country in countries)
        {
            result.Add(CountryViewModel.FromCountry(country));
        }
        
        return result;
    }
}