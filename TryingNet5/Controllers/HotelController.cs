using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TryingNet5.IRepository;
using TryingNet5.Models;

namespace TryingNet5.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

      
        public HotelController(IUnitOfWork unitOfWork,
        ILogger<HotelController> logger,
        IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHoteles()
        {
            try
            {
                var Hoteles = await _unitOfWork.Hotels.GetAll();
                var result = _mapper.Map<IList<HotelDTO>>(Hoteles);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" something wron in the {nameof(GetHoteles)}");
                return StatusCode(500, " Interner server errors please contact server admin");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var Hotel = await _unitOfWork.Hotels.Get(
                    q => q.Id == id,
                    new List<string> { "Country" }
                    );
                var result = _mapper.Map<HotelDTO>(Hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" something wron in the {nameof(GetHoteles)}");
                return StatusCode(500, " Interner server errors please contact server admin");
            }
        }
    }
}
