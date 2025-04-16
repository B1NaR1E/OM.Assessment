using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OM.Assessment.API.Configs;
using OM.Assessment.API.Controllers;
using OM.Assessment.API.Services;

namespace OM.Assessment.API.Tests;

public class CountryControllerTests
{
    private readonly IOptions<DataApiConfig> dataApiConfigOptions = Options.Create(new DataApiConfig()
    {
        Url = "https://restcountries.com/v3.1/all"
    });
    
    private readonly ILogger<CountriesController> logger = new Logger<CountriesController>(new LoggerFactory());
    
    [Fact]
    public async Task When_getting_all_Countries_returns_all_Countries()
    {
        // Arrange
        var service = new CountryService(dataApiConfigOptions);
        var controller = new CountriesController(service, logger);
        
        // Act
        var response = await controller.GetAsync(CancellationToken.None);

        // Arrange
        Assert.NotNull(response);
        Assert.Equal(typeof(OkObjectResult), response.GetType());
        Assert.Equal(200, ((OkObjectResult)response).StatusCode);
    }
    
    [Fact]
    public async Task When_getting_country_by_name_returns_country()
    {
        // Arrange
        var service = new CountryService(dataApiConfigOptions);
        var controller = new CountriesController(service, logger);
        
        var countryName = "Afghanistan";
        
        // Act
        var response = await controller.GetAsync(countryName, CancellationToken.None);
        
        // Arrange
        Assert.NotNull(response);
        Assert.Equal(typeof(OkObjectResult), response.GetType());
        Assert.Equal(200, ((OkObjectResult)response).StatusCode);
    }
}