using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OM.Assessment.API.Configs;
using OM.Assessment.API.Models;
using OM.Assessment.API.ViewModels;

namespace OM.Assessment.API.ServiceLayer;

public class CountryService(
    IOptions<DataApiConfig> dataApiConfigOptions) : ICountryService
{
    private readonly DataApiConfig _dataApiConfig = dataApiConfigOptions.Value ?? throw new ArgumentNullException(nameof(dataApiConfigOptions));
    private readonly HttpClient _httpClient = new();
    
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<IEnumerable<CountryViewModel>> GetCountriesAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var countries = await GetCountriesDataAsync(cancellationToken);
        int skip = (page - 1) * pageSize;
        
        var result = countries
            .OrderBy(c => c.Name.Common)
            .Skip(skip)
            .Take(pageSize);
        
        return CountryViewModel.FromCountry(result);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<CountyDetailsViewModel> GetCountryAsync(string name, CancellationToken cancellationToken)
    {
        var countries = await GetCountriesDataAsync(cancellationToken);
        var result = countries.FirstOrDefault(x => string.Equals(x.Name.Common, name, StringComparison.CurrentCultureIgnoreCase));
        
        return CountyDetailsViewModel.FromCountry(result);
    }

    /// <summary>
    /// Gets countries data from third party API
    /// </summary>
    private async Task<List<Country>> GetCountriesDataAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(_dataApiConfig.Url, cancellationToken);
        
        if(!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve data from API. Status Code: {response.StatusCode}");
        
        var result = JsonConvert.DeserializeObject<List<Country>>(await response.Content.ReadAsStringAsync(cancellationToken));
        
        if(result is null)
            throw new Exception("Unable to deserialize data from API.");
        
        return result;
    }
}