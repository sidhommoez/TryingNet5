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
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

      
        public CountryController(IUnitOfWork unitOfWork,
        ILogger<CountryController> logger,
        IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var result = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" something wron in the {nameof(GetCountries)}");
                return StatusCode(500, " Interner server errors please contact server admin");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(
                    q => q.Id == id,
                    new List<string> { "Hotels" }
                    );
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" something wron in the {nameof(GetCountries)}");
                return StatusCode(500, " Interner server errors please contact server admin");
            }
        }
    }
}
