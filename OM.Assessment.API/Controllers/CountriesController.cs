using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OM.Assessment.API.ServiceLayer;

namespace OM.Assessment.API.Controllers;

[ApiController]
[Route("api/countries")]
public class CountriesController(
    ICountryService countryService, 
    ILogger<CountriesController> logger) : ControllerBase
{
    /// <summary>
    /// Retrieve all countries
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken, [FromQuery] int pageNo = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var countries = await countryService.GetCountriesAsync(pageNo, pageSize, cancellationToken);
            
            return Ok(new ApiResponse()
            {
                Success = true,
                Data = countries
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured while getting countries.");
            return BadRequestActionResult(ex.Message);
        }
    }
    
    /// <summary>
    /// Retrieve details about a specific country
    /// </summary>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync([FromRoute] string name, CancellationToken cancellationToken)
    {
        try
        {
            var country = await countryService.GetCountryAsync(name, cancellationToken);
            
            return Ok(new ApiResponse()
            {
                Success = true,
                Data = country
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured while trying to get the country by name.");
            return BadRequestActionResult(ex.Message);
        }
    }
    
    private IActionResult BadRequestActionResult(string resultErrors) 
        => BadRequest(new ApiResponse
        {
            Success = false,
            Message = resultErrors
        });
}