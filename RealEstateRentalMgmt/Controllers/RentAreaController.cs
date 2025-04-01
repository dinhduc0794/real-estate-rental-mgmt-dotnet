using Microsoft.AspNetCore.Mvc;
using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Controllers
{
    [ApiController]
    [Route("api/rentareas")]
    public class RentAreaController : ControllerBase
    {
        private readonly RentAreaRepository _rentAreaRepository;

        public RentAreaController(RentAreaRepository rentAreaRepository)
        {
            _rentAreaRepository = rentAreaRepository;
        }

        [HttpPost]
        public IActionResult AddRentArea([FromBody] RentArea rentArea)
        {
            _rentAreaRepository.Add(rentArea);
            return Ok(rentArea);
        }
    }
}