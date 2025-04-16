using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OM.Assessment.API.Configs;
using OM.Assessment.API.Controllers;
using OM.Assessment.API.Models;
using OM.Assessment.API.ViewModels;

namespace OM.Assessment.API.Services;

public class CountryService(
    IOptions<DataApiConfig> dataApiConfigOptions) : ICountryService
{
    private readonly DataApiConfig _dataApiConfig = dataApiConfigOptions.Value ?? throw new ArgumentNullException(nameof(dataApiConfigOptions));
    private readonly HttpClient _httpClient = new();
    private IList<Country> _countries = new List<Country>();
    
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<PaginatedResponse> GetCountriesAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        await GetCountriesDataAsync(cancellationToken);
        int skip = (page - 1) * pageSize;
        
        var result = _countries
            .OrderBy(c => c.Name.Common)
            .Skip(skip)
            .Take(pageSize);
        
        return new PaginatedResponse()
        {
            Success = true,
            TotalItems = _countries.Count,
            Data = CountryViewModel.FromCountry(result),
        };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<ApiResponse> GetCountryAsync(string name, CancellationToken cancellationToken)
    {
        await GetCountriesDataAsync(cancellationToken);
        var result = _countries.FirstOrDefault(x => string.Equals(x.Name.Common, name, StringComparison.CurrentCultureIgnoreCase))!;
        
        return new ApiResponse()
        {
            Success = true,
            Data = CountyDetailsViewModel.FromCountry(result),
        };
    }

    /// <summary>
    /// Gets countries data from third party API
    /// </summary>
    private async Task GetCountriesDataAsync(CancellationToken cancellationToken)
    {
        if(_countries.Any())
            return;
        
        var response = await _httpClient.GetAsync(_dataApiConfig.Url, cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve data from API. Status Code: {response.StatusCode}");
        
        _countries = JsonConvert.DeserializeObject<List<Country>>(await response.Content.ReadAsStringAsync(cancellationToken));
    }
}