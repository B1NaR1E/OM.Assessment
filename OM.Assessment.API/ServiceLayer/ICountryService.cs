using OM.Assessment.API.ViewModels;

namespace OM.Assessment.API.ServiceLayer;

public interface ICountryService
{
    /// <summary>
    /// Gets a paginated list of countries.
    /// </summary>
    Task<IEnumerable<CountryViewModel>> GetCountriesAsync(int page, int pageSize, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets a country's details by country name.
    /// </summary>
    Task<CountyDetailsViewModel> GetCountryAsync(string name, CancellationToken cancellationToken);
}