using System;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.IRepository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HotelListing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CountryController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                _logger.Debug($"OK! with ${countries}");
                return Ok(countries);
                // return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Something went wrong in {nameof(GetCountries)}!");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}