using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
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
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                _logger.Debug($"OK! with ${countries}");
                var result = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(result);
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