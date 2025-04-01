using Microsoft.AspNetCore.Mvc;
using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Controllers
{
    [ApiController]
    [Route("api/districts")]
    public class DistrictController : ControllerBase
    {
        private readonly DistrictRepository _districtRepository;

        public DistrictController(DistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        [HttpPost]
        public IActionResult AddDistrict([FromBody] District district)
        {
            _districtRepository.Add(district);
            return Ok(district);
        }
    }
}