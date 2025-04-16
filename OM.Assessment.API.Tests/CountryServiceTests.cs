using Microsoft.Extensions.Options;
using OM.Assessment.API.Configs;
using OM.Assessment.API.Models;
using OM.Assessment.API.Services;
using OM.Assessment.API.ViewModels;

namespace OM.Assessment.API.Tests;

public class CountryServiceTests
{
    
    private readonly IOptions<DataApiConfig> dataApiConfigOptions = Options.Create(new DataApiConfig()
    {
        Url = "https://restcountries.com/v3.1/all"
    });
        
    [Fact]
    public async Task When_getting_all_Countries_returns_all_Countries()
    {
        // Arrange
        var service = new CountryService(dataApiConfigOptions);
        
        // Act
        var response = await service.GetCountriesAsync(1, 10, CancellationToken.None);
        
        // Arrange
        var data = response.Data as List<CountryViewModel>;
        Assert.NotNull(response);
        Assert.NotEmpty(data);
        Assert.Equal(10, data.Count);
    }
    
    [Fact]
    public async Task When_getting_country_by_name_returns_country()
    {
        // Arrange
        var service = new CountryService(dataApiConfigOptions);
        var countryName = "Afghanistan";
        // Act
        var response = await service.GetCountryAsync(countryName, CancellationToken.None);
        
        // Arrange
        var data = response.Data as CountyDetailsViewModel;
        Assert.NotNull(response);
        Assert.NotNull(data);
        Assert.Equal(countryName, data.Name);
    }
}