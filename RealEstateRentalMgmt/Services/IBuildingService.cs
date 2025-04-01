using RealEstateRentalMgmt.Models.DTOs;

namespace RealEstateRentalMgmt.Services
{
    public interface IBuildingService
    {
        List<BuildingResponseDTO> FindAll(Dictionary<string, object> parameters, List<string> typeCodes);
        void SaveBuilding(BuildingDTO buildingDTO);
        void DeleteBuilding(long[] ids);
    }
}
