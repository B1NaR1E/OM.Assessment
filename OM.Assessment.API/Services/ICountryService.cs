using OM.Assessment.API.Controllers;

namespace OM.Assessment.API.Services;

public interface ICountryService
{
    /// <summary>
    /// Gets a paginated list of countries.
    /// </summary>
    Task<PaginatedResponse> GetCountriesAsync(int page, int pageSize, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets a country's details by country name.
    /// </summary>
    Task<ApiResponse> GetCountryAsync(string name, CancellationToken cancellationToken);
}