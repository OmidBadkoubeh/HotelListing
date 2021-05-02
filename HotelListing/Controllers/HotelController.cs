using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HotelListing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HotelController(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var result = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Something happened in {nameof(HotelController)}");
                return StatusCode(500, $"Internal Server Error. Please try again later.");
            }
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> {"Country"});
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Something happened in {nameof(HotelController)}");
                return StatusCode(500, $"Internal Server Error. Please try again later.");
            }
        }
    }
}