using RealEstateRentalMgmt.Models;
using RealEstateRentalMgmt.Models.DTOs;

namespace RealEstateRentalMgmt.Services.Converters
{
    public class BuildingConverter
    {
        public BuildingResponseDTO ToBuildingResponseDTO(Building building)
        {
            return new BuildingResponseDTO
            {
                Id = building.Id,
                Name = building.Name,
                Address = $"{building.Street}, {building.Ward}",
                ManagerName = building.ManagerName,
                ManagerPhone = building.ManagerPhone
            };
        }

        public Building ToBuildingEntity(BuildingDTO buildingDTO, Building building = null)
        {
            if (building == null)
            {
                building = new Building();
            }

            building.Name = buildingDTO.Name;
            building.Ward = buildingDTO.Ward;
            building.Street = buildingDTO.Street;
            building.NumberOfBasement = buildingDTO.NumberOfBasement;
            building.DistrictId = buildingDTO.DistrictId;
            building.ManagerName = buildingDTO.ManagerName;
            building.ManagerPhone = buildingDTO.ManagerPhone;
            // Gán giá trị mặc định như trong Java
            building.RentPrice = 20;

            return building;
        }
    }
}