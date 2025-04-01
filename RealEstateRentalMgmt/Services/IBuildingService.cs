using RealEstateRentalMgmt.Models.DTOs;

namespace RealEstateRentalMgmt.Services
{
    public interface IBuildingService
    {
        List<BuildingResponseDTO> FindAll(BuildingSearchDTO searchDTO);
        void SaveBuilding(BuildingDTO buildingDTO);
        void DeleteBuilding(long[] ids);
    }
}