using Microsoft.AspNetCore.Mvc;
using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Controllers
{
    [ApiController]
        
    public class BuildingController : ControllerBase
    {
        private readonly BuildingRepository _buildingRepository;

        public BuildingController(BuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        [HttpPost]
        public IActionResult AddBuilding([FromBody] Building building)
        {
            _buildingRepository.Add(building);
            return Ok(building);
        }
    }
}