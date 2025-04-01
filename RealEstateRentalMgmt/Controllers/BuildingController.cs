using Microsoft.AspNetCore.Mvc;
using RealEstateRentalMgmt.Exceptions;
using RealEstateRentalMgmt.Models.DTOs;
using RealEstateRentalMgmt.Services;

namespace RealEstateRentalMgmt.Controllers
{
    [ApiController]
    [Route("api/buildings")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public IActionResult GetBuildings([FromQuery] BuildingSearchDTO searchDTO)
        {
            var buildings = _buildingService.FindAll(searchDTO);
            return Ok(buildings);
        }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] BuildingDTO buildingDTO)
        {
            Validate(buildingDTO);
            _buildingService.SaveBuilding(buildingDTO);
            return Ok();
        }

        [HttpDelete("{ids}")]
        public IActionResult DeleteBuilding([FromRoute] long[] ids)
        {
            _buildingService.DeleteBuilding(ids);
            return Ok();
        }

        private void Validate(BuildingDTO building)
        {
            if (string.IsNullOrEmpty(building.Name) || building.NumberOfBasement == null)
            {
                throw new FieldRequiredException("Name & NumberOfBasement are NOT NULL key");
            }
        }
    }
}